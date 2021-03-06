//
//  AndFormula.cs
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

	[XmlType("AndFormula")]
	public class AndFormula<T> : ISatisfiedWithSet<T> {

		[XmlArray("Items")]
		[XmlArrayItem("Item")]
		public List<T> Items {
			get;
			set;
		}

		public AndFormula () : this (new T[0x00]) {
		}
		public AndFormula (params T[] items) : this((IEnumerable<T>) items) {
		}
		public AndFormula (IEnumerable<T> items) {
			this.Items = new List<T>();
			this.Items.AddRange(items);
		}

		#region ISatisfiedWithSet implementation
		public bool SatisfiedWithSet (ICollection<T> collection) {
			foreach(T item in this.Items) {
				if(!collection.Contains(item)) {
					return false;
				}
			}
			return true;
		}
		#endregion


	}
}

