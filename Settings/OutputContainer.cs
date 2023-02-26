// <copyright file="OutputContainer.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System.Collections;
using SharpLog.Outputs;

namespace SharpLog.Settings
{
    /// <summary>
    /// Container for output settings.
    /// </summary>
    public class OutputContainer : IDisposable, IList<Output>
    {
        private readonly List<Output> outputs = new();

        /// <inheritdoc />
        public int Count => this.outputs.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
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
                    value = genericOutput.ConstructOutput();
                }

                this.outputs[index] = value;

                if (this.outputs[index] is not AsyncOutput newAsyncOutput)
                {
                    return;
                }

                newAsyncOutput.Start();
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public int IndexOf(Output output)
        {
            return outputs.IndexOf(output);
        }

        /// <inheritdoc />
        public void Insert(int index, Output output)
        {
            if (output is GenericOutput genericOutput)
            {
                output = genericOutput.ConstructOutput();
            }

            if (output is AsyncOutput asyncOutput)
            {
                asyncOutput.Start();
            }

            this.outputs.Insert(index, output);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            if (this[index] is AsyncOutput asyncOutput)
            {
                asyncOutput.Dispose();
            }

            this.outputs.RemoveAt(index);
        }

        /// <inheritdoc />
        public void Add(Output output)
        {
            if (output is GenericOutput genericOutput)
            {
                output = genericOutput.ConstructOutput();
            }

            this.outputs.Add(output);

            if (output is not AsyncOutput asyncOutput)
            {
                return;
            }

            asyncOutput.Start();
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.Dispose();
            this.outputs.Clear();
        }

        /// <inheritdoc />
        public bool Contains(Output output)
        {
            return this.outputs.Contains(output);
        }

        /// <inheritdoc />
        public void CopyTo(Output[] array, int arrayIndex)
        {
            this.outputs.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public IEnumerator<Output> GetEnumerator()
        {
            return this.outputs.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.outputs.GetEnumerator();
        }
    }
}