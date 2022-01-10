// File: "LinqXml17"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;


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
            Task("LinqXml17");


            string fileName = GetString();
            XDocument source = XDocument.Load(fileName);

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (var elem in source.Elements())
            {
                //Show(elem.Name.LocalName);
                var res = elem.Descendants()
                   .Where(el => el.Nodes().Count() > 0 && el.FirstNode.NodeType is XmlNodeType.Text)
                   .Select(el => el.FirstNode);

                var p = res.Select(el => el.Parent.Name).Distinct();
                foreach (var key in p)
                {
                    if (!dict.ContainsKey(key.ToString()))
                    {
                        dict.Add(key.ToString(), new List<string>());
                    }
                    dict[key.ToString()].AddRange(res
                        .Where(el => el.Parent.Name == key)
                        .Select(e => e.ToString()));
                }

            }

            List<string> keys_sorted = new List<string>(dict.Keys);
            keys_sorted.Sort();
  

            foreach (string key in keys_sorted)
            {
                Put(key);
                Put(dict[key]);
            }

        }
    }
}
