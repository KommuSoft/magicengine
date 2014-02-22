using System;
using System.Xml.Serialization;
using MagicEngine.Information;

namespace MagicEngine.Abstract {
	public class NameGuidableBase : GuidableBase, IName {

		#region IName implementation

		[XmlAttribute ("Name")]
		public string Name {
			get;
			set;
		}

		#endregion

		protected NameGuidableBase () : base () {
		}

		protected NameGuidableBase (Guid guid) : base (guid) {
		}

		protected NameGuidableBase (string name) : this () {
			this.Name = name;
		}

		protected NameGuidableBase (Guid guid, string name) : this (guid) {
			this.Name = name;
		}
	}
}

