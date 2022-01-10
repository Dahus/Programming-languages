// File: "OOP1Creat10"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Builder
        {
            public virtual void BuildStart(char c) {}
            public virtual void BuildFirstChar(char c) {}
            public virtual void BuildNextChar(char c) {}
            public virtual void BuildFirstSpace() {}
            public abstract string GetResult();
        }

        // Implement the BuilderPascal, BuilderPyhton
        //   and BuilderC descendant classes

        public class BuilderPascal : Builder
        {
            public string product = "";
            public override void BuildStart(char c) {
                product = "";
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c) {
                product += c.ToString().ToUpper();
            }
            public override void BuildNextChar(char c) {
                product += c.ToString().ToLower();
            }
            public override void BuildFirstSpace() {
                product += "";
            }
            public override string GetResult()
            {
                return product;
            }
        }

        public class BuilderPython : Builder
        {
            public string product = "";
            public override void BuildStart(char c)
            {
                product = "";
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c)
            {
                product += c.ToString().ToLower();
            }
            public override void BuildNextChar(char c)
            {
                product += c.ToString().ToLower();
            }
            public override void BuildFirstSpace()
            {
                product += "_";
            }
            public override string GetResult()
            {
                return product;
            }
        }

        public class BuilderC : Builder
        {
            public string product = "";
            public override void BuildStart(char c)
            {
                product = "";
                product += c.ToString().ToLower();
            }
            public override void BuildFirstChar(char c)
            {
                product += c.ToString().ToLower();
            }
            public override void BuildNextChar(char c)
            {
                product += c.ToString().ToLower();
            }
            public override void BuildFirstSpace()
            {
                product += "";
            }
            public override string GetResult()
            {
                return product;
            }
        }

        public class Director
        {
            Builder b;
            public Director(Builder b)
            {
                this.b = b;
            }
            public string GetResult()
            {
                return b.GetResult();
            }
            public void Construct(string templat)
            {
                bool isSpace = false;
                int countSpace = 0;
                bool isNextSymbol;
                bool isOneSpace = false;
                b.BuildStart(templat[0]);
                for (int i = 1; i < templat.Length; i++)
                {
                    isNextSymbol = true;
                    if (isSpace == true && templat[i] != ' ')
                    {
                        isSpace = false;
                        isNextSymbol = false;
                        b.BuildFirstChar(templat[i]);
                        isOneSpace = false;
                    }
                    if (templat[i] == ' ' && isOneSpace == false)
                    {
                        isNextSymbol = false;
                        isSpace = true;
                        countSpace++;
                        isOneSpace = true;
                        b.BuildFirstSpace();
                    }
                    if (isNextSymbol == true && templat[i] != ' ')
                    {
                        b.BuildNextChar(templat[i]);
                    }
                }

                // Complete the implementation of the method
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat10");
            string[] stroks = new string[5];
            string[] stroks1 = new string[15];
            for (int i = 0; i < 5; i++)
            {
                stroks[i] = GetString();
            }
            BuilderPascal builderPascal = new BuilderPascal();
            BuilderPython builderPython = new BuilderPython();
            BuilderC builderC = new BuilderC();
            Director[] director = new Director[3];
            director[0] = new Director(builderPascal);
            director[1] = new Director(builderPython);
            director[2] = new Director(builderC);

            director[0].Construct(stroks[0]);
            stroks1[0] = director[0].GetResult();
            director[1].Construct(stroks[0]);
            stroks1[1] = director[1].GetResult();
            director[2].Construct(stroks[0]);
            stroks1[2] = director[2].GetResult();
            director[0].Construct(stroks[1]);
            stroks1[3] = director[0].GetResult();
            director[1].Construct(stroks[1]);
            stroks1[4] = director[1].GetResult();
            director[2].Construct(stroks[1]);
            stroks1[5] = director[2].GetResult();
            director[0].Construct(stroks[2]);
            stroks1[6] = director[0].GetResult();
            director[1].Construct(stroks[2]);
            stroks1[7] = director[1].GetResult();
            director[2].Construct(stroks[2]);
            stroks1[8] = director[2].GetResult();
            director[0].Construct(stroks[3]);
            stroks1[9] = director[0].GetResult();
            director[1].Construct(stroks[3]);
            stroks1[10] = director[1].GetResult();
            director[2].Construct(stroks[3]);
            stroks1[11] = director[2].GetResult();
            director[0].Construct(stroks[4]);
            stroks1[12] = director[0].GetResult();
            director[1].Construct(stroks[4]);
            stroks1[13] = director[1].GetResult();
            director[2].Construct(stroks[4]);
            stroks1[14] = director[2].GetResult();
            for (int i = 0; i < 15; i++)
            {
                Put(stroks1[i]);
            }
        }
    }
}
