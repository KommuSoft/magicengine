using System;
using System.Collections.Generic;
using MagicEngine.Information;
using System.Xml.Serialization;

namespace MagicEngine {
	public interface ICultureSensitive {
		[XmlArray ("Cultures")]
		[XmlArrayItem ("Culture")]
		ICollection<Guid> Cultures {
			get;
			set;
		}

		bool SupportsCulture (Culture culture);
	}
}

