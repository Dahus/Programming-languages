// File: "LinqXml9"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // ��� ������� ����� ������ LinqXml �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.

        public static void Solve()
        {
            Task("LinqXml9");

            var sourceString = File.ReadAllLines(GetString(), Encoding.Default); // �������� XML ������

            XDocument stringProcessing = new XDocument( // ����������� ������ XDocument
               new XDeclaration(null, "windows-1251", null),
               new XElement("root", // ������� 0 ������
                   sourceString.Select(stringXML => stringXML.StartsWith("comment:") ? 
                   
                   new XComment(stringXML.Substring(8)) : // ����������� � �����������

                   new XElement("line", stringXML) as object)));

            /*
            XDocument stringProcessing = new XDocument(
                new XDeclaration(null, "windows-1251", null),
                new XElement("root",
                    sourceString.Select(stringXML => stringXML.StartsWith("comment:") ?
                    new XProcessingInstruction("d", stringXML.Substring(8)) : // Substring() �������� ���. ����

                    new XElement("line", stringXML) as object)));
            */

            stringProcessing.Save(GetString());
        }
    }
}
