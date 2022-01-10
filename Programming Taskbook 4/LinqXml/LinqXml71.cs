// File: "LinqXml71"
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
            Task("LinqXml71");
            string s = GetString();
            XDocument d = XDocument.Load(s);
            XNamespace ns = d.Root.Name.Namespace;
            var a = d.Root.Elements()
            .Select(e =>
            {
                return new
                {
                    company = e.Attribute("company").Value,
                    street = e.Attribute("street").Value,
                    brand = e.Element(ns + "info").Attribute("brand").Value,
                    price = e.Element(ns + "info").Attribute("price").Value,
                };
            }).Show();

            d.Root.ReplaceNodes(a.OrderByDescending(e => e.brand)
                 .GroupBy(e => e.brand,
                 (k, ee) => new XElement(ns + "b" + k,
                 ee.OrderByDescending(e => e.price)
                 .GroupBy(e =>e.price,
                 (k1, ee1) => new XElement(ns + "p" + k1,
                 ee1.OrderBy(e => e.company).OrderBy(e => e.street).Select(e =>
                 new XElement(ns + "info",
                 new XAttribute("street", e.street),
                 new XAttribute("company", e.company)
                 )))))));
            d.Save(s);
        }
    }
}
