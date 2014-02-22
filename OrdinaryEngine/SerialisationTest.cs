using NUnit.Framework;
using System;
using System.Xml.Serialization;
using MagicEngine.Information;
using MagicEngine.Serialisation;

namespace OrdinaryEngine {
	[TestFixture ()]
	public class SerialisationTest {
		[Test ()]
		public void TestGameInformation () {
			XmlSerializer ser = new XmlSerializer (typeof(GameInformation));
		}

		[Test ()]
		public void TestCulture () {
			XmlSerializer ser = new XmlSerializer (typeof(Culture));
		}

		[Test ()]
		public void TestTechnology () {
			XmlSerializer ser = new XmlSerializer (typeof(Technology));
		}

		[Test ()]
		public void TestSerialisationImage () {
			XmlSerializer ser = new XmlSerializer (typeof(SerializableImage));
		}

		[Test ()]
		public void TestResource () {
			XmlSerializer ser = new XmlSerializer (typeof(Resource));
		}
	}
}

