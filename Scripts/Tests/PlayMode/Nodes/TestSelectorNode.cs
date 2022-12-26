using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree
{
    public class TestSelectorNode
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
        public void TestGetBlackboard()
        {
            var node = Tree.AddChildNode<SelectorNode>("Selector Node");
            Tree.Initialize();
            Assert.AreEqual(Tree.Blackboard, node.Blackboard);
        }

        [Test]
        public void TestTickFailure()
        {
            var node = Tree.AddChildNode<SelectorNode>("Selector Node");

            node.AddChildNode<StatusNode>("Failure Node").Status = BehaviorStatus.Failure;
            node.AddChildNode<StatusNode>("Failure Node").Status = BehaviorStatus.Failure;

            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Failure, node.Tick());
        }

        [Test]
        public void TestTickSuccess()
        {
            var node = Tree.AddChildNode<SelectorNode>("Selector Node");

            node.AddChildNode<StatusNode>("Failure Node").Status = BehaviorStatus.Failure;
            node.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;

            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, node.Tick());
        }
    }
}