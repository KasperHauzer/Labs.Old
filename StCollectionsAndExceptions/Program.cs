using System;
using Hierarchy;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

namespace StCollectionsAndExceptions
{
    static class Program
    {
        static Stopwatch stopwatch = new Stopwatch();

        static void Main()
        {
            //int size = 100;
            //TestCollection collection = new TestCollection(size);
            //Student unreal = Student.Generate();

            //string countingForfirst = "";
            //string countingForSecond = "";
            //string countingForThird = "";
            //string countingForFourth = "";
            //string countingForFifth = "";

            ////
            //countingForfirst += CountingForList(collection.keys, collection.keys[0]) + " ";
            //countingForfirst += CountingForList(collection.keys, collection.keys[size / 2]) + " ";
            //countingForfirst += CountingForList(collection.keys, collection.keys[size - 1]) + " ";
            //countingForfirst += CountingForList(collection.keys, unreal.GetBase);

            ////
            //countingForSecond += CountingForList(collection.stringKeys, collection.stringKeys[0]) + " ";
            //countingForSecond += CountingForList(collection.stringKeys, collection.stringKeys[size / 2]) + " ";
            //countingForSecond += CountingForList(collection.stringKeys, collection.stringKeys[size - 1]) + " ";
            //countingForSecond += CountingForList(collection.stringKeys, unreal.ToString());

            ////
            //countingForThird += CountingForDic(collection.dictionary, collection.keys[0]) + " ";
            //countingForThird += CountingForDic(collection.dictionary, collection.keys[size / 2]) + " ";
            //countingForThird += CountingForDic(collection.dictionary, collection.keys[size - 1]) + " ";
            //countingForThird += CountingForDic(collection.dictionary, unreal.GetBase);

            ////
            //countingForFourth += CountingForDic(collection.stringDictionary, collection.stringKeys[0]) + " ";
            //countingForFourth += CountingForDic(collection.stringDictionary, collection.stringKeys[size / 2]) + " ";
            //countingForFourth += CountingForDic(collection.stringDictionary, collection.stringKeys[size - 1]) + " ";
            //countingForFourth += CountingForDic(collection.stringDictionary, unreal.GetBase.ToString());

            ////
            //countingForFifth += CountingForDic(collection.dictionary, collection.baseArray[0]) + " ";
            //countingForFifth += CountingForDic(collection.dictionary, collection.baseArray[size / 2]) + " ";
            //countingForFifth += CountingForDic(collection.dictionary, collection.baseArray[size - 1]) + " ";
            //countingForFifth += CountingForDic(collection.dictionary, unreal);

            //Console.WriteLine(countingForfirst);
            //Console.WriteLine(countingForSecond);
            //Console.WriteLine(countingForThird);
            //Console.WriteLine(countingForFourth);
            //Console.WriteLine(countingForFifth);

            //try {
            //    collection.Prun(-19);
            //} catch (IndexOutOfRangeException) {
            //    Console.WriteLine("Было поймано исключение IndexOutOfRangeException");
            //} catch (BaseArrayIsEmptyException) {
            //    Console.WriteLine("Было поймано исключение BaseArrayIsEmptyException");
            //}

            //try {
            //    collection.baseArray = null;
            //    collection.Prun(1);
            //} catch (IndexOutOfRangeException) {
            //    Console.WriteLine("Было поймано исключение IndexOutOfRangeException");
            //} catch (BaseArrayIsEmptyException) {
            //    Console.WriteLine("Было поймано исключение BaseArrayIsEmptyException");
            //}

            //try {
            //    collection.Prun(1);
            //} catch (BaseArrayIsEmptyException) {
            //    Console.WriteLine("Было поймано исключение BaseArrayIsEmptyException");
            //} finally {
            //    Console.WriteLine("Сейчас сработал оператор \"finally\"");
            //}

            TestCollection a = new TestCollection(5);
            a.Print(); Console.WriteLine();

            a.Add(new Student());
            a.Print(); Console.WriteLine();

            a.RemoveAt(4);
            a.Print(); Console.WriteLine();
        }

        static string CountingForList(IList list, Object key)
        {
            stopwatch.Restart();
            bool flag = list.Contains(key);
            stopwatch.Stop();
            Console.WriteLine(flag);

            return stopwatch.ElapsedTicks.ToString();
        }
    
        static string CountingForDic(Dictionary<Person, Student> dic, Person key)
        {
            stopwatch.Restart();
            bool flag = dic.ContainsKey(key);
            stopwatch.Stop();
            Console.WriteLine(flag);

            return stopwatch.ElapsedTicks.ToString();
        }

        static string CountingForDic(Dictionary<String, Student> dic, String key)
        {
            stopwatch.Restart();
            bool flag = dic.ContainsKey(key);
            stopwatch.Stop();
            Console.WriteLine(flag);

            return stopwatch.ElapsedTicks.ToString();
        }
    
        static string CountingForDic(Dictionary<Person, Student> dic, Student key)
        {
            stopwatch.Restart();
            bool flag = dic.ContainsValue(key);
            stopwatch.Stop();
            Console.WriteLine(flag);

            return stopwatch.ElapsedTicks.ToString();
        }
    
        static void Print(this TestCollection collection)
        {
            foreach (Student i in collection.baseArray)
                Console.WriteLine(i);
        }
    }
}
