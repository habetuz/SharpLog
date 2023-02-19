// <copyright file="OutputContainer.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using SharpLog.Outputs;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SharpLog.Settings
{
    /// <summary>
    /// Container for the output settings.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OutputContainer : IDisposable, IList<Output>
    {
        private readonly List<Output> outputs = new();

        public int Count => this.outputs.Count;
        public bool IsReadOnly => false;

        public Output this[int index]
        {
            get => this.outputs[index];

            set
            {
                if (this.outputs[index] is AsyncOutput asyncOutput)
                {
                    asyncOutput.Dispose();
                }
                else if (value is GenericOutput genericOutput)
                {
                    value = GenerateOutput(genericOutput);
                }

                this.outputs[index] = value;

                if (this.outputs[index] is not AsyncOutput newAsyncOutput)
                {
                    return;
                }

                newAsyncOutput.Start();
            }
        }

        private static Output GenerateOutput(GenericOutput genericOutput)
        {
            if (genericOutput.Type is null)
            {
                throw new NullReferenceException("GenericOutput.Type: The type parameter cannot be null!");
            }

            try
            {
                var type = Type.GetType("SharpLog.Outputs." + genericOutput.Type);
                if (type is null)
                {
                    throw new NullReferenceException("GenericOutput.Type");
                }

                var objGraph = new Dictionary<string, object>(genericOutput.ToArray());

                var serializer = new SerializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .Build();
                var yaml = serializer.Serialize(objGraph);

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .WithTypeMapping<ICredentialsByHost, NetworkCredential>()
                    .WithTypeMapping<Output, GenericOutput>()
                    .Build();

                var output = deserializer.Deserialize(yaml, type);
                if (output is null)
                {
                    throw new NullReferenceException("The yaml deserializer returned null where it should not have done it.");
                }

                return (Output)output;
            }
            catch (Exception e) when (
                e is ArgumentException or
                    TypeLoadException or
                    FileLoadException or
                    BadImageFormatException or
                    NullReferenceException
            )
            {
                throw new ArgumentException($"Output {genericOutput.Type} could not be found or read!");
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.outputs.ForEach(o =>
            {
                if (o is not AsyncOutput asyncOutput)
                {
                    return;
                }

                asyncOutput.Dispose();
            });
        }

        public int IndexOf(Output output)
        {
            return outputs.IndexOf(output);
        }

        public void Insert(int index, Output output)
        {
            if (output is GenericOutput genericOutput)
            {
                output = GenerateOutput(genericOutput);
            }

            if (output is AsyncOutput asyncOutput)
            {
                asyncOutput.Start();
            }

            this.outputs.Insert(index, output);
        }

        public void RemoveAt(int index)
        {
            if (this[index] is AsyncOutput asyncOutput)
            {
                asyncOutput.Dispose();
            }

            this.outputs.RemoveAt(index);
        }

        public void Add(Output output)
        {
            if (output is GenericOutput genericOutput)
            {
                output = GenerateOutput(genericOutput);
            }

            this.outputs.Add(output);

            if (output is not AsyncOutput asyncOutput)
            {
                return;
            }

            asyncOutput.Start();
        }

        public void Clear()
        {
            this.Dispose();
            this.outputs.Clear();
        }

        public bool Contains(Output output)
        {
            return this.outputs.Contains(output);
        }

        public void CopyTo(Output[] array, int arrayIndex)
        {
            this.outputs.CopyTo(array, arrayIndex);
        }

        public bool Remove(Output output)
        {
            var success = this.outputs.Remove(output);

            if (output is not AsyncOutput asyncOutput)
            {
                return success;
            }

            asyncOutput.Dispose();
            return success;
        }

        public IEnumerator<Output> GetEnumerator()
        {
            return this.outputs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.outputs.GetEnumerator();
        }
    }
}