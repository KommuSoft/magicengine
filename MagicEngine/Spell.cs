//
//  Spell.cs
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
using System.Xml.Serialization;

namespace MagicEngine {

	[XmlType("Spell")]
	public class Spell {

		private string name;
		private int wavelength;

		[XmlAttribute("Name")]
		public string Name {
			get {
				return this.name;
			}
			set {
				this.name = value;
			}
		}
		[XmlAttribute("Wavelength")]
		public int Wavelength {
			get {
				return this.wavelength;
			}
			set {
				this.wavelength = Math.Max(380, Math.Min(780, value));
			}
		}

		public Spell () : this("Unknown",wavelength) {
		}
		public Spell (string name, int wavelength) {
			this.Name = "Unknown";
			this.Wavelength = wavelength;
		}

	}
}

