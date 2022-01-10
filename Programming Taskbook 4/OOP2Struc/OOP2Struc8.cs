// File: "OOP2Struc8"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Function
        {
            protected Function func;
            public abstract string GetName();
            public abstract int GetValue(int x);
        }

        // Implement the FX, FDouble, FTriple, FSquare
        //   and FCube descendant classes
        public class FX : Function
        {
            public override string GetName()
            {
                return "X";
            }

            public override int GetValue(int x)
            {
                return x;
            }
        }

        public class FDouble : Function
        {
            public FDouble(Function function)
            {
                func = function;
            }
            public override string GetName()
            {
                return "2*(" + func.GetName() + ")";
            }

            public override int GetValue(int x)
            {
                return 2 * func.GetValue(x);
            }
        }

        public class FTriple : Function
        {
            public FTriple(Function function)
            {
                func = function;
            }
            public override string GetName()
            {
                return "3*(" + func.GetName() + ")";
            }

            public override int GetValue(int x)
            {
                return 3 * func.GetValue(x);
            }
        }

        public class FSquare : Function
        {
            public FSquare(Function function)
            {
                func = function;
            }
            public override string GetName()
            {
                return "(" + func.GetName() + ")^2"; ;
            }

            public override int GetValue(int x)
            {
                return func.GetValue(x) * func.GetValue(x);
            }
        }

        public class FCube : Function
        {
            public FCube(Function function)
            {
                func = function;
            }
            public override string GetName()
            {
                return "(" + func.GetName() + ")^3";
            }

            public override int GetValue(int x)
            {
                return func.GetValue(x) * func.GetValue(x) * func.GetValue(x);
            }
        }

        public static void Solve()
        {
            Task("OOP2Struc8");
            int N = GetInt();
            string[] masString = new string[N];

            for (int i = 0; i < N; i++)
                masString[i] = GetString();

            int X1 = GetInt();
            int X2 = GetInt();
            int[] masInt = new int[] { X1, X2 };

            Function[] masFunc = new Function[N];

            for (int i = 0; i < N; i++)
            {
                for (int k = 0; k < 2; k++)
                {
                    int countSymbol = masString[i].Length;
                    masFunc[i] = new FX();
                    for (int j = 0; j < countSymbol; j++)
                    {
                        string str = masString[i];
                        switch (str[j])
                        {
                            case ' ':
                                masFunc[i] = new FX();
                                masFunc[i].GetValue(masInt[k]);
                                break;
                            case 'D':
                                masFunc[i] = new FDouble(masFunc[i]);
                                masFunc[i].GetValue(masFunc[i].GetValue(masInt[k]));
                                break;
                            case 'T':
                                masFunc[i] = new FTriple(masFunc[i]);
                                masFunc[i].GetValue(masFunc[i].GetValue(masInt[k]));
                                break;
                            case 'S':
                                masFunc[i] = new FSquare(masFunc[i]);
                                masFunc[i].GetValue(masFunc[i].GetValue(masInt[k]));
                                break;
                            case 'C':
                                masFunc[i] = new FCube(masFunc[i]);
                                masFunc[i].GetValue(masFunc[i].GetValue(masInt[k]));
                                break;
                        }
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                Put(masFunc[i].GetName());
                Put(masFunc[i].GetValue(masInt[0]));
                Put(masFunc[i].GetValue(masInt[1]));
            }
        }
    }
}
