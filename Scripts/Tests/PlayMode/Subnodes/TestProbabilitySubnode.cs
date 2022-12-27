using MPewsey.BehaviorTree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes.Tests.PlayMode
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

        [Test]
        public void TestTick()
        {
            var seed = 12345;
            Tree.AddSubnode<TickCounterSubnode>();

            var subnode = Tree.AddSubnode<ProbabilitySubnode>();
            subnode.Probability = 0.5f;

            Tree.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;
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