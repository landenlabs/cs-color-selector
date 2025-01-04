using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSnamespace
{
    static class Program
    {
        /// <summary>
        /// Author: Dennis Lang - 2009
        /// https://landenlabs.com/
        /// 
        /// Demo HSL/Color selector dialog.
        /// 
        /// </summary>
        [STAThread]
        static void Main(string[] cmdLineArgs)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ColorSelectorDemo());
        }
    }
}
