using System;
using System.Xml;
using UtilExtensions;

namespace SeachXmlNode
{
    class SandBox
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var doc = new XmlDocument();
            doc.SeachXmlNode("my node");

        }


    }
}
