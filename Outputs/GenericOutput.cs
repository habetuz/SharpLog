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

namespace SharpLog.Outputs
{
    public class GenericOutput : Output, IDictionary<string, object>
    {
        private readonly Dictionary<string, object> parameter = new();

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
            return;
        }
    }
}