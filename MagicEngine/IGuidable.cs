using System;
using System.Xml.Serialization;

namespace MagicEngine {
	public interface IGuidable {
		[XmlAttribute ("Guid")]
		Guid Guid {
			get;
			set;
		}
	}
}

