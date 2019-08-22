using CSharpByTopics.ExtensionMethods;
using CSharpByTopics.Async;
using CSharpByTopics.Xml;
using System;
using Microsoft.Extensions.Logging;

namespace CSharpByTopics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger<Program> _log =
            //    new Logger<Program>();

            //-------------------------
            // XML Demos
            //-------------------------

            //new SerializationDemo().Run();
            //new LinqToXmlDomDemo().Run();
            //new LinqToXmlLoadDemo().Run();
            //new LinqToXmlModiyDOMDemo().Run();

            //-------------------------
            // Extension Methods
            //-------------------------

            //new ExtensionMethodDemo().Run();

            //-------------------------
            // Threading
            //-------------------------

            //new MultipleTaskDemo().Run();
            new BlockingCodeDemo().Run();

        }
    }
}
