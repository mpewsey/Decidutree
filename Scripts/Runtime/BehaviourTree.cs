using MPewsey.BehaviorTree.Nodes;
using UnityEngine;

namespace MPewsey.BehaviorTree
{
    /// <summary>
    /// A behavior tree component.
    /// 
    /// When ticked, the tree evaluates in the same manner as a SelectorNode.
    /// </summary>
    public class BehaviourTree : SelectorNode
    {
        [SerializeField] private InitializeMode _initializeMode = InitializeMode.Manual;
        /// <summary>
        /// The initialization option for the tree.
        /// </summary>
        public InitializeMode InitializeMode { get => _initializeMode; set => _initializeMode = value; }

        /// <summary>
        /// The tree's blackboard.
        /// </summary>
        public new Blackboard Blackboard { get; } = new Blackboard();

        private void Awake()
        {
            if (InitializeMode == InitializeMode.OnAwake)
                Initialize();
        }

        private void Start()
        {
            if (InitializeMode == InitializeMode.OnStart)
                Initialize();
        }

        /// <summary>
        /// Builds and initializes all nodes in the tree.
        /// </summary>
        public void Initialize()
        {
            Initialize(this, null);
        }
    }
}