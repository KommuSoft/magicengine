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
using System.Xml.Serialization;

namespace MagicEngine.Information {

	[XmlType("ResourceCollection")]
	public class ResourceCollection : IEnumerable<KeyValuePair<Guid,long>> {

		[XmlArray("Elements")]
		[XmlArrayItem("Element")]
		public Dictionary<Guid,long> Mapping {
			get;
			set;
		}

		public ResourceCollection () {
			this.Mapping = new Dictionary<Guid, long>();
		}

		public void Add (Resource resource, int value) {
			this.Add (resource.Guid, value);
		}

		public void Add (Guid resourceindex, long value) {
			if (value >= 0x00) {
				long ori;
				if (this.Mapping.TryGetValue (resourceindex, out ori)) {
					this.Mapping [resourceindex] = ori + value;
				} else {
					this.Mapping.Add (resourceindex, value);
				}
			} else {
				throw new ArgumentException ("Cannot add a negative amount of resources!");
			}
		}

		public bool Sufficient (Resource resource, long value) {
			return this.Sufficient (resource.Guid, value);
		}

		public bool Sufficient (Guid resourceindex, long value) {
			long ori;
			return (this.Mapping.TryGetValue (resourceindex, out ori) && ori >= value);
		}

		public bool Sufficient (ResourceCollection collection) {
			foreach (KeyValuePair<Guid,long> kvp in collection) {
				if (!this.Sufficient (kvp.Key, kvp.Value)) {
					return false;
				}
			}
			return true;
		}

		private void SubChecked (Resource resource, long value) {
			this.SubChecked (resource.Guid, value);
		}

		private void SubChecked (Guid resourceindex, long value) {
			long ori;
			if (this.Mapping.TryGetValue (resourceindex, out ori) && ori >= value) {
				long newval = ori - value;
				if (newval > 0x00) {
					this.Mapping [resourceindex] = newval;
				} else {
					this.Mapping.Remove (resourceindex);
				}
			}
		}

		public void Sub (Resource resource, long value) {
			this.Sub (resource.Guid, value);
		}

		public void Sub (Guid resourceindex, long value) {
			if (value >= 0x00) {
				long ori;
				if (this.Mapping.TryGetValue (resourceindex, out ori) && ori >= value) {
					long newval = ori - value;
					if (newval > 0x00) {
						this.Mapping [resourceindex] = newval;
					} else {
						this.Mapping.Remove (resourceindex);
					}
				} else {
					throw new InvalidOperationException ("Cannot subtract resources: resources insufficient!");
				}
			} else {
				throw new ArgumentException ("Cannot add a negative amount of resources!");
			}
		}

		public long Value (Resource resource) {
			return this.Value (resource.Guid);
		}

		public long Value (Guid resourceindex) {
			long val;
			if (this.Mapping.TryGetValue (resourceindex, out val)) {
				return val;
			} else {
				return 0x00;
			}
		}

		public void Add (ResourceCollection collection) {
			foreach (KeyValuePair<Guid,long> kvp in collection) {
				this.Add (kvp.Key, kvp.Value);
			}
		}

		public void Sub (ResourceCollection resourcecollection) {
			if (this.Sufficient (resourcecollection)) {
				foreach (KeyValuePair<Guid,long> kvp in resourcecollection) {
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

		public IEnumerator<KeyValuePair<Guid, long>> GetEnumerator () {
			return this.Mapping.GetEnumerator ();
		}

		#endregion

	}
}

