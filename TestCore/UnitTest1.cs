using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SampleApp;

namespace TestCore
{
    public class Tests
    {
        private ProgramForTest _programForTest;
        [SetUp]
        public void Setup()
        {
           _programForTest = new ProgramForTest();
        }

        [Test]
        public void Test1()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\CAAdmin\source\repos\SampleApp\TestCore\TestCaseSource.xml");

            var items = new List<int>();
            int index = 0, balance = 0, noOfItems = 0;

            noOfItems = Int32.Parse(xmlDoc.SelectSingleNode("//testcases/case/ItemsCount").InnerText);
            XmlNode node = xmlDoc.SelectSingleNode("//testcases/case/Items");
            foreach (XmlNode childNode in node.ChildNodes)
                items.Add(Int32.Parse(childNode.InnerText));
            index = Int32.Parse(xmlDoc.SelectSingleNode("//testcases/case/Index").InnerText);
            balance = Int32.Parse(xmlDoc.SelectSingleNode("//testcases/case/Balance").InnerText);
            var expectedOutput = xmlDoc.SelectSingleNode("//testcases/case/ExpectedOutput").InnerText;
            StringWriter sb = new StringWriter();
            Console.SetOut(sb);
            _programForTest.bonAppetit(items, index, balance);

            Assert.AreEqual(expectedOutput, sb.ToString().Trim());
        }
    }
}