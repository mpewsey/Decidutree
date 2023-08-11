namespace MPewsey.Decidutree
{
    /// <summary>
    /// A shared variable entry in a Blackboard.
    /// </summary>
    public class BlackboardEntry<T>
    {
        /// <summary>
        /// The entry key.
        /// </summary>
        public object Key { get; }

        /// <summary>
        /// The shared value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Creates a new blackboard entry.
        /// </summary>
        /// <param name="key">The entry key.</param>
        public BlackboardEntry(object key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return $"BlackboardEntry<{typeof(T)}>(Key = {Key}, Value = {Value})";
        }
    }
}