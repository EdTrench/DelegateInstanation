using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelegateInstanation
{
    class Program
    {
        static void Main(string[] args)
        {

            RunAsCSharpVersion(5);
            Console.ReadKey();
        }

        static void RunAsCSharpVersion(Int16 cSharpVersion)
        {
            EventHandler handler;

            switch (cSharpVersion)
            {
                case 1:
                    //c# 1
                    handler = new EventHandler(HandleDemoEvent);
                    handler(null, EventArgs.Empty);
                    break;
                case 2:
                    //c# 2; implicit conversion
                    handler = HandleDemoEvent;
                    handler(null, EventArgs.Empty);
                    break;
                case 3:
                    //c# 2; anoynomous method
                    handler = delegate(object sender, EventArgs e)
                        { Console.WriteLine("Handled anonymously"); };
                    handler(null, EventArgs.Empty);
                    break;
                case 4:
                    //C# 2; anoynomous method, don't need paramter
                    handler = delegate
                        { Console.WriteLine("Handled anonoymously again"); };
                    handler(null, EventArgs.Empty);
                    break;
                case 5:
                    //C# 2; delegate contravariance
                    MouseEventHandler mouseHandler = HandleDemoEvent;
                    mouseHandler(null, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
                    break;
            }
        }

        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Handled by HandleDemoEvent");
        }
    }

}
