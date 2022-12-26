namespace MPewsey.BehaviorTree
{
    public class SequenceNode : BehaviorNode
    {
        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            foreach (var node in Children)
            {
                var status = node.Tick();

                if (status != BehaviorStatus.Success)
                    return status;
            }

            return BehaviorStatus.Success;
        }
    }
}