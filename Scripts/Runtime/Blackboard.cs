using System.Collections.Generic;

namespace MPewsey.BehaviorTree
{
    public class Blackboard
    {
        private Dictionary<object, object> Entries { get; } = new Dictionary<object, object>();

        private BlackboardEntry<T> CreateEntry<T>(object key)
        {
            var entry = new BlackboardEntry<T>(key);
            Entries.Add(key, entry);
            return entry;
        }

        public BlackboardEntry<T> GetValue<T>(object key)
        {
            return (BlackboardEntry<T>)Entries[key];
        }

        public BlackboardEntry<T> SetValue<T>(object key, T value)
        {
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

        public BlackboardEntry<T> EnsureSetValue<T>(object key, T value)
        {
            if (Entries.TryGetValue(key, out object entry))
                return (BlackboardEntry<T>)entry;

            var newEntry = CreateEntry<T>(key);
            newEntry.Value = value;
            return newEntry;
        }
    }
}