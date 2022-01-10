// File: "OOP1Creat5"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class AbstractButton
        {
            public string text;
            public abstract string GetControl();
        }

        // Implement the Button1 and Button2 descendant classes

        public class Button1 : AbstractButton {

            public Button1(string buttonText) {
                text = '[' + buttonText.ToUpper() + ']';
            }
            public override string GetControl()
            {
                return text;
            }
        }

        public class Button2 : AbstractButton
        {
            public Button2(string buttonText)
            {
                text = '<' + buttonText.ToLower() + '>';
            }
            public override string GetControl()
            {
                return text;
            }
        }

        public abstract class AbstractLabel
        {
            public string text;
            public abstract string GetControl();
        }

        // Implement the Label1 and Label2 descendant classes

        public class Label1 : AbstractLabel
        {
            public Label1(string labelText)
            {
                text = '=' + labelText.ToUpper() + '=';
            }
            public override string GetControl()
            {
                return text;
            }
        }

        public class Label2 : AbstractLabel
        {
            public Label2(string labelText)
            {
                text = '"' + labelText.ToLower() + '"';
            }
            public override string GetControl()
            {
                return text;
            }
        }

        public abstract class ControlFactory
        {
            public abstract AbstractButton CreateButton(string text);
            public abstract AbstractLabel CreateLabel(string text);
        }

        public class Factory1 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                Button1 button = new Button1(text);
                return button;
            }

            public override AbstractLabel CreateLabel(string text)
            {
                Label1 label = new Label1(text);
                return label;
            }
        }

        public class Factory2 : ControlFactory
        {
            public override AbstractButton CreateButton(string text)
            {
                Button2 button = new Button2(text);
                return button;
            }

            public override AbstractLabel CreateLabel(string text)
            {
                Label2 label = new Label2(text);
                return label;
            }
        }

        // Implement the Factory1 and Factory2 descendant classes

        public class Client
        {
            // Add required fields
            ControlFactory control;
            public string resText = "";
            public AbstractButton button;
            public AbstractLabel label;
            public Client(ControlFactory f)
            {
                // Implement the constructor
                control = f;
            }
            public void AddButton(string text)
            {
                // Implement the method
                button = control.CreateButton(text);
                resText += button.GetControl() + " ";
            }
            public void AddLabel(string text)
            {
                // Implement the method
                label = control.CreateLabel(text);
                resText += label.GetControl() + " ";
            }
            public string GetControls()
            {
                // Remove the previous statement and implement the method
                return resText.Remove(resText.Length-1);
            }
        }

        public static void Solve()
        {
            Task("OOP1Creat5");
            Factory1 factory1 = new Factory1();
            Factory2 factory2 = new Factory2();
            Client client1 = new Client(factory1);
            Client client2 = new Client(factory2);
            int N = GetInt();
            string[] str = new string[N];

            for (int i = 0; i < N; i++) {
                str[i] = GetString();
                string[] words = str[i].Split(new char[] { ' ' });
                if (words[0] == "B")
                {
                    client1.AddButton(words[1]);
                    client2.AddButton(words[1]);
                } else if (words[0] == "L")
                {
                    client1.AddLabel(words[1]);
                    client2.AddLabel(words[1]);
                }
            }
            Put(client1.GetControls(), client2.GetControls());

            Console.WriteLine("1");
        }
    }
}
