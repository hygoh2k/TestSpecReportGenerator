using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Xml.Linq;
using System.IO;

namespace ReportGenerator
{
    class Program
    {
        /// <summary>
        /// generate test spec based on dll and xml documentation
        /// argument expression: <dll file1>;<xml file1>,<dll file2>;<xml file2>,<dll file3>;<xml file3>...
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string expression = args[0];
            var xmlDllExpressionList = expression.Split(new char[] { ',' });
            var htmlWriter = new SimpleHtml();

            foreach (var xmlDllExpression in xmlDllExpressionList)
            {
                var items = xmlDllExpression.Split(new char[] { ';' });
                var dllFile = items[0];
                var xmlFile = items[1];



                var doc = XElement.Load(xmlFile);
                var testAssemblyName = doc.Descendants("assembly").SelectMany(x => x.Descendants("name")).FirstOrDefault().Value;
                var xmlMethods = doc.Descendants("members").SelectMany(x => x.Descendants("member")).Where(m => m.Attributes().Any(a => a.Value.StartsWith("M:"))).ToArray();
                FileInfo dllFileInfo = new FileInfo(dllFile);


                var assembly = Assembly.LoadFile(dllFileInfo.FullName);
                var testClasses = assembly.ExportedTypes;
                

                foreach (var testclass in testClasses)
                {
                    var testclassName = testclass.Name;

                    foreach (var method in testclass.GetMethods())
                    {
                        if (method.CustomAttributes == null || method.CustomAttributes.Count() == 0)
                            continue;

                        if (!method.CustomAttributes.Any(m => m.AttributeType.Name.Equals("TestMethodAttribute")))
                            continue;

                        var methodFullName = string.Format("{0}.{1}", method.DeclaringType.FullName, method.Name);

                        string summary = string.Empty;
                        foreach (var xmlMethod in xmlMethods)
                        {
                            bool foundXmlMethod = xmlMethod.Attributes().Any(x => x.Value.Equals(string.Format("M:{0}", methodFullName)));
                            if (foundXmlMethod)
                            {
                                var summaryNode = xmlMethod.Descendants("summary").FirstOrDefault();
                                if (summaryNode != null)
                                {
                                    summary = summaryNode.Value.Trim();
                                }
                                break;
                            }
                        }

                        //Console.WriteLine("{0}\t{1}", methodFullName, summary);
                        htmlWriter.AddTestMethod(assembly.GetName().Name, testclassName, methodFullName, summary);



                    }
                }
            }

            htmlWriter.Write("test_spec.html");
        }
    }
}
