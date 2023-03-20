using MPewsey.BehaviorTree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes.Tests.PlayMode
{
    public class TestModuloSubnode
    {
        private BehaviourTree Tree { get; set; }

        [SetUp]
        public void SetUp()
        {
            Tree = new GameObject("Behavior Tree").AddComponent<BehaviourTree>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(Tree.gameObject);
        }

        [Test]
        public void TestTick()
        {
            Tree.AddSubnode<CounterSubnode>().SetValues("Counter");

            var subnode = Tree.AddSubnode<ModuloSubnode>().SetValues("Counter", 2, 1, ComparisonType.Equal);

            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Initialize();

            for (int i = 1; i < 1000; i++)
            {
                var status = i % subnode.Modulus == subnode.Value ? BehaviorStatus.Success : BehaviorStatus.Failure;
                Assert.AreEqual(status, Tree.Tick());
                Assert.AreEqual(status, subnode.Tick());
            }
        }
    }
}