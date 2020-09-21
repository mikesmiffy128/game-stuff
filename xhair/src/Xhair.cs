using System.Drawing;
using System.Windows.Forms;

namespace xhair {
	public class Xhair : UserControl {
		/* const float GAP = 4; */
		Pen p = new Pen(Config.xhair_colour, Config.thickness);

		public Xhair() { Paint += new PaintEventHandler(onpaint); }

		private void onpaint(object sender, PaintEventArgs e) {
			float xm = Width / 2;
			float ym = Height / 2;
			// could support a gap some day:
			/*
			e.Graphics.DrawLine(p, xm, 0, xm, ym - GAP);
			e.Graphics.DrawLine(p, xm, ym + GAP, xm, Height);
			e.Graphics.DrawLine(p, 0, ym, xm - GAP, ym);
			e.Graphics.DrawLine(p, xm + GAP, ym, Width, ym);
			*/
			// but that's on the don't care list for now:
			e.Graphics.DrawLine(p, xm, 0, xm, Height);
			e.Graphics.DrawLine(p, 0, ym, Width, ym);
		}
	}
}
