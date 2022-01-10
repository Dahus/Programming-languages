// File: "OOP2Struc6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Device
        {
            protected int cost;
            protected string name;
            public virtual void Add(Device d) { }
            public abstract string GetName();
            public abstract int GetTotalPrice();
        }

        public class SimpleDevice : Device
        {
            public SimpleDevice(string name, int cost)
            {
                this.name = name;
                this.cost = cost;
            }
            public override string GetName()
            {
                return name;
            }

            public override int GetTotalPrice()
            {
                return cost;
            }
        }

        public class CompoundDevice : Device
        {
            List<Device> listDevice = new List<Device>();

            public CompoundDevice(string name, int cost)
            {
                this.name = name;
                this.cost = cost;
            }

            public override void Add(Device d)
            {
                listDevice.Add(d);
            }
            public override string GetName()
            {
                return name;
            }

            public override int GetTotalPrice()
            {
                int sum = cost;
                if (listDevice.Count != 0)
                {
                    for (int i = 0; i < listDevice.Count; i++)
                    {
                        sum += listDevice[i].GetTotalPrice();
                    }
                }

                return sum;
            }

        }
        // Implement the SimpleDevice
        //   and CompoundDevice descendant classes

        public static void Solve()
        {
            Task("OOP2Struc6");
            int n = GetInt();
            string[] str = new string[n];
            int[] cost = new int[n];
            int[] parents = new int[n];

            Device[] mas = new Device[n];

            for (int i = 0; i < n; i++)
            {
                str[i] = GetString();
                cost[i] = GetInt();

                string checkstr = str[i];
                if (char.IsUpper(checkstr[0]) == true)
                    mas[i] = new CompoundDevice(str[i], cost[i]);
                else
                    mas[i] = new SimpleDevice(str[i], cost[i]);
            }

            for (int i = 0; i < n; i++)
            {
                parents[i] = GetInt();
                if (parents[i] != -1)
                    mas[parents[i]].Add(mas[i]);
            }

            for (int i = 0; i < n; i++)
            {
                Put(mas[i].GetName());
                Put(mas[i].GetTotalPrice());
            }
        }
    }
}
