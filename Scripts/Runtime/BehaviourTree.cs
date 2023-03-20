using MPewsey.BehaviorTree.Nodes;

namespace MPewsey.BehaviorTree
{
    /// <summary>
    /// A behavior tree component.
    /// 
    /// When ticked, the tree evaluates in the same manner as a SelectorNode.
    /// </summary>
    public class BehaviourTree : SelectorNode
    {
        /// <summary>
        /// The tree's blackboard.
        /// </summary>
        public new Blackboard Blackboard { get; } = new Blackboard();

        /// <summary>
        /// Builds and initializes all nodes in the tree.
        /// </summary>
        public void Initialize()
        {
            Initialize(this, null);
        }
    }
}