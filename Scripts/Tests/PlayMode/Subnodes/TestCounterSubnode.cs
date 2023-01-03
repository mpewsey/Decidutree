using MPewsey.BehaviorTree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes.Tests.PlayMode
{
    public class TestCounterSubnode
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
            var counter = Tree.AddSubnode<CounterSubnode>().SetValues("Counter");
            var node = Tree.AddChildNode<StatusNode>("Success Node");
            node.Status = BehaviorStatus.Success;
            Tree.Initialize();

            for (int i = 1; i < 1000; i++)
            {
                Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
                Assert.AreEqual(i, counter.Counter.Value);
            }
        }
    }
}