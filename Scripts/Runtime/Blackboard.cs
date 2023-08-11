using System.Collections.Generic;

namespace MPewsey.Decidutree
{
    /// <summary>
    /// A blackboard, containing shared variable entries for a behavior tree instance.
    /// </summary>
    public class Blackboard
    {
        /// <summary>
        /// A dictionary of blackboard entries by key.
        /// </summary>
        private Dictionary<object, object> Entries { get; } = new Dictionary<object, object>();

        /// <summary>
        /// Creates a new blackboard entry with the specified key and adds it to the dictionary.
        /// </summary>
        /// <param name="key">The entry key.</param>
        private BlackboardEntry<T> CreateEntry<T>(object key)
        {
            ValidateKey(key);
            var entry = new BlackboardEntry<T>(key);
            Entries.Add(key, entry);
            return entry;
        }

        /// <summary>
        /// Returns the blackboard entry for the specified key.
        /// </summary>
        /// <param name="key">The entry key.</param>
        public BlackboardEntry<T> GetValue<T>(object key)
        {
            var entry = GetEntry<T>(key);

            if (entry != null)
                return entry;

            throw new KeyNotFoundException($"Key does not exist: {key}.");
        }

        /// <summary>
        /// Sets the value for the blackboard entry with the specified key.
        /// If the entry does not already exist, creates it.
        /// Returns the entry.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <param name="value">The entry value.</param>
        public BlackboardEntry<T> SetValue<T>(object key, T value)
        {
            var entry = GetEntry<T>(key) ?? CreateEntry<T>(key);
            entry.Value = value;
            return entry;
        }

        /// <summary>
        /// If a blackboard entry with the specified key does not already exist,
        /// creates it with the specified value. Otherwise, returns the existing,
        /// unmodified blackboard entry for the key.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <param name="value">The entry value.</param>
        public BlackboardEntry<T> EnsureSetValue<T>(object key, T value)
        {
            var entry = GetEntry<T>(key);

            if (entry != null)
                return entry;

            var newEntry = CreateEntry<T>(key);
            newEntry.Value = value;
            return newEntry;
        }

        /// <summary>
        /// Checks that the specified key is valid and raises exceptions if not.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <exception cref="System.ArgumentException">Raised for an invalid key.</exception>
        private void ValidateKey(object key)
        {
            switch (key)
            {
                case null:
                    throw new System.ArgumentException("Key cannot be null.");
                case string str when string.IsNullOrWhiteSpace(str):
                    throw new System.ArgumentException("String key cannot be null or whitespace.");
            }
        }

        /// <summary>
        /// Returns the blackboard entry for the specified key if it exists. Otherwise, returns null.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <exception cref="System.InvalidCastException">Raised if the blackboard entry is not of the specified type.</exception>
        private BlackboardEntry<T> GetEntry<T>(object key)
        {
            ValidateKey(key);

            if (Entries.TryGetValue(key, out object entry))
            {
                if (entry is BlackboardEntry<T> castEntry)
                    return castEntry;
                throw new System.InvalidCastException($"Invalid cast for key: {key}. Attempted to cast {entry.GetType()} to {typeof(BlackboardEntry<T>)}.");
            }

            return null;
        }
    }
}