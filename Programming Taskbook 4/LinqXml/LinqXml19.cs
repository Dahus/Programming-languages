// File: "LinqXml19"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
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
            Task("LinqXml19");
            XDocument d = XDocument.Load(GetString());
            foreach (var e1 in d.Root.Elements())
            {
                Put(e1.Name.LocalName);
                int max = e1.Descendants()
                .Select(e => e.DescendantNodes().Count())
                .DefaultIfEmpty(-1).Max();

                Put(max);

                var a = e1.Descendants()
                .Where(e => e.DescendantNodes().Count() == max)
                .Select(e => e.Name.LocalName)
                .OrderBy(e => e)
                .DefaultIfEmpty("no child");
                foreach (var e in a)
                { 
                    Put(e);
                }
            }
        }
    }
}
