using System.Collections.Generic;

namespace MPewsey.BehaviorTree
{
    /// <summary>
    /// Contains methods for comparing objects.
    /// </summary>
    public static class Comparison
    {
        /// <summary>
        /// Returns true if the comparison between two values is satisfied.
        /// </summary>
        /// <param name="comparisonType">The comparison type.</param>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <exception cref="System.ArgumentException">Raised if the comparison type is not handled.</exception>
        public static bool IsSatisfied<T>(ComparisonType comparisonType, T left, T right)
        {
            var comparison = Comparer<T>.Default.Compare(left, right);

            switch (comparisonType)
            {
                case ComparisonType.Equal:
                    return comparison == 0;
                case ComparisonType.NotEqual:
                    return comparison != 0;
                case ComparisonType.LessThan:
                    return comparison < 0;
                case ComparisonType.LessThanOrEqual:
                    return comparison <= 0;
                case ComparisonType.GreaterThan:
                    return comparison > 0;
                case ComparisonType.GreaterThanOrEqual:
                    return comparison >= 0;
                default:
                    throw new System.ArgumentException($"Unhandled comparison type: {comparisonType}.");
            }
        }
    }
}