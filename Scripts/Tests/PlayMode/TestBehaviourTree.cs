using MPewsey.BehaviorTree.Nodes;
using MPewsey.BehaviorTree.Subnodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Tests.PlayMode
{
    public class TestBehaviourTree
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
        public void TestAddChildNode()
        {
            var nodes = new BehaviorNode[]
            {
                Tree.AddChildNode<SequenceNode>("Sequence Node"),
                Tree.AddChildNode<SelectorNode>("Selector Node"),
            };

            Tree.Initialize();
            CollectionAssert.AreEqual(nodes, Tree.Children);
        }

        [Test]
        public void TestAddSubnode()
        {
            var nodes = new BehaviorSubnode[]
            {
                Tree.AddSubnode<CounterSubnode>().SetValues("Counter"),
            };

            Tree.Initialize();
            CollectionAssert.AreEqual(nodes, Tree.Subnodes);
        }
    }
}