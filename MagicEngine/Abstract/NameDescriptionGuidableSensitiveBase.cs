using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MagicEngine.Information;

namespace MagicEngine.Abstract {
	public abstract class NameDescriptionGuidableSensitiveBase : NameDescriptionGuidableBase, IGuidSensitive {

		#region IGuidSensitive implementation

		[XmlArray ("SensitiveGuids")]
		[XmlArrayItem ("Guid")]
		public HashSet<Guid> SensitiveGuids {
			get;
			set;
		}

		#endregion

		protected NameDescriptionGuidableSensitiveBase () : base () {
			this.SensitiveGuids = new HashSet<Guid> ();
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid) : base (guid) {
			this.SensitiveGuids = new HashSet<Guid> ();
		}

		protected NameDescriptionGuidableSensitiveBase (string name) : base (name) {
			this.SensitiveGuids = new HashSet<Guid> ();
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid, string name) : base (guid, name) {
			this.SensitiveGuids = new HashSet<Guid> ();
		}

		protected NameDescriptionGuidableSensitiveBase (string name, string description) : base (name, description) {
			this.SensitiveGuids = new HashSet<Guid> ();
		}

		protected NameDescriptionGuidableSensitiveBase (Guid guid, string name, string description) : base (guid, name, description) {
			this.SensitiveGuids = new HashSet<Guid> ();
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

