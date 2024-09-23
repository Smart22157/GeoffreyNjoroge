using Geoffrey_Muchangi.Models;
using System;
using System.Windows.Forms;

namespace Geoffrey_Muchangi.Models
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Ensure this points to your form
        }
    }
}
