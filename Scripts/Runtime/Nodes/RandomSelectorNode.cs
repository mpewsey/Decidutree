using UnityEngine;

namespace MPewsey.Decidutree.Nodes
{
    /// <summary>
    /// A selector node that operates on child nodes in a random order.
    /// </summary>
    public class RandomSelectorNode : SelectorNode
    {
        /// <summary>
        /// Shuffles the child nodes then ticks them in the same manner as a SelectorNode.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            ShuffleChildren();
            return base.OnTick();
        }

        /// <summary>
        /// Shuffles the child nodes array.
        /// </summary>
        private void ShuffleChildren()
        {
            for (int i = 0; i < Children.Length - 1; i++)
            {
                var j = Random.Range(i, Children.Length);
                (Children[i], Children[j]) = (Children[j], Children[i]);
            }
        }
    }
}