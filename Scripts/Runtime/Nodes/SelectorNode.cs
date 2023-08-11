namespace MPewsey.Decidutree.Nodes
{
    /// <summary>
    /// Ticks the node's children until the first Success or Running node is found.
    /// </summary>
    public class SelectorNode : BehaviorNode
    {
        /// <summary>
        /// Does nothing.
        /// </summary>
        protected override void OnInitialize()
        {

        }

        /// <summary>
        /// Ticks the node's children until the first Success or Running node is found
        /// and returns the status. Returns Failure if no nodes are running or successful.
        /// </summary>
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