// <copyright file="GenericOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using SharpLog.Settings;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SharpLog.Outputs
{
    public class GenericOutput : Output, IDictionary<string, object>
    {
        private readonly Dictionary<string, object> parameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericOutput"/> class.
        /// </summary>
        public GenericOutput()
            : this(null, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericOutput"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameter">The parameter dictionary.</param>
        /// <param name="format">The format.</param>
        /// <param name="levels">The level settings.</param>
        public GenericOutput(string? type = null, Dictionary<string, object>? parameter = null, string? format = null, LevelContainer? levels = null)
            : base(format, levels)
        {
            this.Type = type;
            this.parameter = parameter ?? new();
        }

        /// <summary>
        /// The type name of the output (found in namespace SharpLog.Outputs).
        /// </summary>
        public string? Type
        { get; set; }

        /// <inheritdoc />
        public object this[string key]
        {
            get => this.parameter[key];

            set
            {
                if (string.Equals(key, "type", StringComparison.OrdinalIgnoreCase))
                {
                    this.Type = (string)value;
                    return;
                }

                this.parameter[key] = value;
            }
        }

        /// <inheritdoc />
        public ICollection<string> Keys => this.parameter.Keys;

        /// <inheritdoc />
        public ICollection<object> Values => this.parameter.Values;

        /// <inheritdoc />
        public int Count => this.parameter.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <summary>
        /// Constructs an output from the given type and parameter.
        /// </summary>
        /// <returns>The constructed output.</returns>
        /// <exception cref="NullReferenceException">Thrown when <see cref="GenericOutput.Type" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <see cref="GenericOutput.Type" /> class cannot be found.</exception>
        public Output ConstructOutput()
        {
            if (this.Type is null)
            {
                throw new NullReferenceException("GenericOutput.Type: The type parameter cannot be null!");
            }

            try
            {
                var type = System.Type.GetType("SharpLog.Outputs." + this.Type);
                if (type is null)
                {
                    throw new NullReferenceException("GenericOutput.Type");
                }

                var objGraph = new Dictionary<string, object>(this.ToArray());

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
                throw new ArgumentException($"Output {this.Type} could not be found or read!");
            }
        }

        /// <inheritdoc />
        public void Add(string key, object value)
        {
            if (string.Equals(key, "type", StringComparison.OrdinalIgnoreCase))
            {
                this.Type = (string)value;
                return;
            }

            this.parameter.Add(key, value);
        }

        /// <inheritdoc />
        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.parameter.Clear();
            this.Type = null;
        }

        /// <inheritdoc />
        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.parameter.Contains(item);
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return this.parameter.ContainsKey(key);
        }

        /// <inheritdoc />
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            this.parameter.ToArray().CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.parameter.GetEnumerator();
        }

        /// <inheritdoc />
        public bool Remove(string key)
        {
            return this.parameter.Remove(key);
        }

        /// <inheritdoc />
        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.parameter.Remove(item.Key);
        }

        /// <inheritdoc />
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out object value)
        {
            return this.parameter.TryGetValue(key, out value);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.parameter.GetEnumerator();
        }

        /// <inheritdoc />
        public override void Write(string formattedLog, Log log)
        {
            throw new NotSupportedException("Construct this output before writing with it.");
        }
    }
}