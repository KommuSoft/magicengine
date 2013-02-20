//
//  Technology.cs
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

	public class Technology : GuidBase, IResolvable<Guid,Technology>, ITechnolable, ISatisfiedWithSet<Guid> {

		[XmlAttribute("Name")]
		public string Name {
			get;
			set;
		}

		public DNFormula<Guid> Prerequirements {
			get;
			set;
		}

		public Technology () {
			this.Prerequirements = new DNFormula<Guid>();
		}
		public Technology (string name) : this() {
			this.Name = name;
		}
		public Technology (Guid guid, string name) : base(guid) {
			this.Name = name;
			this.Prerequirements = new DNFormula<Guid>();
		}
		public Technology (Guid guid) : base(guid) {
			this.Prerequirements = new DNFormula<Guid>();
		}

		#region IResolvable implementation
		public virtual void Resolve (Dictionary<Guid,Technology> dictionary) {
			if(this.Prerequirements == null) {
				this.Prerequirements = new DNFormula<Guid>();
			}
		}
		#endregion
		#region ITechnolable implementation
		public virtual void Collect (List<Technology> technologies) {
		}
		#endregion

		#region ISatisfiedWithSet implementation
		public bool SatisfiedWithSet (ICollection<Guid> collection) {
			return this.Prerequirements.SatisfiedWithSet(collection);
		}
		#endregion


	}
}

