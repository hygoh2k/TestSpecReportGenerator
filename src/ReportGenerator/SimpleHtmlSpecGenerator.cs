using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    /// <summary>
    /// simple html generator
    /// </summary>
    public class SimpleHtml
    {
        StringBuilder _str;
        List<Tuple<string, string, string, string>> _record;

        public SimpleHtml()
        {
            _str = new StringBuilder();
            _record = new List<Tuple<string, string, string, string>>();


            //init header
            _str.AppendLine(@"<!DOCTYPE html>
                            <html>
                            <head>
                            <style>
                            table {
                              font-family: arial, sans-serif;
                              border-collapse: collapse;
                              width: 100%;
                            }

                            td, th {
                              border: 1px solid #dddddd;
                              text-align: left;
                              padding: 8px;
                            }

                            tr:nth-child(even) {
                              background-color: #dddddd;
                            }
                            </style>
                            </head>
                            <body>");

            _str.AppendLine(@"<h2>Test Spec</h2>");


        }

        /// <summary>
        /// insert test method
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="testclass"></param>
        /// <param name="testMethod"></param>
        /// <param name="description"></param>
        public void AddTestMethod(string assembly, string testclass, string testMethod, string description)
        {
            _record.Add(new Tuple<string, string, string, string>(assembly, testclass, testMethod, description));
        }


        /// <summary>
        /// dump info into file
        /// </summary>
        /// <param name="fileName"></param>
        public void Write(string fileName)
        {
            var assemblyGroup = _record.Select(x => x.Item1).Distinct();

            foreach (var assembly in assemblyGroup)
            {
                _str.AppendLine(@"<h3>");
                _str.AppendLine(assembly);
                _str.AppendLine(@"</h3>");

                _str.AppendLine(@"<table>");
                _str.AppendLine(@"<tr>
                            <th>Test Method</th>
                            <th>Test Description</th>
                          </tr>");

                foreach (var row in _record.Where(x => x.Item1.Equals(assembly)))
                {
                    _str.AppendLine(@"<tr>");
                    _str.AppendLine(@"<td>");
                    _str.Append(row.Item3);
                    _str.AppendLine(@"</td>");
                    _str.AppendLine(@"<td>");
                    _str.Append(row.Item4);
                    _str.AppendLine(@"</td>");
                    _str.AppendLine(@"</tr>");

                }

                _str.AppendLine(@"</table>");
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(_str.ToString());
            }

        }
    }

}
