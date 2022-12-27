using MPewsey.BehaviorTree.Subnodes;
using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes
{
    /// <summary>
    /// The base class for all behavior nodes.
    /// </summary>
    public abstract class BehaviorNode : MonoBehaviour
    {
        /// <summary>
        /// The behavior tree, or root of the tree.
        /// </summary>
        public BehaviorTree Root { get; private set; }

        /// <summary>
        /// The parent node.
        /// </summary>
        public BehaviorNode Parent { get; private set; }

        /// <summary>
        /// An array of child nodes.
        /// </summary>
        public BehaviorNode[] Children { get; private set; }

        /// <summary>
        /// An array of attached subnode components.
        /// </summary>
        public BehaviorSubnode[] Subnodes { get; private set; }

        /// <summary>
        /// Returns the behavior tree's blackboard.
        /// </summary>
        public Blackboard Blackboard => Root.Blackboard;

        /// <summary>
        /// This method should be used to perform any necessary one time set up for the node,
        /// such as caching references to any blackboard entries used by the node.
        /// 
        /// This method is called when the Initialize method is called for the node.
        /// </summary>
        protected abstract void OnInitialize();

        /// <summary>
        /// This method should be used to implement any functionality for the node
        /// and should return an appropriate status for the node.
        /// </summary>
        protected abstract BehaviorStatus OnTick();

        /// <summary>
        /// Initializes the node and its child nodes and subnodes.
        /// </summary>
        /// <param name="root">The behavior tree, or root node.</param>
        /// <param name="parent">The parent node.</param>
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

        /// <summary>
        /// Ticks all subnodes in a sequence, then calls the nodes OnTick methods
        /// if they are all satisfied.
        /// </summary>
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

        /// <summary>
        /// Adds a child to the node.
        /// </summary>
        /// <param name="name">The child Game Object name.</param>
        public T AddChildNode<T>(string name) where T : BehaviorNode
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(transform);
            return obj.AddComponent<T>();
        }

        /// <summary>
        /// Adds a subnode to the node.
        /// </summary>
        public T AddSubnode<T>() where T : BehaviorSubnode
        {
            return gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Returns an array of components on the immediate children of the specified
        /// transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
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