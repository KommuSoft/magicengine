using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MagicEngine.Information;

namespace MagicEngine.Abstract {
	public class NameDescriptionCulturedGuidableBase : NameDescriptionGuidableBase, ICultureSensitive {

		#region ICultureSensitive implementation

		[XmlArray ("Cultures")]
		[XmlArrayItem ("Culture")]
		public ICollection<Guid> Cultures {
			get;
			set;
		}

		#endregion

		public NameDescriptionCulturedGuidableBase () {
		}

		#region ICultureSensitive implementation

		public bool SupportsCulture (Culture culture) {
			return this.Cultures.Contains (culture.Guid);
		}

		#endregion

	}
}

