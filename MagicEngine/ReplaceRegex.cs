//
//  ReplaceRegex.cs
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
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace MagicEngine {

	[XmlType("ReplaceRegex")]
	public class ReplaceRegex {

		private string source;
		private string drain;

		[XmlAttribute("Source")]
		public string Source {
			get {
				return this.source;
			}
			set {
				this.source = value;
			}
		}

		[XmlAttribute("Drain")]
		public string Drain {
			get {
				return this.drain;
			}
			set {
				this.drain = value;
			}
		}

		public ReplaceRegex () {
		}

		public ReplaceRegex (string source, string drain) {
			this.Source = source;
			this.Drain = drain;
		}

		public string Replace (string input) {
			return Regex.Replace (input, source, drain);
		}

	}
}

