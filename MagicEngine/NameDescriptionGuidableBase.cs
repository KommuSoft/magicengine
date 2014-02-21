using System;
using System.Xml.Serialization;

namespace MagicEngine {
	public abstract class NameDescriptionGuidableBase : NameGuidableBase, IDescription {

		#region IDescription implementation

		[XmlAttribute ("Description")]
		string Description {
			get;
			set;
		}

		#endregion

		protected NameDescriptionGuidableBase () : base () {
		}

		protected NameDescriptionGuidableBase (Guid guid) : base (guid) {
		}

		protected NameDescriptionGuidableBase (string name) : base (name) {
		}

		protected NameDescriptionGuidableBase (Guid guid, string name) : base (guid, name) {
		}

		protected NameDescriptionGuidableBase (string name, string description) : this (name) {
			this.Description = description;
		}

		protected NameDescriptionGuidableBase (Guid guid, string name, string description) : this (guid, name) {
			this.Description = description;
		}
	}
}

