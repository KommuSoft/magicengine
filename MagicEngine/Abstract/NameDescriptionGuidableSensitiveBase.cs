using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MagicEngine.Information;

namespace MagicEngine.Abstract {
	public class NameDescriptionGuidableSensitiveBase : NameDescriptionGuidableBase, IGuidSensitive {

		#region IGuidSensitive implementation

		[XmlArray ("SensitiveGuids")]
		[XmlArrayItem ("Guid")]
		public ICollection<Guid> SensitiveGuids {
			get;
			set;
		}

		#endregion

		public NameDescriptionGuidableSensitiveBase () {
		}

		#region IGuidSensitive implementation

		public bool SupportsGuid (Guid guid) {
			return this.SensitiveGuids.Contains (guid);
		}

		public bool SupportsGuid (IGuidable guidable) {
			return this.SensitiveGuids.Contains (guidable.Guid);
		}

		#endregion

	}
}

