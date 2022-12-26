namespace MPewsey.BehaviorTree
{
    public class BlackboardEntry<T>
    {
        public object Key { get; }
        public T Value { get; set; }

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