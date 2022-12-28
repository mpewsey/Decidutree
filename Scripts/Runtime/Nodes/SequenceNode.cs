namespace MPewsey.BehaviorTree.Nodes
{
    /// <summary>
    /// Ticks the node's children until the first Failure or Running node is found.
    /// </summary>
    public class SequenceNode : BehaviorNode
    {
        protected override void OnInitialize()
        {

        }

        /// <summary>
        /// Ticks the node's children until the first Failure or Running node is found
        /// and returns the status. Returns Success if no running or failing node is found.
        /// </summary>
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