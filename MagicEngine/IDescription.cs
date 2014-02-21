using System;
using System.Xml.Serialization;

namespace MagicEngine {
	public interface IDescription {
		[XmlAttribute ("Description")]
		string Description {
			get;
			set;
		}
	}
}

