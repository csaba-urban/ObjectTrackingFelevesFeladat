using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectTracking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			System.Threading.Mutex mutex = new System.Threading.Mutex( false, "UrbanCsaba" );
			if ( !mutex.WaitOne( 0 ) )
			{
				MessageBox.Show( "A program egy példánya már fut.", "Object Tracking" );
				return;
			}

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
