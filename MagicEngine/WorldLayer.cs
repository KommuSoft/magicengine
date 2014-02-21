using System;

namespace MagicEngine {
	public class WorldLayer<TItem> {
		public TItem[,] data;

		public WorldLayer (int height, int width) {
			this.data = new TItem[height, width];
		}

		public void Covolve2d () {

		}
	}
}