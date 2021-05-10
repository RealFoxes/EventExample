using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcessBusinessLogic bl = new ProcessBusinessLogic();
			bl.MessageExecutor += MessageToUp; // register with an event
			bl.MessageExecutor += MessageToReverse; // register with an event
            bl.Message("1cGovno");
            Console.ReadKey();
        }

        public static void MessageToReverse(string message)
        {
            Console.WriteLine(String.Join(" ", message.Reverse()));
        }
        public static void MessageToUp(string message)
        {
            Console.WriteLine(message.ToUpper());
        }
    }

    public delegate void MessageExecutor(string message);  // delegate
    public class ProcessBusinessLogic
    {
        public event MessageExecutor MessageExecutor; // event

        public void Message(string message)
		{
            MessageExecutor?.Invoke(message);
		}
    }
}
