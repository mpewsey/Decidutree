namespace MPewsey.BehaviorTree.Subnodes
{
    public class TickCountIsEvenSubnode : BehaviorSubnode
    {
        public BlackboardEntry<uint> TickCount { get; private set; }

        protected override void OnInitialize()
        {
            TickCount = Blackboard.EnsureSetValue(BlackboardKeys.TickCount, 0u);
        }

        protected override BehaviorStatus OnTick()
        {
            if (TickCount.Value % 2 == 0)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}