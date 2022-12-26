namespace MPewsey.BehaviorTree
{
    public class BehaviorTree : SelectorNode
    {
        public new Blackboard Blackboard { get; } = new Blackboard();

        public void Initialize()
        {
            Initialize(this, null);
        }
    }
}