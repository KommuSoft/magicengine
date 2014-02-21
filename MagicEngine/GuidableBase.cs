//
//  GuidBase.cs
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

namespace MagicEngine.Information {
	public abstract class GuidableBase : IGuidable {
		[XmlAttribute ("Guid")]
		public Guid Guid {
			get;
			set;
		}

		protected GuidableBase () {
			this.Guid = Guid.NewGuid ();
		}

		protected GuidableBase (Guid guid) {
			this.Guid = guid;
		}

		public override bool Equals (object obj) {
			IGuidable other = obj as IGuidable;
			return (other != null && this.Guid == other.Guid);
		}

		public override int GetHashCode () {
			return this.Guid.GetHashCode ();
		}
	}
}

