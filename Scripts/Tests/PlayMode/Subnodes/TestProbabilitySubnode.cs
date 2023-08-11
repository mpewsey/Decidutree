using MPewsey.Decidutree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.Decidutree.Subnodes.Tests.PlayMode
{
    public class TestProbabilitySubnode
    {
        private BehaviorTree Tree { get; set; }

        [SetUp]
        public void SetUp()
        {
            Tree = new GameObject("Behavior Tree").AddComponent<BehaviorTree>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(Tree.gameObject);
        }

        [TestCase(12345)]
        public void TestTick(int seed)
        {
            var subnode = Tree.AddSubnode<ProbabilitySubnode>().SetValues(0.5f);

            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Initialize();

            Random.InitState(seed);
            var expected = new BehaviorStatus[1000];

            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = Random.value <= 0.5f ? BehaviorStatus.Success : BehaviorStatus.Failure;
            }

            Random.InitState(seed);
            var results = new BehaviorStatus[expected.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Tree.Tick();
            }

            CollectionAssert.AreEqual(expected, results);
        }
    }
}