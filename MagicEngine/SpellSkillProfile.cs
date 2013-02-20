//
//  SpellSkillProfile.cs
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

	using FunctionComponent = Tuple<int,double,double>;//mean,invsigma,mul

	[XmlType("SpellSkillProfile")]
	public class SpellSkillProfile : Technology {

		[XmlIgnore]
		public double this [int wavelength] {
			get {
				return CalculateSkill(wavelength);
			}
		}
		[XmlIgnore]
		public double this [Spell sp] {
			get {
				if(this.Spells.Contains(sp)) {
					return this[sp.Wavelength];
				}
				else {
					return double.NegativeInfinity;
				}
			}
		}
		[XmlArray("SkillDefinition")]
		[XmlArrayItem("SkillElement")]
		public List<GaussianFunction> Elements {
			get;
			set;
		}
		[XmlArray("Spells")]
		[XmlArrayItem("Spell")]
		public List<Guid> SpellGuids {
			get;
			set;
		}
		[XmlIgnore]
		public HashSet<Spell> Spells {
			get;
			set;
		}

		public SpellSkillProfile () {
			this.initialize();
		}
		public SpellSkillProfile (string name) : base(name) {
			this.initialize();
		}
		public SpellSkillProfile (Guid guid) : base(guid) {
			this.initialize();
		}
		public SpellSkillProfile (Guid guid, string name) : base(guid) {
			this.initialize();
		}

		private void initialize () {
			this.Spells = new HashSet<Spell>();
			this.SpellGuids = new List<Guid>();
			this.Elements = new List<GaussianFunction>();
		}

		public double CalculateSkill (int wavelength) {
			double sum = 0.0d;
			double wd = (double)wavelength;
			foreach(GaussianFunction fc in this.Elements) {
				sum += fc.Eval(wd);
			}
			return Math.Min(1.0d, sum);
		}

		public override void Resolve (Dictionary<Guid,Technology> dictionary) {
			base.Resolve(dictionary);
			foreach(Guid g in this.SpellGuids) {
				this.Spells.Add((Spell)dictionary[g]);
			}
		}

	}
}

