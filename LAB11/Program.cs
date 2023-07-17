using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10;
using System.Diagnostics;

namespace LAB11
{
    public class Program
    {
        static int MAX_DURATION = 300; // Максимальная длительность испытания.
        static int MIN_DURATION = 1; // Минимальная длительность испытания.
        static int MAX_TASKNUMBER = 60; // Максимальное число заданий в испытании.
        static int MIN_TASKNUMBER = 1; // Минимальное число заданий в испытании.
        static int MAX_GRADUATIONYEAR = 2022; // Максимальный год выпуска.
        static int MIN_GRADUATIONYEAR = 2012; // Минимальный год выпуска.
        static Random rnd = new Random();
        #region Методы для hashtable.
        /// <summary>
        /// Печать главного меню.
        /// </summary>
        static void PrintMainMenuHashTable()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить объект в хеш-таблицу.");
            Console.WriteLine("2. Удалить объект из хеш-таблицы.");
            Console.WriteLine("3. Узнать количество элементов типа Test в хеш-таблице.");
            Console.WriteLine("4. Печать элементов типа Exam.");
            Console.WriteLine("5. Печать элементов типа FinalExam.");
            Console.WriteLine("6. Печать хеш-таблицы.");
            Console.WriteLine("7. Клонировать хеш-таблицу.");
            Console.WriteLine("8. Сортировка хеш-таблицу.");
            Console.WriteLine("9. Поиск заданного элемента в хеш-таблице.");
            Console.WriteLine("10. Выход.");
        }
        /// <summary>
        ///  Печать меню при добавление объекта в хеш-таблицу.
        /// </summary>
        static void PrintAddMenuHashTable()
        {
            Console.WriteLine("Объект какого класса вы хотите добавить:");
            Console.WriteLine("1. Trial.");
            Console.WriteLine("2. Test.");
            Console.WriteLine("3. Exam.");
            Console.WriteLine("4. FinalExam.");
        }
        /// <summary>
        /// Печать меню поиска в хеш-таблице.
        /// </summary>
        static void PrintSearchMenu()
        {
            Console.WriteLine("Объект какого класса вы хотите найти:");
            Console.WriteLine("1. Trial.");
            Console.WriteLine("2. Test.");
            Console.WriteLine("3. Exam.");
            Console.WriteLine("4. FinalExam.");
        }
        /// <summary>
        /// Печать меню удаления объектов из хеш-таблицы.
        /// </summary>
        static void PrintDeleteMenuHashTable()
        {
            Console.WriteLine("Выберите что удалить:");
            Console.WriteLine("1. Объект по ключу.");
            Console.WriteLine("2. Все объекты");
        }
        /// <summary>
        /// Печать хеш-таблицы.
        /// </summary>
        /// <param name="hashtable"></param>
        static void PrintHashTable(Hashtable hashtable)
        {
            foreach (DictionaryEntry item in hashtable)
                Console.WriteLine("Key = " + item.Key + "; Value = " + item.Value);
            Console.WriteLine();
        }
        /// <summary>
        /// Печать отсортированной хеш-таблицы по ключам.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица.</param>
        static void PrintSortedHashTable(Hashtable hashtable)
        {
            SortedDictionary<int, Trial> sortedHashTable = new SortedDictionary<int, Trial>();
            foreach (DictionaryEntry dt in hashtable)
                sortedHashTable.Add((int)dt.Key, (Trial)dt.Value);
            foreach (KeyValuePair<int, Trial> item in sortedHashTable)
                Console.WriteLine("Key = " + item.Key + "; Value = " + item.Value);
        }

        /// <summary>
        /// Проверка хеш-таблицы на сущесоствование ключей.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица.</param>
        /// <returns></returns>
        public static bool CheckExistHashTable(Hashtable hashtable)
        {
            if (hashtable.Count == 0) return false;
            return true;
        }
        /// <summary>
        /// Ввод непустой строки.
        /// </summary>
        /// <returns></returns>
        static string InputLine()
        {
            do
            {
                string s = Console.ReadLine().Trim();
                if (s.Length != 0)
                    return s;
                Console.WriteLine("Вы ничего не ввели!");
            } while (true);      
        }
        /// <summary>
        /// Создать объект Trial.
        /// </summary>
        /// <param name="key">Ключ для id номера.</param>
        /// <returns></returns>
        public static Trial CreateTrial(int key = int.MaxValue)
        {
            int id = UI.Input(1, key, "Введите id номер испытания (Положительное число):");
            Console.WriteLine("Введите название испытания:");
            string trialName = InputLine();
            Console.WriteLine("Введите дисциплину испытания:");
            string discipline = InputLine();
            int duration = UI.Input(MIN_DURATION, MAX_DURATION, $"Введите длительность испытания (от {MIN_DURATION} до {MAX_DURATION}):");
            int taskNumber = UI.Input(MIN_TASKNUMBER, MAX_TASKNUMBER, $"Введите количество заданий в испытании (от {MIN_TASKNUMBER} до {MAX_TASKNUMBER}):");
            return new Trial() { id = new IdNumber(id), TrialName = trialName, Discipline = discipline, Duration = duration, TaskNumber = taskNumber };
        }
        /// <summary>
        /// Создать объект Test.
        /// </summary>
        /// <param name="key">Ключ для id номера.</param>
        /// <returns></returns>
        static Test CreateTest(int key = int.MaxValue)
        {
            int id = UI.Input(1, key, "Введите id номер испытания (Положительное число):");
            Console.WriteLine("Введите название испытания:");
            string trialName = InputLine();
            Console.WriteLine("Введите дисциплину испытания:");
            string discipline = InputLine();
            Console.WriteLine("Введите тип теста:");
            string typeTest = InputLine();
            int duration = UI.Input(MIN_DURATION, MAX_DURATION, $"Введите длительность испытания (от {MIN_DURATION} до {MAX_DURATION}):");
            int taskNumber = UI.Input(MIN_TASKNUMBER, MAX_TASKNUMBER, $"Введите количество заданий в испытании (от {MIN_TASKNUMBER} до {MAX_TASKNUMBER}):");
            return new Test() { id = new IdNumber(id), TrialName = trialName, Discipline = discipline, TypeTest = typeTest, Duration = duration, TaskNumber = taskNumber };
        }
        /// <summary>
        /// Создать объект Exam.
        /// </summary>
        /// <param name="key">Ключ для id номера.</param>
        /// <returns></returns>
        static Exam CreateExam(int key = int.MaxValue)
        {
            int id = UI.Input(1, key, "Введите id номер испытания (Положительное число):");
            Console.WriteLine("Введите название испытания:");
            string trialName = InputLine();
            Console.WriteLine("Введите дисциплину испытания:");
            string discipline = InputLine();
            Console.WriteLine("Введите тип экзамена:");
            string typeExam = InputLine();
            int duration = UI.Input(MIN_DURATION, MAX_DURATION, $"Введите длительность испытания (от {MIN_DURATION} до {MAX_DURATION}):");
            int taskNumber = UI.Input(MIN_TASKNUMBER, MAX_TASKNUMBER, $"Введите количество заданий в испытании (от {MIN_TASKNUMBER} до {MAX_TASKNUMBER}):");
            return new Exam() { id = new IdNumber(id), TrialName = trialName, Discipline = discipline, TypeExam = typeExam, Duration = duration, TaskNumber = taskNumber };
        }
        /// <summary>
        /// Создать объект FinalExam.
        /// </summary>
        /// <param name="key">Ключ для id номера.</param>
        /// <returns></returns>
        static FinalExam CreateFinalExam(int key = int.MaxValue)
        {
            int id = UI.Input(1, key, "Введите id номер испытания (Положительное число):");
            Console.WriteLine("Введите название испытания:");
            string trialName = InputLine();
            Console.WriteLine("Введите дисциплину испытания:");
            string discipline = InputLine();
            Console.WriteLine("Введите тип экзамена:");
            string typeExam = InputLine();
            int duration = UI.Input(MIN_DURATION, MAX_DURATION, $"Введите длительность испытания (от {MIN_DURATION} до {MAX_DURATION}):");
            int taskNumber = UI.Input(MIN_TASKNUMBER, MAX_TASKNUMBER, $"Введите количество заданий в испытании (от {MIN_TASKNUMBER} до {MAX_TASKNUMBER}):");
            int graduationYear = UI.Input(MIN_GRADUATIONYEAR, MAX_GRADUATIONYEAR, $"Введите год выпуска (от {MIN_GRADUATIONYEAR} до {MAX_GRADUATIONYEAR}):");
            return new FinalExam() { id = new IdNumber(id), TrialName = trialName, Discipline = discipline, TypeExam = typeExam, Duration = duration, TaskNumber = taskNumber, GraduationYear = graduationYear };
        }
        /// <summary>
        /// Глубокое копирование
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Hashtable GetDeepClone(Hashtable hashtable)
        {
            Hashtable hashtableDeepClone = new Hashtable();
            foreach (DictionaryEntry item in hashtable)
            {
                if (item.Value.GetType() == typeof(Trial))        
                    hashtableDeepClone.Add(item.Key, ((Trial)item.Value).Clone());
                else if (item.Value.GetType() == typeof(Test))
                    hashtableDeepClone.Add(item.Key, ((Test)item.Value).Clone());
                else if (item.Value.GetType() == typeof(Exam))
                    hashtableDeepClone.Add(item.Key, ((Exam)item.Value).Clone());
                else if (item.Value.GetType() == typeof(FinalExam))
                    hashtableDeepClone.Add(item.Key, ((FinalExam)item.Value).Clone());
            }
            return hashtableDeepClone;
        }
        /// <summary>
        /// Подсчет количества элементов класса Test в хеш-таблице.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица</param>
        /// <returns></returns>
        public static int GetCountTest(Hashtable hashtable)
        {
            int countTest = 0;
            foreach (DictionaryEntry item in hashtable)
                if (item.Value is Test)
                    countTest++;
            return countTest;
        }
        /// <summary>
        /// Печать элементов класса Exam из хеш-таблицы.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица</param>
        static void PrintExamElement(Hashtable hashtable)
        {
            bool examExist = false;
            foreach (DictionaryEntry item in hashtable)
                if (item.Value.GetType() == typeof(Exam))
                {
                    Console.WriteLine("Key = " + item.Key + "; Value = " + item.Value);
                    examExist = true;
                }
            if (!examExist)
                Console.WriteLine("В очереди нет объектов класса Exam!");
        }
        /// <summary>
        /// Печать элементов класса FinalExam из хеш-таблицы.
        /// </summary>
        /// <param name="hashtable">Хеш-таблицы</param>
        static void PrintFinalExamElement(Hashtable hashtable)
        {
            bool finalExamEsixt = false;
            foreach (DictionaryEntry item in hashtable)
                if (item.Value is FinalExam)
                {
                    Console.WriteLine("Key = " + item.Key + "; Value = " + item.Value);
                    finalExamEsixt = true;
                }
            if (!finalExamEsixt)
                Console.WriteLine("В очереди нет объектов класса FinalExam!");
        }
        /// <summary>
        /// Удаление элемента по ключу из хеш-таблицы.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица.</param>
        /// <param name="keyRemove">Ключ, который удаляем.</param>
        public static void DeleteKeyHashTable(Hashtable hashtable, int keyRemove)
        {
            if (hashtable.ContainsKey(keyRemove)) // Если содержит веденный ключ. 
            {
                hashtable.Remove(keyRemove);
                Console.WriteLine("Удален элемент с ключом:" + keyRemove);
                if (hashtable.Count == 0)
                    Console.WriteLine("Хеш-таблица стала пустой!");
            }
            else // Если не содержит введеный ключ.
                Console.WriteLine("Не существует элемента с введенным ключом!");
        }
        /// <summary>
        /// Печать примера глоубого копирования
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="hashtable">Хеш-таблица.</param>
        static void PrintExampleDeepCopyHashTable(int key, Hashtable hashtable)
        {
            Console.WriteLine("Глубокое копирование");
            Trial t = new Trial();
            hashtable.Add(key, t);
            Console.WriteLine("Добавим новый элемент в коллекцию");
            Hashtable hashtableClone = GetDeepClone(hashtable);
            Console.WriteLine("Оригинал:");
            PrintHashTable(hashtable);
            Console.WriteLine("Копия:");
            PrintHashTable(hashtableClone);
            Console.WriteLine();
            Console.WriteLine("Поменяем название в добавленном элементе");
            t.Discipline = "Поменяли название";
            Console.WriteLine("Оригинал:");
            PrintHashTable(hashtable);
            Console.WriteLine("Копия:");
            PrintHashTable(hashtableClone);
            hashtable.Remove(key);
        }
        /// <summary>
        /// Печать примера поверхностного копирования
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="hashtable">Хеш-таблица.</param>
        static void PrintExampleShallowCopyHashTable(int key, Hashtable hashtable)
        {
            Console.WriteLine("Поверхностное копирование:");
            Console.WriteLine("Добавим новый элемент в коллекцию.");
            Trial trialNew = new Trial()
            {
                id = new IdNumber(key),
                TrialName = "Элемент для копирования",
                Discipline = "Копирование",
                Duration = 1,
                TaskNumber = 1
            };
            hashtable.Add(key, trialNew);
            key++;
            Hashtable hashtableClone = (Hashtable)hashtable.Clone();
            Console.WriteLine("Склонировали коллекцию");
            Console.WriteLine("Распечатаем оригинал и копию");
            Console.WriteLine("Оригинал:");
            PrintHashTable(hashtable);
            Console.WriteLine("Копия");
            PrintHashTable(hashtableClone);
            Console.WriteLine("Изменим уже существующий элемент в коллекции.");
            trialNew.TrialName = "Изменили название элемента для копирования";
            Console.WriteLine("Добавим еще один элемент в коллекцию.");
            Test testNew = new Test()
            {
                id = new IdNumber(key),
                TrialName = "Новый элемент, который не скопировали",
                Discipline = "Новое копирование",
                TypeTest = "Копирование",
                Duration = 1,
                TaskNumber = 2
            };
            hashtable.Add(key, testNew);
            Console.WriteLine("Распечатаем оригинал и копию");
            Console.WriteLine("Оригинал:");
            PrintHashTable(hashtable);
            Console.WriteLine("Копия");
            PrintHashTable(hashtableClone);
            hashtable.Remove(key);
            hashtable.Remove(key - 1);
        }
        #endregion Методы для hashtable.
        #region Методы для queue.
        /// <summary>
        /// Печать главного меню.
        /// </summary>
        static void PrintMainMenuQueue()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить объект в очередь.");
            Console.WriteLine("2. Удалить объект из очереди.");
            Console.WriteLine("3. Узнать количество элементов типа Test в очереди.");
            Console.WriteLine("4. Печать элементов типа Exam.");
            Console.WriteLine("5. Печать элементов типа FinalExam.");
            Console.WriteLine("6. Печать очереди.");
            Console.WriteLine("7. Клонировать очередь.");
            Console.WriteLine("8. Сортировка очереди.");
            Console.WriteLine("9. Поиск заданного элемента в очереди.");
            Console.WriteLine("10. Выход.");
        }
        /// <summary>
        ///  Печать меню при добавление объекта в очередь.
        /// </summary>
        static void PrintAddMenuQueue()
        {
            Console.WriteLine("Объект какого класса вы хотите добавить:");
            Console.WriteLine("1. Trial.");
            Console.WriteLine("2. Test.");
            Console.WriteLine("3. Exam.");
            Console.WriteLine("4. FinalExam.");
        }
        /// <summary>
        ///  Печать меню при удаление объекта из очереди.
        /// </summary>
        static void PrintDeleteMenuQueueOneObj()
        {
            Console.WriteLine("Объект какого класса вы хотите удалить:");
            Console.WriteLine("1. Trial.");
            Console.WriteLine("2. Test.");
            Console.WriteLine("3. Exam.");
            Console.WriteLine("4. FinalExam.");
        }
        /// <summary>
        /// Печать меню удаления объектов из очереди.
        /// </summary>
        static void PrintDeleteMenuQueue()
        {
            Console.WriteLine("Выберите что удалить:");
            Console.WriteLine("1. Один объект.");
            Console.WriteLine("2. Все объекты");
        }
        /// <summary>
        /// Проверка queue на пустоту.
        /// </summary>
        /// <param name="hashtable">Хеш-таблица.</param>
        /// <returns></returns>
        public static bool CheckExistQueue(Queue<Trial> queue)
        {
            if (queue.Count == 0) return false;
            return true;
        }
        /// <summary>
        /// Печать очереди.
        /// </summary>
        /// <param name="queue">Очередь.</param>
        static void PrintQueue(Queue<Trial> queue)
        {
            foreach (Trial trial in queue)
                Console.WriteLine(trial);
        }
        /// <summary>
        /// Сортировка очередеи.
        /// </summary>
        /// <param name="queue">Очередь.</param>
        /// <returns></returns>
        public static Queue<Trial> GetSortedQueue(Queue<Trial> queue)
        {
            Queue<Trial> sortedQueue = new Queue<Trial>();
            Trial[]  sortetQueueArray = queue.ToArray();
            for (int i = 0; i < sortetQueueArray.Length - 1; i++)
                for (int j = i + 1; j < sortetQueueArray.Length; j++)
                    if (sortetQueueArray[i].id.number > sortetQueueArray[j].id.number)
                    {
                        Trial temp = sortetQueueArray[i];
                        sortetQueueArray[i] = sortetQueueArray[j];
                        sortetQueueArray[j] = temp;
                    }
            foreach (Trial trial in sortetQueueArray)
                sortedQueue.Enqueue(trial);
            return sortedQueue;
        }
        /// <summary>
        /// Подсчет количества элементов класса Test в очереди.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        /// <returns></returns>
        public static int GetCountTest(Queue<Trial> trials)
        {
            int countTest = 0;
            foreach (Trial item in trials)
                if (item.GetType() == typeof(Test))
                    countTest++;
            return countTest;
        }
        /// <summary>
        /// Печать элементов класса Exam из хеш-таблицы.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        static void PrintExamElement(Queue<Trial> trials)
        {
            Console.WriteLine("Печать элементов типа Exam:");
            bool examExist = false;
            foreach (Trial item in trials)
                if (item.GetType() == typeof(Exam))
                {
                    Console.WriteLine(item);
                    examExist = true;
                }
            if (!examExist)
                Console.WriteLine("В очереди нет обхектов типа Exam!");
        }
        /// <summary>
        /// Печать элементов класса FinalExam из хеш-таблицы.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        static void PrintFinalExamElement(Queue<Trial> trials)
        {
            Console.WriteLine("Печать элементов типа FinalExam:");
            bool finalExamExist = false;
            foreach (Trial item in trials)
                if (item.GetType() == typeof(FinalExam))
                {
                    Console.WriteLine(item);
                    finalExamExist = true;
                }
            if (!finalExamExist)
                Console.WriteLine("В очереди нет обхектов типа FinalExam!");
        }
        /// <summary>
        /// Печать примера поверхностного копирования очереди.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        static void PrintExampleShallowCopy(ref Queue<Trial> trials)
        {
            Console.WriteLine("Поверхностное копирование");
            Console.WriteLine("Добавим новый элемент в коллекцию.");
            Trial trialNew = new Trial()
            {
                id = new IdNumber(rnd.Next()),
                TrialName = "Элемент для копирования",
                Discipline = "Копирование",
                Duration = 1,
                TaskNumber = 1
            };
            trials.Enqueue(trialNew);
            Queue<Trial> queueClone = new Queue<Trial>();
            foreach (Trial item in trials)
                queueClone.Enqueue(item);
            Console.WriteLine("Склонировали коллекцию");
            Console.WriteLine("Распечатаем оригинал и копию");
            Console.WriteLine();
            Console.WriteLine("Оригинал:");
            PrintQueue(trials);
            Console.WriteLine("Копия");
            PrintQueue(queueClone);
            Console.WriteLine();
            Console.WriteLine("Изменим уже существующий элемент в коллекции.");
            trialNew.TrialName = "Изменили название элемента для копирования";
            Console.WriteLine("Добавим еще один элемент в коллекцию.");
            Test testNew = new Test()
            {
                id = new IdNumber(rnd.Next()),
                TrialName = "Новый элемент, который не скопировали",
                Discipline = "Новое копирование",
                TypeTest = "Копирование",
                Duration = 1,
                TaskNumber = 2
            };
            trials.Enqueue(testNew);
            Console.WriteLine("Распечатаем оригинал и копию");
            Console.WriteLine();
            Console.WriteLine("Оригинал:");
            PrintQueue(trials);
            Console.WriteLine("Копия");
            PrintQueue(queueClone);
            trials = DeleteLastElementQueue(trials, 2);
            Console.WriteLine();
        }
        /// <summary>
        /// Глубокое копирование очереди.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        /// <returns></returns>
        public static Queue<Trial> GetDeepClone(Queue<Trial> trials)
        {
            Queue<Trial> trialsClone = new Queue<Trial>();
            foreach (Trial item in trials)
            {
                if (item.GetType() == typeof(Trial))
                    trialsClone.Enqueue((Trial)(item).Clone());
                else if (item.GetType() == typeof(Test))
                    trialsClone.Enqueue((Test)(item).Clone());
                else if (item.GetType() == typeof(FinalExam))
                    trialsClone.Enqueue((FinalExam)(item).Clone());
                else if (item.GetType() == typeof(Exam))
                    trialsClone.Enqueue((Exam)(item).Clone());
                
            }
            return trialsClone;
        }
        /// <summary>
        /// Печать примера глубого копирования очереди.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        static void PrintDeepCopyExample(ref Queue<Trial> trials)
        {
            Console.WriteLine("Глубокое копирование");
            Trial t = new Trial();
            trials.Enqueue(t);
            Console.WriteLine("Добавим новый элемент в коллекцию");
            Queue<Trial> trialsClone = GetDeepClone(trials);
            Console.WriteLine("Оригинал:");
            PrintQueue(trials);
            Console.WriteLine("Копия:");
            PrintQueue(trialsClone);
            Console.WriteLine();
            Console.WriteLine("Поменяем название в добавленном элементе");
            t.Discipline = "Поменяли название";
            Console.WriteLine("Оригинал:");
            PrintQueue(trials);
            Console.WriteLine("Копия:");
            PrintQueue(trialsClone);
            trials = DeleteLastElementQueue(trials, 1);
            Console.WriteLine();
        }
        /// <summary>
        /// Удалить последние элементы из очереди.
        /// </summary>
        /// <param name="trials">Очередь.</param>
        /// <param name="countDelete">Количество удаляемых из конца очереди элементов.</param>
        /// <returns></returns>
        public static Queue<Trial> DeleteLastElementQueue(Queue<Trial> trials, int countDelete)
        {
            Queue<Trial> trialsHelpQueue = new Queue<Trial>();
            int len = trials.Count - countDelete;
            for (int i = 0; i < len; i++)
                trialsHelpQueue.Enqueue(trials.Dequeue());
            return trialsHelpQueue;
        }
        #endregion
        #region Методы для коллекций
        /// <summary>
        /// Добавление элемента в коллекции.
        /// </summary>
        /// <param name="testCollections">Коллекции.</param>
        /// <param name="addElement">Добавляемый элемент.</param>
        public static void AddElementCollections(TestCollections testCollections, Test addElement)
        {
            if (testCollections.col21.ContainsKey(addElement.ToString()))
                Console.WriteLine("Такой объект уже есть в коллекции!");
            else
            {
                testCollections.col10.Push(addElement);
                testCollections.col11.Push(addElement.ToString());
                testCollections.col20.Add(addElement.BaseTrial, addElement);
                testCollections.col21.Add(addElement.ToString(), addElement);
                Console.WriteLine("Добавили элемент:");
                addElement.VirtualShow();
            }
        }
        /// <summary>
        /// Удаление элемента из коллекций.
        /// </summary>
        /// <param name="testCollections">Коллекции.</param>
        /// <param name="deleteTest">Удаляемый элемент.</param>
        public static void DeleteElementCollections(TestCollections testCollections, Test deleteTest)
        {
            if (!testCollections.col21.ContainsKey(deleteTest.ToString()))
                Console.WriteLine("Такого объекта нет в коллекции! Ничего не удалили!");
            else
            {
                testCollections.col10 = DeleteElementStack(testCollections.col10, deleteTest);
                testCollections.col11 = DeleteElementStack(testCollections.col11, deleteTest);
                testCollections.col20.Remove(deleteTest.BaseTrial);
                testCollections.col21.Remove(deleteTest.ToString());
                Console.WriteLine("Удалили элемент:");
                deleteTest.VirtualShow();
            }
        }
        /// <summary>
        /// Удаление элемента из стека класса Test.
        /// </summary>
        /// <param name="stack">Стек, содержащий элементы класса Test.</param>
        /// <param name="deleteElement">Удаляемый элемент.</param>
        /// <returns></returns>
        static Stack<Test> DeleteElementStack(Stack<Test> stack, Test deleteElement)
        {
            Stack<Test> newStack = new Stack<Test>();
            int len = stack.Count;
            for (int i = 0; i < len; i++)
            {
                if (!stack.Peek().Equals(deleteElement))
                    newStack.Push(stack.Peek());
                stack.Pop();
            }
            return newStack;
        }
        /// <summary>
        /// Удаление элемента из строкового стека.
        /// </summary>
        /// <param name="stack">Стек из строк.</param>
        /// <param name="deleteElement">Элемент, который нужно удалить.</param>
        /// <returns></returns>
        static Stack<string> DeleteElementStack(Stack<string> stack, Test deleteElement)
        {
            Stack<string> newStack = new Stack<string>();
            int len = stack.Count;
            for (int i = 0; i < len; i++)
            {
                if (!stack.Peek().Equals(deleteElement.ToString()))
                    newStack.Push(stack.Peek());
                stack.Pop();
            }   
            return newStack;
        }
        /// <summary>
        /// Печать меню для коллекций.
        /// </summary>
        static void PrintTestCollectionsMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить элемент в коллекцию.");
            Console.WriteLine("2. Удалить элемент из коллекции.");
            Console.WriteLine("3. Измерить время поиска для первого, центрального, последнего элемента.");
            Console.WriteLine("4. Печать коллекции.");
            Console.WriteLine("5. Выход.");
        }
        /// <summary>
        /// Печать коллекции.
        /// </summary>
        /// <param name="testCollections">Коллекция.</param>
        static void PrintFirstCollection(TestCollections testCollections)
        {
            foreach (var item in testCollections.col10)
            {
                Console.WriteLine(item);
            }
        }
        #endregion
        //hashtable.Add(10, trial);
        //hashtable.Add(5, test1);
        //hashtable.Add(3, test2);
        //hashtable.Add(2, exam1);
        //hashtable.Add(14, finalExam1);
        static void Main(string[] args)
        {            
            #region 1 часть, hashtable.
            Hashtable hashtable = new Hashtable();
            Trial trial = new Trial() { id = new IdNumber(1), TrialName = "Контрольная работа по физике №1", Discipline = "Физика",
            Duration = 60, TaskNumber = 30 };
            Test test1 = new Test() { id = new IdNumber(2), TrialName = "Тест по истории №1", Discipline = "История", TypeTest = "Закрытый",
            Duration = 20, TaskNumber = 10 }; 
            Test test2 = new Test() { id = new IdNumber(30), TrialName = "Тест по истории №3", Discipline = "История", TypeTest = "Закрытый",
            Duration = 20, TaskNumber = 10 };
            Exam exam1 = new Exam() { id = new IdNumber(4), TrialName = "Экзамен по программировнию №1.1", Discipline = "Программирование",
            TypeExam = "Необязательный", Duration = 60, TaskNumber = 10 }; 
            FinalExam finalExam1 = new FinalExam() { id = new IdNumber(5), TrialName = "Выпускной экзамен по обществознанию", 
            Discipline = "Обществознание", TypeExam = "Обязательный", Duration = 60, TaskNumber = 10, GraduationYear = 2022 };
            int key = 1;
            hashtable.Add(key++, trial);
            hashtable.Add(key++, test1);
            hashtable.Add(key++, test2);
            hashtable.Add(key++, exam1);
            hashtable.Add(key++, finalExam1);
            int choiceMenu, addMenu , deleteMenu, searchMenu;
            string msgHashTableEmpty = "Хеш-таблица пустая!";
            do
            {
                PrintMainMenuHashTable();
                choiceMenu = UI.Input(1, 10, "Выберите пункт меню:");
                switch (choiceMenu)
                {
                    case 1: // Добавить элемент в коллекцию.
                        {
                            PrintAddMenuHashTable(); // Печать меню добавления.
                            addMenu = UI.Input(1, 4, "Выберите пункт:");
                            Trial addElement;
                            if (addMenu == 1) // Добавить Trial.
                            {
                                addElement = new Trial();
                                addElement.Init();
                            }
                            else if (addMenu == 2) // Добавить Test.
                            {
                                addElement = new Test();
                                addElement.Init(); 
                            } 
                            else if (addMenu == 3) // Добавить Exam.
                            {
                                addElement = new Exam();
                                addElement.Init();
                            } 
                            else // Добавить FinalExam.
                            {
                                addElement = new FinalExam();
                                addElement.Init();
                            }
                            addElement.id.number = key;
                            hashtable.Add(key, addElement);
                            key++;
                            Console.WriteLine("Добавлен элемент в хеш-таблицу!");
                            break;
                        }
                    case 2: // Удалить объект из коллекции.
                        {
                            PrintDeleteMenuHashTable(); // Печать меню удаления.
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                            {
                                deleteMenu = UI.Input(1, 2, "Выберите пункт:");
                                if (deleteMenu == 1) // Удалить объект по ключу.
                                {
                                    int keyRemove = UI.Input(1, int.MaxValue, "Введите ключ:");
                                    DeleteKeyHashTable(hashtable, keyRemove);
                                }
                                else // Удалить все объекты.
                                {
                                    hashtable.Clear();
                                    Console.WriteLine("Из хеш-таблицы удалены все объекты!");
                                }
                            }
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 3: // Узнать количество элементов типа Test в коллекции.
                        {
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                                Console.WriteLine("Количество элементов типа Test в коллекции = " + GetCountTest(hashtable));
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 4: // Печать элементов типа Exam.
                        {
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                                PrintExamElement(hashtable);
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 5: // Печать элементов типа FinalExam.
                        {
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                                PrintFinalExamElement(hashtable);
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 6: // Печать коллекции.
                        {
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                                PrintHashTable(hashtable);
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty); 
                            break;
                        }
                    case 7: // Клонировать коллекцию.
                        {       
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                            {
                                PrintExampleShallowCopyHashTable(key, hashtable);
                                Console.WriteLine();
                                PrintExampleDeepCopyHashTable(key, hashtable);
                            }
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 8: // Сортировка коллекции.
                        {
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                                    PrintSortedHashTable(hashtable);
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 9: // Поиск заданного элемента в коллекции.
                        {      
                            if (CheckExistHashTable(hashtable)) // Если хеш-таблица не пустая.
                            {
                                PrintSearchMenu();
                                searchMenu = UI.Input(1, 4, "Выберите пункт:");
                                Trial searchElement;
                                if (searchMenu == 1) // Создание объекта Trial.
                                    searchElement = CreateTrial(key);
                                else if (searchMenu == 2) // Создание объекта Test.
                                    searchElement = CreateTest(key);
                                else if (searchMenu == 3) // Создание объекта Exam.
                                    searchElement = CreateExam(key);
                                else // Создание объекта FinalExam.
                                    searchElement = CreateFinalExam(key);
                                Console.WriteLine("Ищем элемент:");
                                searchElement.VirtualShow();
                                if (hashtable.ContainsValue(searchElement)) // Если хеш-таблица содержит введенный элемент.
                                        Console.WriteLine("Элемент есть в коллекции!");
                                else  // Если хеш-таблица не содержит введенный элемент.
                                    Console.WriteLine("Элемент не найден");
                            }
                            else // Если хеш-таблица пустая.
                                Console.WriteLine(msgHashTableEmpty);
                            break;
                        }
                    case 10: // Выход.
                        {
                            break;
                        }
                }
            } while (choiceMenu != 10); // Пока не выход.
            #endregion 1 часть, hashtable.
            #region 2 часть, queue<T>.          
            Queue<Trial> trials = new Queue<Trial>();
            trial = new Trial() { id = new IdNumber(100), TrialName = "1", Discipline = "1", Duration = 1, TaskNumber = 1 };
            trials.Enqueue(trial);
            trials.Enqueue(test1);
            trials.Enqueue(test2);
            trials.Enqueue(exam1);
            trials.Enqueue(finalExam1);
            string msgQueueEmpty = "Очередь пустая!";
            int createDeleteObjChoice; 
            do
            {
                PrintMainMenuQueue();
                choiceMenu = UI.Input(1, 10, "Выберите пункт меню:");
                switch (choiceMenu)
                {
                    case 1: // Добавить элемент в коллекцию.
                        {
                            PrintAddMenuQueue(); // Печать меню добавления.
                            addMenu = UI.Input(1, 4, "Выберите пункт:");
                            Trial addElement;
                            if (addMenu == 1) // Добавить Trial.
                            {
                                addElement = new Trial();
                                addElement.Init();
                            }
                            else if (addMenu == 2) // Добавить Test.
                            {
                                addElement = new Test();
                                addElement.Init();
                            }
                            else if (addMenu == 3) // Добавить Exam.
                            {
                                addElement = new Exam();
                                addElement.Init();
                            }
                            else // Добавить FinalExam.
                            {
                                addElement = new FinalExam();
                                addElement.Init();
                            }
                            trials.Enqueue(addElement);
                            Console.WriteLine("Добавлен элемент в очередь!");
                            break;
                        }
                    case 2: // Удалить объект из коллекции.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                            {
                                PrintDeleteMenuQueue(); // Печать меню удаления.
                                deleteMenu = UI.Input(1, 2, "Выберите пункт:");
                                if (deleteMenu == 1) // Удалить объект.
                                {
                                    PrintDeleteMenuQueueOneObj();
                                    createDeleteObjChoice = UI.Input(1, 4, "Выберите пункт:");
                                    Trial deleteElement;
                                    if (createDeleteObjChoice == 1) // Удалить Trial.
                                        deleteElement = CreateTrial();
                                    else if (createDeleteObjChoice == 2) // Удалить Test.
                                        deleteElement = CreateTest();
                                    else if (createDeleteObjChoice == 3) // Удалить Exam.
                                        deleteElement = CreateExam();
                                    else // Удалить FinalExam.
                                        deleteElement = CreateFinalExam();
                                    if (trials.Contains(deleteElement))
                                    {
                                        Queue<Trial> trialsHelpQueue = new Queue<Trial>();
                                        int len = trials.Count;
                                        for (int i = 0; i < len; i++)
                                        {
                                            if (!trials.Peek().Equals(deleteElement))
                                                trialsHelpQueue.Enqueue(trials.Dequeue());
                                            else 
                                                trials.Dequeue();
                                        }
                                        Console.WriteLine("Из очереди удален элемент!");
                                        trials = trialsHelpQueue;
                                    }
                                    else
                                        Console.WriteLine("Введенного элемента нет в очереди. Вы ничего не удалили!");
                                }
                                else // Удалить все объекты.
                                {
                                    trials.Clear();
                                    Console.WriteLine("Из очереди удалены все объекты!");
                                }
                            }
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 3: // Узнать количество элементов типа Test в коллекции.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                                Console.WriteLine("Количество элементов типа Test в коллекции = " + GetCountTest(trials));
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 4: // Печать элементов типа Exam.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                                PrintExamElement(trials);
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 5: // Печать элементов типа FinalExam.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                                PrintFinalExamElement(trials);
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 6: // Печать коллекции.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                                PrintQueue(trials);
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 7: // Клонировать коллекцию.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                            {
                                PrintExampleShallowCopy(ref trials);
                                PrintDeepCopyExample(ref trials);
                            }
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 8: // Сортировка коллекции.
                        {
                            if (CheckExistQueue(trials)) // Если очередь не пустая.
                                PrintQueue(GetSortedQueue(trials));
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 9: // Поиск заданного элемента в коллекции.
                        {
                            if (CheckExistQueue(trials)) // Если очередь непустая.
                            {
                                PrintSearchMenu();
                                searchMenu = UI.Input(1, 4, "Выберите пункт:");
                                Trial searchElement;
                                if (searchMenu == 1) // Создание объекта Trial.
                                    searchElement = CreateTrial();
                                else if (searchMenu == 2) // Создание объекта Test.
                                    searchElement = CreateTest();
                                else if (searchMenu == 3) // Создание объекта Exam.
                                    searchElement = CreateExam();
                                else // Создание объекта FinalExam.
                                    searchElement = CreateFinalExam();
                                Console.WriteLine("Ищем элемент:");
                                searchElement.VirtualShow();
                                if (trials.Contains(searchElement)) // Если очередь содержит введенный элемент.
                                    Console.WriteLine("Элемент есть в коллекции!");
                                else  // Если очередь не содержит введенный элемент.
                                    Console.WriteLine("Элемент не найден");
                            }
                            else // Если очередь пустая.
                                Console.WriteLine(msgQueueEmpty);
                            break;
                        }
                    case 10: // Выход.
                        {
                            break;
                        }
                }
            } while (choiceMenu != 10); // Пока не выход.
            #endregion
            #region 3 часть. stack<T>, Dictionary<K,T>
            TestCollections testCollections = new TestCollections();
            int menuTestColl;
            do
            {
                PrintTestCollectionsMenu();
                menuTestColl = UI.Input(1, 5, "Выберите пункт меню:");
                switch (menuTestColl)
                {
                    case 1: // Добавить элемент в коллекцию.
                        {
                            Console.WriteLine("Введите объект, который хотите добавить:");
                            Test addTest = CreateTest();
                            AddElementCollections(testCollections, addTest);
                            break;
                        }
                    case 2: // Удалить элемент из коллекции.
                        {
                            Console.WriteLine("Введите элемент, который хотите удалить:");
                            Test deleteTest = CreateTest();
                            DeleteElementCollections(testCollections, deleteTest);
                            break;
                        }
                    case 3: // Измерить время поиска для первого, центрального, последнего элемента и элемента не находящегося в коллекции.
                        {          
                            TestCollections.SearchFirstElement(testCollections);
                            TestCollections.SearchAverageElement(testCollections);
                            TestCollections.SearchLastElement(testCollections);
                            TestCollections.SearchNotExistElement(testCollections);
                            break;
                        }
                    case 4: // Печать коллекции.
                        {
                            PrintFirstCollection(testCollections);
                            break;
                        }
                    case 5: // Выход.
                        {
                            break;
                        }
                }
            } while (menuTestColl != 5);
            #endregion
        }
    }
}