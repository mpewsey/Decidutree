using NUnit.Framework;
using System.Linq;
using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes.Tests.PlayMode
{
    public class TestRandomSelectorNode
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
            var node = Tree.AddChildNode<RandomSelectorNode>("Random Selector Node");

            node.AddChildNode<StatusNode>("Failure Node").Status = BehaviorStatus.Failure;
            node.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;

            Tree.Initialize();
            var changed = false;
            var children = node.Children.ToArray();
            Assert.AreEqual(2, children.Length);
            Random.InitState(12345);

            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
                changed = changed || !children.SequenceEqual(node.Children);
            }

            Assert.IsTrue(changed);
        }
    }
}