using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LAB10;
using LAB11;
using System.Collections;
using System.Collections.Generic;

namespace TestLAB11
{
    [TestClass]
    public class UnitTest1
    {
        #region start test part 1
        [TestMethod]
        public void CheckDeleteExistKeyHashTable()
        {
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial();
            int key = 1;
            hashtable.Add(key++, trial);
            int old_count = hashtable.Count;
            Program.DeleteKeyHashTable(hashtable, 1);
            Assert.AreNotEqual(old_count, hashtable.Count);
        }
        [TestMethod]
        public void CheckDeleteNotExistKeyHashTable()
        {
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial();
            Test test1 = new Test();
            int key = 1;
            hashtable.Add(key++, trial);
            hashtable.Add(key++, test1);
            int old_count = hashtable.Count;
            Program.DeleteKeyHashTable(hashtable, 10);
            Assert.AreEqual(old_count, hashtable.Count);
        }
        [TestMethod]
        public void CheackGetCountTestHashTable()
        {
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial();
            Test test1 = new Test();
            int key = 1;
            hashtable.Add(key++, trial);
            hashtable.Add(key++, test1);
            Assert.AreEqual(1, Program.GetCountTest(hashtable));
        }
        [TestMethod]
        public void ChechHashTableIsEmpty_True()
        {
            Hashtable hashtable = new Hashtable();
            Assert.AreEqual(false, Program.CheckExistHashTable(hashtable));
        }
        [TestMethod]
        public void ChechHashTableIsEmpty_False()
        {
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial();
            hashtable.Add(1, trial);
            Assert.AreEqual(true, Program.CheckExistHashTable(hashtable));
        }
        [TestMethod]
        public void CheckDeepCloneHashTable()
        {
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial();
            Test t = new Test();
            Exam e = new Exam();
            FinalExam ef = new FinalExam();
            hashtable.Add(1, trial);
            hashtable.Add(2, t);
            hashtable.Add(3, e);
            hashtable.Add(4, ef);
            Hashtable hashtableDeepClone = Program.GetDeepClone(hashtable);
            trial.Duration = 10;
            Assert.AreNotEqual(trial, hashtableDeepClone[1]);
        }
        #endregion end test part 1
        #region start test part 2
        [TestMethod]
        public void ChechQueueIsEmpty_True()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Assert.AreEqual(false, Program.CheckExistQueue(queue));
        }
        [TestMethod]
        public void ChechQueueIsEmpty_False()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Trial trial = new Trial();
            queue.Enqueue(trial);
            Assert.AreEqual(true, Program.CheckExistQueue(queue));
        }
        [TestMethod]
        public void ChechSortQueue()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Trial trial = new Trial()
            {
                id = new IdNumber(30),
                TrialName = "Контрольная работа по физике №1",
                Discipline = "Физика",
                Duration = 60,
                TaskNumber = 30
            };
            Test test1 = new Test()
            {
                id = new IdNumber(2),
                TrialName = "Тест по истории №1",
                Discipline = "История",
                TypeTest = "Закрытый",
                Duration = 20,
                TaskNumber = 10
            };
            Test test2 = new Test()
            {
                id = new IdNumber(10),
                TrialName = "Тест по истории №3",
                Discipline = "История",
                TypeTest = "Закрытый",
                Duration = 20,
                TaskNumber = 10
            };
            queue.Enqueue(trial);
            queue.Enqueue(test1);
            queue.Enqueue(test2);
            Queue<Trial> sortedQueue = Program.GetSortedQueue(queue);
            Assert.AreNotEqual(queue.Peek(), sortedQueue.Peek());
        }
        [TestMethod]
        public void CheackGetCountTestQueue()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Trial trial = new Trial();
            Test test1 = new Test();
            queue.Enqueue(trial);
            queue.Enqueue(test1);
            Assert.AreEqual(1, Program.GetCountTest(queue));
        }
        [TestMethod]
        public void CheckDeepCloneQueue()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Trial trial = new Trial();
            Test t = new Test();
            Exam e = new Exam();
            FinalExam ef = new FinalExam();
            queue.Enqueue(trial);
            queue.Enqueue(t);
            queue.Enqueue(e);
            queue.Enqueue(ef);
            Queue<Trial> queueDeepClone = Program.GetDeepClone(queue);
            trial.Duration = 10;
            Assert.AreNotEqual(trial, queueDeepClone.Peek());
        }
        [TestMethod]
        public void DeleteLastElementQueue()
        {
            Queue<Trial> queue = new Queue<Trial>();
            Trial trial = new Trial();
            Test t = new Test();
            queue.Enqueue(trial);
            queue.Enqueue(t);
            queue = Program.DeleteLastElementQueue(queue, 1);
            Assert.AreEqual(1, queue.Count);
        }
        #endregion end test part 2
        #region start test part 3
        [TestMethod]
        public void CheckAddNewElement()
        {
            TestCollections testCol = new TestCollections(3);
            Test t = new Test();
            Program.AddElementCollections(testCol, t);
            Assert.AreNotEqual(3, testCol.col10.Count);
        }
        [TestMethod]
        public void CheckAddOldElement()
        {
            TestCollections testCol = new TestCollections();
            Test t = testCol.col10.Peek();
            Program.AddElementCollections(testCol, t);
            Assert.AreEqual(1000, testCol.col10.Count);
        }
        [TestMethod]
        public void CheckDeleteOldElement()
        {
            TestCollections testCol = new TestCollections(3);
            Test t = testCol.col10.Peek();
            Program.DeleteElementCollections(testCol, t);
            Assert.AreEqual(2, testCol.col10.Count);
        }
        [TestMethod]
        public void CheckDeleteNewElement()
        {
            TestCollections testCol = new TestCollections(3);
            Test t = new Test();
            Program.DeleteElementCollections(testCol, t);
            Assert.AreEqual(3, testCol.col10.Count);
        }
        #endregion end test part 3
    }
}
