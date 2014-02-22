//
//  GameInformation.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MagicEngine.Information {
	[XmlRoot ("GameInformation")]
	public class GameInformation : ITechnolable, IResolvable<Guid,Technology> {
		[XmlArray ("Cultures")]
		[XmlArrayItem ("Culture")]
		public List<Culture> Cultures {
			get;
			set;
		}

		[XmlArray ("Spells")]
		[XmlArrayItem ("Spell")]
		public List<Spell> Spells {
			get;
			set;
		}

		[XmlArray ("Buildings")]
		[XmlArrayItem ("Building")]
		public List<Building> Buildings {
			get;
			set;
		}

		[XmlArray ("SpellSkillProfiles")]
		[XmlArrayItem ("SpellSkillProfile")]
		public List<SpellSkillProfile> SpellSkillProfiles {
			get;
			set;
		}

		[XmlArray ("Technologies")]
		[XmlArrayItem ("Technology")]
		public List<Technology> Technology {
			get;
			set;
		}

		[XmlArray ("Resources")]
		[XmlArrayItem ("Resource")]
		public List<Resource> Resources {
			get;
			set;
		}

		public GameInformation () {
			this.Cultures = new List<Culture> ();
			this.Resources = new List<Resource> ();
			this.Technology = new List<Technology> ();
			this.Spells = new List<Spell> ();
			this.Buildings = new List<Building> ();
			this.SpellSkillProfiles = new List<SpellSkillProfile> ();
		}

		#region ITechnolable implementation

		public void Collect (List<Technology> technologies) {
			technologies.AddRange (this.GetTechnologies ());
		}

		#endregion

		public IEnumerable<Technology> GetTechnologies () {
			yield break;
		}

		public void Resolve () {
			List<Technology> alltechs = new List<Technology> ();
			this.Collect (alltechs);
			Dictionary<Guid,Technology> techdic = new Dictionary<Guid, Technology> (alltechs.Count);
			foreach (Technology tech in alltechs) {
				techdic.Add (tech.Guid, tech);
			}
			this.Resolve (techdic);
		}

		#region IResolvable implementation

		public void Resolve (Dictionary<Guid, Technology> dictionary) {

		}

		#endregion

		public static GameInformation ReadFromFile (string filename) {
			return Utils.ReadFromFileCallBack (filename, ReadFromStream);
		}

		public static GameInformation ReadFromStream (Stream s) {
			GameInformation gi = Utils.XmlDeserialize<GameInformation> (s);
			gi.Resolve ();
			return gi;
		}

		public void WriteToStream (Stream s) {
			Utils.XmlSerialize<GameInformation> (s, this);
		}

		public void WriteToFile (string filename) {
			Utils.WriteToFileCallBack (filename, this, Utils.XmlSerialize<GameInformation>);
		}
	}
}