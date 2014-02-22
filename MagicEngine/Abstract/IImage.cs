using System;
using System.Xml.Serialization;
using MagicEngine.Serialisation;

namespace MagicEngine.Abstract {
	public interface IImage {
		[XmlElement ("Image")]
		SerializableImage Image {
			get;
			set;
		}
	}
}

