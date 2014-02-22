using System;
using System.Collections.Generic;
using MagicEngine.Information;
using System.Xml.Serialization;

namespace MagicEngine.Abstract {
	public interface IGuidSensitive {
		[XmlArray ("SensitiveGuids")]
		[XmlArrayItem ("Guid")]
		ICollection<Guid> SensitiveGuids {
			get;
			set;
		}

		bool SupportsGuid (Guid guid);

		bool SupportsGuid (IGuidable guidable);
	}
}

