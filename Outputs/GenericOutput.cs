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

        public string? Type
        { get; set; }

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

        public ICollection<string> Keys => this.parameter.Keys;
        public ICollection<object> Values => this.parameter.Values;
        public int Count => this.parameter.Count;
        public bool IsReadOnly => false;

        public void Add(string key, object value)
        {
            if (string.Equals(key, "type", StringComparison.OrdinalIgnoreCase))
            {
                this.Type = (string)value;
                return;
            }

            this.parameter.Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.parameter.Clear();
            this.Type = null;
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.parameter.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return this.parameter.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            this.parameter.ToArray().CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.parameter.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return this.parameter.Remove(key);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.parameter.Remove(item.Key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out object value)
        {
            return this.parameter.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.parameter.GetEnumerator();
        }

        public override void Write(string formattedLog, Log log)
        {
            return;
        }
    }
}