using UnityEngine;

namespace MPewsey.BehaviorTree
{
    public class StatusNode : BehaviorNode
    {
        [SerializeField]
        private BehaviorStatus _status;
        public BehaviorStatus Status { get => _status; set => _status = value; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            return Status;
        }
    }
}