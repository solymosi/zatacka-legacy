using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    static class Program
    {
        static public GameForm Form;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form = new GameForm();
            Application.Run(Form);
        }
    }
}
