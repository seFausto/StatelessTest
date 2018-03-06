using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var light = new Lights();

            light.Transition(Lights.Trigger.TurnOn);

            light.Transition(Lights.Trigger.Dim);

            light.Transition(Lights.Trigger.Dim);

            Console.ReadLine();
        }
    }
}
