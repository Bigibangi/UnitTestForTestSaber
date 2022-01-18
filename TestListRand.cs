using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SerializeTestSaber;


namespace TestListRandSaber
{
    [TestFixture]
    class TestListRand
    {

        public ListRand CreateInstance()
        {
            return new ListRand() { Count = 0 };
        }

        [Test]
        public void ListRandWithOneNode()
        {
            var listRand = CreateInstance();
            var listNode = new ListNode();
            listRand.AddNode(listNode);
            Assert.AreEqual(listRand.Head, listNode);
        }
        [Test]
        public void ListRandWithMoreThenOneNode()
        {
            var listRand = CreateInstance();
            for (int i = 0; i < 5; i++)
            {
                listRand.AddNode(new ListNode());
            }
            Assert.AreEqual(5, listRand.Count);
        }

        [Test]
        public void SerializeAndDeserializeListWithOneNode()
        {
            var listRand = new ListRand();
            var listNode = new ListNode();
            listNode.Data = "Test";
            using (var fs = new FileStream("Test\\ListRandWithOneNode.txt", FileMode.OpenOrCreate))
            {
                listRand.AddNode(listNode);
                listRand.Serialize(fs);
            }
            var otherListRand = new ListRand();
            using (var fr = new FileStream("Test\\ListRandWithOneNode.txt", FileMode.Open))
            {
                otherListRand.Deserialize(fr);
            }
            Assert.AreEqual(otherListRand.Count, 1);
            Assert.AreEqual(listRand.Head.Data, listNode.Data);
            Assert.AreEqual(listRand.Head.Data, otherListRand.Head.Data);
        }
    }
}
