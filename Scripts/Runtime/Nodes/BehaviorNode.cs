using MPewsey.BehaviorTree.Subnodes;
using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes
{
    public abstract class BehaviorNode : MonoBehaviour
    {
        public BehaviorTree Root { get; private set; }
        public BehaviorNode Parent { get; private set; }
        public BehaviorNode[] Children { get; private set; }
        public BehaviorSubnode[] Subnodes { get; private set; }
        public Blackboard Blackboard => Root.Blackboard;

        protected abstract void OnInitialize();
        protected abstract BehaviorStatus OnTick();

        protected void Initialize(BehaviorTree root, BehaviorNode parent)
        {
            Root = root;
            Parent = parent;
            Subnodes = GetComponents<BehaviorSubnode>();
            Children = GetChildComponents<BehaviorNode>(transform);
            OnInitialize();

            foreach (var node in Subnodes)
            {
                node.Initialize(root, this);
            }

            foreach (var node in Children)
            {
                node.Initialize(root, this);
            }
        }

        public BehaviorStatus Tick()
        {
            foreach (var node in Subnodes)
            {
                var status = node.Tick();

                if (status != BehaviorStatus.Success)
                    return status;
            }

            return OnTick();
        }

        public T AddChildNode<T>(string name) where T : BehaviorNode
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(transform);
            return obj.AddComponent<T>();
        }

        public T AddSubnode<T>() where T : BehaviorSubnode
        {
            return gameObject.AddComponent<T>();
        }

        public static T[] GetChildComponents<T>(Transform parent)
        {
            if (parent == null || parent.childCount == 0)
                return System.Array.Empty<T>();

            var count = 0;
            var components = new T[parent.childCount];

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).TryGetComponent(out T component))
                    components[count++] = component;
            }

            System.Array.Resize(ref components, count);
            return components;
        }
    }
}