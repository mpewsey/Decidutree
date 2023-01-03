using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes
{
    /// <summary>
    /// A behavior node that returns a specified status.
    /// </summary>
    public class StatusNode : BehaviorNode
    {
        [SerializeField]
        private BehaviorStatus _status;
        /// <summary>
        /// The status returned by the node.
        /// </summary>
        public BehaviorStatus Status { get => _status; set => _status = value; }

        /// <summary>
        /// Sets the node values and returns the node.
        /// </summary>
        /// <param name="status">The return status.</param>
        public StatusNode SetValues(BehaviorStatus status)
        {
            Status = status;
            return this;
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        protected override void OnInitialize()
        {

        }

        /// <summary>
        /// Returns the specified status.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            return Status;
        }
    }
}