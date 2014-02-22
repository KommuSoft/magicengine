using System;
using System.Xml.Serialization;

namespace MagicEngine.Abstract {
	public interface IDescription {
		[XmlAttribute ("Description")]
		string Description {
			get;
			set;
		}
	}
}

