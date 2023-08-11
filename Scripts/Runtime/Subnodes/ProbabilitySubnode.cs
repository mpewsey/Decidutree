using UnityEngine;

namespace MPewsey.Decidutree.Subnodes
{
    /// <summary>
    /// A subnode that returns success with a specified probability.
    /// </summary>
    public class ProbabilitySubnode : BehaviorSubnode
    {
        [Range(0, 1)]
        [SerializeField]
        private float _probability;
        /// <summary>
        /// The probability that the subnode will return Success.
        /// </summary>
        public float Probability
        {
            get => _probability;
            set => _probability = Mathf.Clamp(value, 0, 1);
        }

        /// <summary>
        /// Sets the values for the subnode and returns the subnode.
        /// </summary>
        /// <param name="probability">The success probability.</param>
        public ProbabilitySubnode SetValues(float probability)
        {
            Probability = probability;
            return this;
        }

        private void OnValidate()
        {
            Probability = Probability;
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        protected override void OnInitialize()
        {

        }

        /// <summary>
        /// Generates a random number and returns Success if it falls
        /// with the specified probability. Otherwise, returns Failure.
        /// </summary>
        protected override BehaviorStatus OnTick()
        {
            if (Probability > 0 && Random.value <= Probability)
                return BehaviorStatus.Success;
            return BehaviorStatus.Failure;
        }
    }
}