using System.Collections.Generic;

namespace MPewsey.BehaviorTree
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
            ValidateKey(key);
            return (BlackboardEntry<T>)Entries[key];
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
            ValidateKey(key);

            if (Entries.TryGetValue(key, out object entry))
            {
                var castEntry = (BlackboardEntry<T>)entry;
                castEntry.Value = value;
                return castEntry;
            }

            var newEntry = CreateEntry<T>(key);
            newEntry.Value = value;
            return newEntry;
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
            ValidateKey(key);

            if (Entries.TryGetValue(key, out object entry))
                return (BlackboardEntry<T>)entry;

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
    }
}