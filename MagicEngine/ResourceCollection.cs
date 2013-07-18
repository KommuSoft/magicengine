//
//  ResourceCollection.cs
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
using System.Collections;
using System.Collections.Generic;

namespace MagicEngine {

	public class ResourceCollection : IEnumerable<KeyValuePair<int,int>> {

		private readonly Dictionary<int,int> mapping = new Dictionary<int,int> ();

		public ResourceCollection () {

		}

		public void Add (int resourceindex, int value) {
			if (value >= 0x00) {
				int ori;
				if (this.mapping.TryGetValue (resourceindex, out ori)) {
					this.mapping [resourceindex] = ori + value;
				} else {
					this.mapping.Add (resourceindex, value);
				}
			} else {
				throw new ArgumentException ("Cannot add a negative amount of resources!");
			}
		}

		public bool Sufficient (int resourceindex, int value) {
			int ori;
			return (this.mapping.TryGetValue (resourceindex, out ori) && ori >= value);
		}

		public bool Sufficient (ResourceCollection collection) {
			foreach (KeyValuePair<int,int> kvp in collection) {
				if (!this.Sufficient (kvp.Key, kvp.Value)) {
					return false;
				}
			}
			return true;
		}

		private void SubChecked (int resourceindex, int value) {
			int ori;
			if (this.mapping.TryGetValue (resourceindex, out ori) && ori >= value) {
				int newval = ori - value;
				if (newval > 0x00) {
					this.mapping [resourceindex] = newval;
				} else {
					this.mapping.Remove (resourceindex);
				}
			}
		}

		public void Sub (int resourceindex, int value) {
			if (value >= 0x00) {
				int ori;
				if (this.mapping.TryGetValue (resourceindex, out ori) && ori >= value) {
					int newval = ori - value;
					if (newval > 0x00) {
						this.mapping [resourceindex] = newval;
					} else {
						this.mapping.Remove (resourceindex);
					}
				} else {
					throw new InvalidOperationException ("Cannot subtract resources: resources insufficient!");
				}
			} else {
				throw new ArgumentException ("Cannot add a negative amount of resources!");
			}
		}

		public int Value (int resourceindex) {
			int val;
			if (this.mapping.TryGetValue (resourceindex, out val)) {
				return val;
			} else {
				return 0;
			}
		}

		public void Add (ResourceCollection collection) {
			foreach (KeyValuePair<int,int> kvp in collection) {
				this.Add (kvp.Key, kvp.Value);
			}
		}

		public void Sub (ResourceCollection resourcecollection) {
			if (this.Sufficient (resourcecollection)) {
				foreach (KeyValuePair<int,int> kvp in resourcecollection) {
					this.SubChecked (kvp.Key, kvp.Value);
				}
			} else {
				throw new InvalidOperationException ("Cannot subtract resources: resources insufficient!");
			}
		}

		#region IEnumerable implementation
		System.Collections.IEnumerator IEnumerable.GetEnumerator () {
			return this.GetEnumerator ();
		}
		#endregion

		#region IEnumerable implementation
		public IEnumerator<KeyValuePair<int, int>> GetEnumerator () {
			return this.mapping.GetEnumerator ();
		}
		#endregion


	}
}

