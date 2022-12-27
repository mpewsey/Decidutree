using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Nodes.Tests.PlayMode
{
    public class TestSequenceNode
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
        public void TestTickSuccess()
        {
            var node = Tree.AddChildNode<SequenceNode>("Sequence Node");

            node.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;
            node.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;

            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, node.Tick());
        }

        [Test]
        public void TestTickFailure()
        {
            var node = Tree.AddChildNode<SequenceNode>("Sequence Node");

            node.AddChildNode<StatusNode>("Success Node").Status = BehaviorStatus.Success;
            node.AddChildNode<StatusNode>("Failure Node").Status = BehaviorStatus.Failure;

            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Failure, node.Tick());
        }
    }
}