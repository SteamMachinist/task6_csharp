using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6_csharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
