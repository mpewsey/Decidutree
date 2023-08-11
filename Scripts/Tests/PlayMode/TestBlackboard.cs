using NUnit.Framework;

namespace MPewsey.Decidutree.Tests.PlayMode
{
    public class TestBlackboard
    {
        [Test]
        public void TestSetAndGetValue()
        {
            var blackboard = new Blackboard();
            var key = "Test Key";
            var entry = blackboard.SetValue(key, 100);
            Assert.AreEqual(100, entry.Value);
            blackboard.SetValue(key, 200);
            Assert.AreEqual(200, entry.Value);
            Assert.AreEqual(entry, blackboard.GetValue<int>(key));
        }

        [Test]
        public void TestEnsureSetValue()
        {
            var blackboard = new Blackboard();
            var key = "Test Key";
            var entry1 = blackboard.EnsureSetValue(key, 100);
            var entry2 = blackboard.EnsureSetValue(key, 200);
            Assert.AreEqual(entry1, entry2);
            Assert.AreEqual(100, entry1.Value);
        }

        [Test]
        public void TestBlackboardEntryToString()
        {
            var entry = new BlackboardEntry<int>("Test Key") { Value = 100 };
            Assert.AreEqual($"BlackboardEntry<{typeof(int)}>(Key = Test Key, Value = 100)", entry.ToString());
        }

        [Test]
        public void TestNullKeyThrowsException()
        {
            var blackboard = new Blackboard();
            Assert.Throws<System.ArgumentException>(() => blackboard.SetValue(null, 1));
        }

        [Test]
        public void TestEmptyStringThrowsException()
        {
            var blackboard = new Blackboard();
            Assert.Throws<System.ArgumentException>(() => blackboard.SetValue("", 1));
        }
    }
}