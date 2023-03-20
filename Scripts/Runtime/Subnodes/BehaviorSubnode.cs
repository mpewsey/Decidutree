using MPewsey.BehaviorTree.Nodes;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    /// <summary>
    /// The base class for all behavior subnodes.
    /// </summary>
    [RequireComponent(typeof(BehaviorNode))]
    public abstract class BehaviorSubnode : MonoBehaviour
    {
        /// <summary>
        /// The behavior tree, or root of the tree.
        /// </summary>
        public BehaviourTree Root { get; private set; }

        /// <summary>
        /// The parent node.
        /// </summary>
        public BehaviorNode Parent { get; private set; }

        /// <summary>
        /// Returns the behavior tree's blackboard.
        /// </summary>
        public Blackboard Blackboard => Root.Blackboard;

        /// <summary>
        /// This method should be used to perform any necessary one time set up for the subnode,
        /// such as caching references to any blackboard entries used by the subnode.
        /// 
        /// This method is called when the Initialize method is called for the subnode.
        /// </summary>
        protected abstract void OnInitialize();

        /// <summary>
        /// This method should be used to implement any functionality for the subnode
        /// and should return an appropriate status for the subnode.
        /// </summary>
        protected abstract BehaviorStatus OnTick();

        /// <summary>
        /// Initializes the subnode.
        /// </summary>
        /// <param name="root">The behavior tree, or root node.</param>
        /// <param name="parent">The parent node.</param>
        public void Initialize(BehaviourTree root, BehaviorNode parent)
        {
            Root = root;
            Parent = parent;
            OnInitialize();
        }

        /// <summary>
        /// Ticks the OnTick method and returns its status.
        /// </summary>
        public BehaviorStatus Tick()
        {
            return OnTick();
        }
    }
}