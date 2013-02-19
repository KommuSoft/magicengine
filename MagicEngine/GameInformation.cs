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
using System.Xml.Serialization;

namespace MagicEngine.Information {

	[XmlRoot("GameInformation")]
	public class GameInformation : ITechnolable, IResolvable<Guid,Technology> {

		[XmlArray("Cultures")]
		[XmlArrayItem("Culture")]
		public List<Culture> Cultures {
			get;
			set;
		}
		[XmlArray("Spells")]
		[XmlArrayItem("Spell")]
		public List<Spell> Spells {
			get;
			set;
		}
		[XmlArray("Buildings")]
		[XmlArrayItem("Building")]
		public List<Building> Buildings {
			get;
			set;
		}
		[XmlArray("SpellSkillProfiles")]
		[XmlArrayItem("SpellSkillProfile")]
		public List<SpellSkillProfile> SpellSkillProfiles {
			get;
			set;
		}

		public GameInformation () {
		}

		#region ITechnolable implementation
		public void Collect (List<Technology> technologies) {
			foreach(Spell spell in this.Spells) {
				technologies.Add(technologies);
			}
			foreach(Building build in this.Buildings) {
				technologies.Add(build);
			}
			foreach(SpellSkillProfile ssp in this.SpellSkillProfiles) {
				technologies.Add(ssp);
			}
		}
		#endregion
		#region IResolvable implementation
		public void Resolve (Dictionary<Guid, Technology> dictionary) {

		}
		#endregion



	}

}