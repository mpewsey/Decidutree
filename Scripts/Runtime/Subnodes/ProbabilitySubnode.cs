using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes
{
    public class ProbabilitySubnode : BehaviorSubnode
    {
        [Range(0, 1)]
        [SerializeField]
        private float _probability;
        public float Probability
        {
            get => _probability;
            set => _probability = Mathf.Clamp(value, 0, 1);
        }

        private void OnValidate()
        {
            Probability = Probability;
        }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            if (Probability > 0 && Random.value <= Probability)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}