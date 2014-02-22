using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MagicEngine.Information;

namespace MagicEngine.Abstract {
	public abstract class NameDescriptionGuidableSensitiveBase : NameDescriptionGuidableBase, IGuidSensitive {

		#region IGuidSensitive implementation

		[XmlArray ("SensitiveGuids")]
		[XmlArrayItem ("Guid")]
		public ICollection<Guid> SensitiveGuids {
			get;
			set;
		}

		#endregion

		protected NameDescriptionGuidableSensitiveBase () : base () {
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid) : base (guid) {
		}

		protected NameDescriptionGuidableSensitiveBase (string name) : base (name) {
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid, string name) : base (guid, name) {
		}

		protected NameDescriptionGuidableSensitiveBase (string name, string description) : base (name, description) {
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid, string name, string description) : base (guid, name, description) {
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

