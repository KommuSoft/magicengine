//
//  DNFormula.cs
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

	[XmlType("DNFormula")]
	public class DNFormula<T> : ISatisfiedWithSet<T> {

		[XmlArray("Clauses")]
		[XmlArrayItem("Clause")]
		public List<AndFormula<T>> Clauses {
			get;
			set;
		}

		public DNFormula () : this(new T[0x00]) {
		}
		public DNFormula (params AndFormula<T>[] andFormulas) {
		}
		public DNFormula (IEnumerable<AndFormula<T>> andFormulas) {
			this.Clauses = new List<AndFormula<T>>();
			this.Clauses.AddRange(andFormulas);
		}

		#region ISatisfiedWithSet implementation
		public bool SatisfiedWithSet (ICollection<T> collection) {
			if(this.Clauses.Count <= 0x00) {
				return true;
			}
			foreach(AndFormula<T> af in this.Clauses) {
				if(af.SatisfiedWithSet(collection)) {
					return true;
				}
			}
			return false;
		}
		#endregion


	}
}

