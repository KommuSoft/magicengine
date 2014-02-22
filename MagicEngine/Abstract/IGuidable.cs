using System;
using System.Xml.Serialization;

namespace MagicEngine.Abstract {
	public interface IGuidable {
		[XmlAttribute ("Guid")]
		Guid Guid {
			get;
			set;
		}
	}
}

