// File: "OOP3Behav6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractComparable
        {
            public abstract int CompareTo(AbstractComparable other);
            public static int IndexMax(List<AbstractComparable> abstracts)
            {
                int max = 0;
                int maxElement = -1;
                int[] countOne = new int[abstracts.Count];

                for (int i = 0; i < countOne.Length; i++)
                {
                    countOne[i] = 0;

                }
                for (int i = 0; i < abstracts.Count; i++)
                {
                    for (int j = 0; j < abstracts.Count; j++)
                    {
                        int d = abstracts[i].CompareTo(abstracts[j]);
                        if (d == 1)
                        {
                            countOne[i]++;
                        }
                    }
                }
                for (int i = 0; i < countOne.Length; i++)
                {
                    if (maxElement < countOne[i])
                    {
                        max = i;
                        maxElement = countOne[i];
                    }
                }
                return max;
            }


            public static int LastIndexMax(List<AbstractComparable> abstracts)
            {
                int lastMax = 0;

                int maxElement = -1;
                int[] countOne = new int[abstracts.Count];

                for (int i = 0; i < countOne.Length; i++)
                {
                    countOne[i] = 0;

                }
                for (int i = 0; i < abstracts.Count; i++)
                {
                    for (int j = 0; j < abstracts.Count; j++)
                    {
                        int d = abstracts[i].CompareTo(abstracts[j]);
                        if (d == 1)
                        {
                            countOne[i]++;
                        }
                    }
                }
                for (int i = 0; i < countOne.Length; i++)
                {
                    if (maxElement <= countOne[i])
                    {
                        lastMax = i;
                        maxElement = countOne[i];
                    }
                }
                return lastMax;
            }


            public static int IndexMin(List<AbstractComparable> abstracts)
            {
                int min = 0;
                int minElement = 0;
                int[] countOne = new int[abstracts.Count];

                for (int i = 0; i < countOne.Length; i++)
                {
                    countOne[i] = 0;

                }
                for (int i = 0; i < abstracts.Count; i++)
                {
                    for (int j = 0; j < abstracts.Count; j++)
                    {
                        int d = abstracts[i].CompareTo(abstracts[j]);
                        if (d == -1)
                        {
                            countOne[i]++;
                        }
                    }
                }
                for (int i = 0; i < countOne.Length; i++)
                {
                    if (minElement < countOne[i])
                    {
                        min = i;
                        minElement = countOne[i];
                    }
                }
                return min;
            }

            public static int LastIndexMin(List<AbstractComparable> abstracts)
            {
                int lastMin = 0;

                int minElement = 0;
                int[] countOne = new int[abstracts.Count];

                for (int i = 0; i < countOne.Length; i++)
                {
                    countOne[i] = 0;

                }
                for (int i = 0; i < abstracts.Count; i++)
                {
                    for (int j = 0; j < abstracts.Count; j++)
                    {
                        int d = abstracts[i].CompareTo(abstracts[j]);
                        if (d == -1)
                        {
                            countOne[i]++;
                        }
                    }
                }
                for (int i = 0; i < countOne.Length; i++)
                {
                    if (minElement <= countOne[i])
                    {
                        lastMin = i;
                        minElement = countOne[i];
                    }
                }
                return lastMin;
            }
            // Implement the IndexMax, LastIndexMax, IndexMin
            //   and LastIndexMin static methods
        }

        public class NumberComparable : AbstractComparable
        {
            public int key = 0;
            public NumberComparable(string data)
            {

                int.TryParse(data, out key);

            }
            public override int CompareTo(AbstractComparable other)
            {
                NumberComparable test = other as NumberComparable;
                if (test.key > key)
                {
                    return -1;
                }
                if (test.key == key)
                {
                    return 0;
                }
                if (test.key < key)
                {
                    return 1;
                }
                return -10;
            }


        }

        public class LengthComparable : AbstractComparable
        {
            public int key;
            public LengthComparable(string data)
            {
                key = data.Length;
            }
            public override int CompareTo(AbstractComparable other)
            {
                LengthComparable test = other as LengthComparable;
                if (test.key > key)
                {
                    return -1;
                }
                if (test.key == key)
                {
                    return 0;
                }
                if (test.key < key)
                {
                    return 1;
                }
                return -10;
            }
        }

        public class TextComparable : AbstractComparable
        {
            public string key;
            public TextComparable(string data)
            {
                key = data;
            }
            public override int CompareTo(AbstractComparable other)
            {
                TextComparable test = other as TextComparable;
                //int d=key.CompareTo(test.key);
                int d = string.CompareOrdinal(key, test.key);
                if (d < -1)
                {
                    return -1;
                }
                if (d > 1)
                {
                    return 1;
                }
                return d;
            }
        }

        // Implement the NumberComparable, LengthComparable
        //   and TextComparable descendant classes

        public static void Solve()
        {
            Task("OOP3Behav6");
            int n, k;
            n = GetInt();
            k = GetInt();
            string[,] massiv = new string[k, n + 1];
            List<AbstractComparable> comp = new List<AbstractComparable>();
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    massiv[i, j] = GetString();

                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    switch (massiv[i, 0])
                    {
                        case "N":
                            comp.Add(new NumberComparable(massiv[i, j]));
                            break;
                        case "T":
                            comp.Add(new TextComparable(massiv[i, j]));
                            break;
                        case "L":
                            comp.Add(new LengthComparable(massiv[i, j]));
                            break;
                    }
                }

                int index = AbstractComparable.IndexMax(comp);
                int lastIndex = AbstractComparable.LastIndexMax(comp);
                int minIndex = AbstractComparable.IndexMin(comp);
                int lastMinIndex = AbstractComparable.LastIndexMin(comp);
                Show(index);
                Show(lastIndex);
                Show(minIndex);
                Show(lastMinIndex);
                Put(index);
                Put(lastIndex);
                Put(minIndex);
                Put(lastMinIndex);
                Show("-------");
                comp.Clear();
            }
        }
    }
}
