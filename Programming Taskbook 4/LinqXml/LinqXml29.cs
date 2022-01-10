// File: "LinqXml29"
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

        public static void Solve()
        {
            Task("LinqXml29");
            string s = GetString();

            XDocument d = XDocument.Load(s);

            d.Root.Descendants().Where(el => el.DescendantNodes().Count() == 0 
		&& el.Ancestors().Count() <3).Remove();
            d.Save(s);
        }
    }
}
