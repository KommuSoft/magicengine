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
using MagicEngine.Abstract;

namespace MagicEngine.Information {
	[XmlType ("Spell")]
	public class Spell : NameGuidableBase {
		private int wavelength;

		[XmlAttribute ("DescriptiveName")]
		public string DescriptiveName {
			get;
			set;
		}

		[XmlAttribute ("Pronunciation")]
		public string Pronunciation {
			get;
			set;
		}

		[XmlAttribute ("Description")]
		public string Description {
			get;
			set;
		}

		[XmlAttribute ("Wavelength")]
		public int Wavelength {
			get {
				return this.wavelength;
			}
			set {
				this.wavelength = Math.Max (350, Math.Min (780, value));
			}
		}

		public Spell () : this ("Unknown", 580) {
		}

		public Spell (string name, int wavelength) : base (name) {
			this.Wavelength = wavelength;
		}

		public Spell (string name, int wavelength, string pronunciation) : this (name, wavelength) {
			this.Pronunciation = pronunciation;
		}

		public Spell (string name, int wavelength, string pronunciation, string descriptiveName) : this (name, wavelength, pronunciation) {
			this.DescriptiveName = descriptiveName;
		}

		public Spell (string name, int wavelength, string pronunciation, string descriptiveName, string description) : this (name, wavelength, pronunciation, descriptiveName) {
			this.Description = description;
		}
	}
}

