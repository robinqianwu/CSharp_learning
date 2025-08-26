using System;
using System.Windows.Forms;
using CSharp_learning.Forms;

namespace CSharp_learning
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
