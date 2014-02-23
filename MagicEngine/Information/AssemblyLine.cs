using System;
using MagicEngine.Abstract;
using System.Xml.Serialization;

namespace MagicEngine.Information {

	public class AssemblyLine : NameDescriptionGuidableBase {

		public const double DefaultProcessingTime = 60.0d;

		[XmlElement("Resources")]
		public ResourceCollection Sources {
			get;
			set;
		}

		[XmlElement("Results")]
		public ResourceCollection Results {
			get;
			set;
		}

		[XmlAttribute("ProcessingTime")]
		public double ProcessingTime {
			get;
			set;
		}

		public AssemblyLine () : base () {
		}

		public AssemblyLine (Guid guid) : base (guid) {
		}

		public AssemblyLine (string name) : base (name) {
		}

		public AssemblyLine (Guid guid, string name) : base (guid, name) {
		}

		public AssemblyLine (string name, string description) : base (name,description) {
		}

		public AssemblyLine (Guid guid, string name, string description) : base (guid, name,description) {
		}

		public void AddSource (Resource resource, long amount) {
		}

	}
}

