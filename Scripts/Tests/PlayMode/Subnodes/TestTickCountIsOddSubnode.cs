using MPewsey.BehaviorTree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes.Tests.PlayMode
{
    public class TestTickCountIsOddSubnode
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
            Tree.AddSubnode<TickCounterSubnode>();
            var subnode = Tree.AddSubnode<TickCountIsOddSubnode>();
            Tree.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;
            Tree.Initialize();

            for (int i = 1; i < 1000; i++)
            {
                var status = i % 2 == 1 ? BehaviorStatus.Success : BehaviorStatus.Failure;
                Assert.AreEqual(status, Tree.Tick());
                Assert.AreEqual(status, subnode.Tick());
            }
        }
    }
}