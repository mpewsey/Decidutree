namespace MPewsey.BehaviorTree
{
    public class SelectorNode : BehaviorNode
    {
        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            foreach (var node in Children)
            {
                var status = node.Tick();

                if (status != BehaviorStatus.Failure)
                    return status;
            }

            return BehaviorStatus.Failure;
        }
    }
}