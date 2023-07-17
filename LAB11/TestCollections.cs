using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10;
using System.Diagnostics;


namespace LAB11
{
    public class TestCollections
    {
        const int SIZE = 1000;
        public Stack<Test> col10 = new Stack<Test>();
        public Stack<string> col11 = new Stack<string>();
        public Dictionary<Trial, Test> col20 = new Dictionary<Trial, Test>(SIZE);
        public Dictionary<string, Test> col21 = new Dictionary<string, Test>(SIZE);

        public readonly Test FirstTest;
        public readonly Test AverageTest;
        public readonly Test LastTest;

        public TestCollections()
        {
            for (int i = 0; i < SIZE; i++)
            {
                Test test = new Test();
                do
                {
                    test.Init();
                    if (!col20.ContainsKey(test.BaseTrial)) break;
                } while (true);
                if (i == 0)
                    FirstTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                else if (i == SIZE / 2)
                    AverageTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                else if (i == SIZE - 1)
                    LastTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                col10.Push(test);
                col11.Push(test.ToString());
                col20.Add(test.BaseTrial, test);
                col21.Add(test.ToString(), test);
            }
        }
        public TestCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Test test = new Test();
                do
                {
                    test.Init();
                    if (!col21.ContainsKey(test.ToString())) break;
                } while (true);
                if (i == 0)
                    FirstTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                else if (i == Count / 2)
                    AverageTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                else if (i == Count - 1)
                    LastTest = new Test() { id = test.id, TrialName = test.TrialName, Discipline = test.Discipline, TypeTest = test.TypeTest, Duration = test.Duration, TaskNumber = test.TaskNumber };
                col10.Push(test);
                col11.Push(test.ToString());
                col20.Add(test.BaseTrial, test);
                col21.Add(test.ToString(), test);
            }
        }
        static public void SearchFirstElement(TestCollections testCollections)
        {
            bool result;
            Console.WriteLine("Поиск первого элемента:");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Первый элемент:");
            Console.WriteLine(testCollections.FirstTest.ToString());
            // Поиск в коллекции 1 <TValue>.
            sw.Start();
            result =  testCollections.col10.Contains(testCollections.FirstTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <TValue> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 1 <string>. 
            sw.Restart();
            result = testCollections.col11.Contains(testCollections.FirstTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <string> = " + sw.ElapsedTicks.ToString().Trim('0')+" Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по ключу.
            sw.Restart();
            result = testCollections.col20.ContainsKey(testCollections.FirstTest.BaseTrial);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по ключу.
            sw.Restart();
            result = testCollections.col21.ContainsKey(testCollections.FirstTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по значению.
            sw.Restart();
            result = testCollections.col20.ContainsValue(testCollections.FirstTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по значению.
            sw.Restart();
            result = testCollections.col21.ContainsValue(testCollections.FirstTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
        }
        static public void SearchAverageElement(TestCollections testCollections)
        {
            bool result;
            Console.WriteLine("Поиск среднего элемента:");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Средний элемент:");
            Console.WriteLine(testCollections.AverageTest.ToString());
            // Поиск в коллекции 1 <TValue>.
            sw.Start();
            result = testCollections.col10.Contains(testCollections.AverageTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <TValue> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 1 <string>.
            sw.Restart();
            result = testCollections.col11.Contains(testCollections.AverageTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <string> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по ключу.
            sw.Restart();
            result = testCollections.col20.ContainsKey(testCollections.AverageTest.BaseTrial);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по ключу.
            sw.Restart();
            result = testCollections.col21.ContainsKey(testCollections.AverageTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по значению.
            sw.Restart();
            result = testCollections.col20.ContainsValue(testCollections.AverageTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по значению.
            sw.Restart();
            result = testCollections.col21.ContainsValue(testCollections.AverageTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
        }
        static public void SearchLastElement(TestCollections testCollections)
        {
            bool result;
            Console.WriteLine("Поиск последнего элемента:");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Последний элемент:");
            Console.WriteLine(testCollections.LastTest.ToString());
            // Поиск в коллекции 1 <TValue>.
            sw.Start();
            result =  testCollections.col10.Contains(testCollections.LastTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <TValue> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 1 <string>.
            sw.Restart();
            result = testCollections.col11.Contains(testCollections.LastTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <string> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по ключу.
            sw.Restart();
            result = testCollections.col20.ContainsKey(testCollections.LastTest.BaseTrial);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по ключу.
            sw.Restart();
            result = testCollections.col21.ContainsKey(testCollections.LastTest.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по значению.
            sw.Restart();
            result = testCollections.col20.ContainsValue(testCollections.LastTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по значению.
            sw.Restart();
            result = testCollections.col21.ContainsValue(testCollections.LastTest);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
        }
        static public void SearchNotExistElement(TestCollections testCollections)
        {
            bool result; 
            Console.WriteLine("Поиск несуществущего элемента:");
            var sw = new Stopwatch();
            Test notExistElement = new Test();
            Console.WriteLine("Несуществующий элемент:");
            Console.WriteLine(notExistElement.ToString());
            // Поиск в коллекции 1 <TValue>.
            sw.Start();
            result = testCollections.col10.Contains(notExistElement);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <TValue> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 1 <string>.
            sw.Restart();
            result = testCollections.col11.Contains(notExistElement.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 1 <string> = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по ключу.
            sw.Restart();
            result = testCollections.col20.ContainsKey(notExistElement.BaseTrial);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по ключу.
            sw.Restart();
            result = testCollections.col21.ContainsKey(notExistElement.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по ключу = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <Tkey, TValue> по значению.
            sw.Restart();
            result = testCollections.col20.ContainsValue(notExistElement);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <Tkey, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
            // Поиск в коллекции 2 <string, TValue> по значению.
            sw.Restart();
            result = testCollections.col21.ContainsValue(notExistElement);
            sw.Stop();
            Console.WriteLine("Время поиска в коллекции 2 <string, TValue> по значению = " + sw.ElapsedTicks.ToString().Trim('0') + " Нашел: " + result);
        }
    }
}
