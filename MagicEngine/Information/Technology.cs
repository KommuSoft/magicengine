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
using MagicEngine.Abstract;
using MagicEngine.Serialisation;
using System.Xml.Serialization;

namespace MagicEngine.Information {
	[XmlType ("Technology")]
	public class Technology : NameDescriptionGuidableSensitiveBase, IImage {
		[XmlElement ("Image")]
		public SerializableImage Image {
			get;
			set;
		}

		public Technology () : base () {
		}

		public Technology (Guid guid) : base (guid) {
		}

		public Technology (string name) : base (name) {
		}

		public Technology (Guid guid, string name) : base (guid, name) {
		}

		public Technology (string name, string description) : base (name, description) {
		}

		public Technology (Guid guid, string name, string description) : base (guid, name, description) {
		}

		public Technology (SerializableImage img) : base () {
			this.Image = img;
		}

		public Technology (Guid guid, SerializableImage img) : base (guid) {
			this.Image = img;
		}

		public Technology (string name, SerializableImage img) : base (name) {
			this.Image = img;
		}

		public Technology (Guid guid, string name, SerializableImage img) : base (guid, name) {
			this.Image = img;
		}

		public Technology (string name, string description, SerializableImage img) : base (name, description) {
			this.Image = img;
		}

		public Technology (Guid guid, string name, string description, SerializableImage img) : base (guid, name, description) {
			this.Image = img;
		}
	}
}

