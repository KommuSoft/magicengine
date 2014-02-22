using System;
using System.Collections.Generic;

namespace MagicEngine.Information {

	public class Player {

		public HashSet<Guid> AchievedGuid {
			get;
			private set;
		}

		public Culture Culture {
			get;
			private set;
		}

		public ResourceCollection ResourceCollection {
			get;
			private set;
		}

		public Player (Culture culture) {
			this.Culture = culture;
			this.AchievedGuid = new HashSet<Guid>();
			this.ResourceCollection = new ResourceCollection();
		}

	}
}

