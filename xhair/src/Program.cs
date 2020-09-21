using System;
using System.Threading;
using System.Windows.Forms;

namespace xhair {
	static class Program {
		// dumb thing (allow graceful taskkill handling):
		private class WMCloseMessageFilter : IMessageFilter {
			private Form f;
			public WMCloseMessageFilter(Form f) { this.f = f; }
			public bool PreFilterMessage(ref Message m) {
				if (m.Msg == 16 /* WM_CLOSE */) f.Close();
				return false;
			}
		}

		static Mutex mutex = new Mutex(false,
				"xhair-79D2D29E-2E20-4164-A367-CAB97E0AB0C0");

		[STAThread]
		static void Main() {
			if (!mutex.WaitOne(0)) return;

			//Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form f = new MainForm();
			Application.AddMessageFilter(new WMCloseMessageFilter(f));
			Application.Run(f);
		}
	}
}
