using MPewsey.BehaviorTree.Nodes;
using NUnit.Framework;
using UnityEngine;

namespace MPewsey.BehaviorTree.Subnodes.Tests.PlayMode
{
    public class TestComparisonSubnode
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
        public void TestEqualsTick()
        {
            var blackboardValue = 100;
            var value = 100;
            var comparisonType = ComparisonType.Equals;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestEqualsFailsTick()
        {
            var blackboardValue = 200;
            var value = 100;
            var comparisonType = ComparisonType.Equals;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Failure, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Failure, Tree.Tick());
        }

        [Test]
        public void TestNotEqualTick()
        {
            var blackboardValue = 200;
            var value = 100;
            var comparisonType = ComparisonType.NotEqual;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestLessThanTick()
        {
            var blackboardValue = 25;
            var value = 100;
            var comparisonType = ComparisonType.LessThan;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestLessThanOrEqualTick()
        {
            var blackboardValue = 25;
            var value = 100;
            var comparisonType = ComparisonType.LessThanOrEqual;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestLessThanOrEqualAreEqualTick()
        {
            var blackboardValue = 100;
            var value = 100;
            var comparisonType = ComparisonType.LessThanOrEqual;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestGreaterThanTick()
        {
            var blackboardValue = 100;
            var value = 25;
            var comparisonType = ComparisonType.GreaterThan;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestGreaterThanOrEqualTick()
        {
            var blackboardValue = 100;
            var value = 25;
            var comparisonType = ComparisonType.GreaterThanOrEqual;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }

        [Test]
        public void TestGreaterThanOrEqualAreEqualTick()
        {
            var blackboardValue = 100;
            var value = 100;
            var comparisonType = ComparisonType.GreaterThanOrEqual;

            var comparison = Tree.AddSubnode<ComparisonSubnodeInt>().SetValues("Test", comparisonType, value);
            Tree.AddChildNode<StatusNode>("Success Node").SetValues(BehaviorStatus.Success);
            Tree.Blackboard.SetValue("Test", blackboardValue);
            Tree.Initialize();

            Assert.AreEqual(BehaviorStatus.Success, comparison.Tick());
            Assert.AreEqual(BehaviorStatus.Success, Tree.Tick());
        }
    }
}