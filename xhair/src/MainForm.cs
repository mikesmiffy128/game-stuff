using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace xhair {
	public class MainForm : Form {
		[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
		static extern long GetWindowLong(IntPtr w, int idx);
		[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
		static extern void SetWindowLong(IntPtr w, int idx, long val);

		private void onmenuclose(object sender, EventArgs e) { Close(); }
		private void onclose(object sender, EventArgs e) { icon.Dispose(); }

		// apparently icons are added simply by gc ref, cool api guys
		private NotifyIcon icon;
		private Timer topmosttimer;

		private void ontick(object sender, EventArgs e) {
			// don't do anything if the menu is visible otherwise it keeps
			// closing again every second
			if (!icon.ContextMenuStrip.Visible) {
				TopMost = true;
				CenterToScreen();
			}
		}

		public MainForm() {
			FormBorderStyle = FormBorderStyle.None;
			MinimumSize = new Size(1, 1);
			// enforce a minimum w/h, otherwise windows will, and we won't know
			#pragma warning disable CS0162 // dead code
			if (Config.width  > 16) Width  = Config.width;  else Width  = 16;
			if (Config.height > 16) Height = Config.height; else Height = 16;
			#pragma warning restore CS0162
			// ensure we cover fullscreen games, and handle res changes
			topmosttimer = new Timer();
			topmosttimer.Interval = 1000;
			topmosttimer.Tick += new EventHandler(ontick);
			topmosttimer.Start();
			TopMost = true;
			// XXX HACK: there should be a proper way to do this!
			BackColor = Config.transparent_colour;
			TransparencyKey = Config.transparent_colour;
			Xhair p = new Xhair();
			p.Width = Config.width;
			p.Height = Config.height;
			// if the size is too small the window is still bigger so centre the
			// control in the window to make sure it's actually centred properly
			p.Left = (Width - p.Width) / 2;
			p.Top = (Height - p.Height) / 2;
			Controls.Add(p);
			ShowInTaskbar = false;
			icon = new NotifyIcon();
			Icon = Icon.FromHandle(Properties.Resources.icon.GetHicon());
			icon.Icon = Icon;
			icon.Visible = true;
			ContextMenuStrip m = new ContextMenuStrip();
			m.Items.Add("Close", null, new EventHandler(onmenuclose));
			icon.ContextMenuStrip = m;
			FormClosing += onclose;
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			// FormStartPosition seems to be off sometimes...
			CenterToScreen();
			// clickthrough
			SetWindowLong(Handle, -20,
					GetWindowLong(Handle, -20) | 0x80000 | 0x20);
		}
	}
}
