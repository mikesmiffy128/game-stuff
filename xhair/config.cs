using System.Drawing;
using static System.Drawing.Color;

			/* Non-programmers: try and avoid all the C# syntax and just look *
			 * at these comments and their corresponding settings in this     *
			 * column over here!                                              */

namespace xhair {
static class Config {
public static readonly Color

			/* what colour do you want your crosshair to be?                  */
			xhair_colour = Magenta
,
			/* choose a DIFFERENT color for the background - you'll need to   *
			 * key out this color for OBS window capture.                     */
			transparent_colour = Green
;public
const int
			/* choose a width and height - normally these should be the same  *
			 * although for stretched resolutions you MIGHT decide to make it *
			 * e.g. 9x12 so that it appears even after stretching. up to you. */
			width = 12, height = 12
;public
const float
			/* choose a line thickness - if the value is below 2 or a decimal *
			 * value it may seem uneven/off-centre so that's not advised.     */
			thickness = 2
;
}
}
