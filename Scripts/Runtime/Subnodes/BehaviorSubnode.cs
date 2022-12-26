using UnityEngine;

namespace MPewsey.BehaviorTree
{
    [RequireComponent(typeof(BehaviorNode))]
    public abstract class BehaviorSubnode : MonoBehaviour
    {
        public BehaviorTree Root { get; private set; }
        public BehaviorNode Parent { get; private set; }
        public Blackboard Blackboard => Root.Blackboard;

        protected abstract void OnInitialize();
        protected abstract BehaviorStatus OnTick();

        public void Initialize(BehaviorTree root, BehaviorNode parent)
        {
            Root = root;
            Parent = parent;
            OnInitialize();
        }

        public BehaviorStatus Tick()
        {
            return OnTick();
        }
    }
}