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
			this.reset();
		}

		public AssemblyLine (Guid guid) : base (guid) {
			this.reset();
		}

		public AssemblyLine (string name) : base (name) {
			this.reset();
		}

		public AssemblyLine (Guid guid, string name) : base (guid, name) {
			this.reset();
		}

		public AssemblyLine (string name, string description) : base (name,description) {
			this.reset();
		}

		public AssemblyLine (Guid guid, string name, string description) : base (guid, name,description) {
			this.reset();
		}

		private void reset () {
			this.Sources = new ResourceCollection();
			this.Results = new ResourceCollection();
		}

		public void AddSource (Resource resource, long amount) {
			this.Sources.Add(resource,amount);
		}

		public void AddResult (Resource resource, long amount) {
			this.Results.Add(resource,amount);
		}

	}
}

