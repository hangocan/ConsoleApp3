using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramChallenge;

namespace TestTask
{
    [TestClass]
    public class UnitTest
    {
        string startPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        [TestMethod]
        public void TestMethod1()
        {
            //XML Generator test

            string loadPath = startPath + "\\testnumber.txt";
            string savePath = startPath + @"\test.xml";

            List<NumberPair> ls = new List<NumberPair> { };
            ls = Tasks.ReadConvert(loadPath);
            string[] result = ls.Select(x => x.Hexadecimal).ToArray();
            string[] predict = { "A", "14", "1E", "28", "32", "3C", "46", "50", "5A" };
            CollectionAssert.AreEqual(result, predict);
            Tasks.XMLGenerator(startPath, loadPath, savePath);


        }
        [TestMethod]
        public void TaskMethod2()
        {
            //CSV Generator test
            string loadPath = startPath + @"\test.xml";
            string savePath = startPath + @"\test.csv";
            Tasks.CSVGenerator(startPath, loadPath, savePath);

        }
    }
}
