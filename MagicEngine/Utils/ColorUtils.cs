using System;

namespace MagicEngine.Utils {
	public static class ColorUtils {
		public static uint FromWavelength (int lambda) {
			if (lambda < 350 || lambda > 780) {
				return 0x00;
			} else {
				uint r = 0x00;
				uint g = 0x00;
				uint b = 0x00;
				uint factor = 0xffff;
				if (lambda < 440) {
					r = (uint)((440 - lambda) * 0x02d8);
					b = 0xffff;
					if (lambda < 420) {
						factor = (uint)(0x4ccc + 0xb332 * (lambda - 350) / 70);
					}
				} else if (lambda < 490) {
					g = (uint)((lambda - 440) * 0x051e);
					b = 0xffff;
				} else if (lambda < 510) {
					g = 0xffff;
					b = (uint)((510 - lambda) * 0x0ccc);
				} else if (lambda < 580) {
					r = (uint)((lambda - 510) * 0x03a8);
					g = 0xffff;
				} else if (lambda < 645) {
					r = 0xffff;
					g = (uint)((645 - lambda) * 0x03f0);
				} else {
					r = 0xffff;
					if (lambda > 700) {
						factor = (uint)(0x4ccc + 0xb332 * (780 - lambda) / 80);
					}
				}
				r *= factor;
				g *= factor;
				b *= factor;
				r >>= 0x08;
				r &= 0xff0000;
				g >>= 0x10;
				g &= 0x00ff00;
				b >>= 0x18;
				return r | g | b;
			}
		}
	}
}

