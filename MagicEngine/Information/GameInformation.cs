//
//  GameInformation.cs
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
using System.IO;
using System.Xml.Serialization;
using MagicEngine.Utils;

namespace MagicEngine.Information {
	[XmlRoot ("GameInformation")]
	public class GameInformation {
		[XmlArray ("Cultures")]
		[XmlArrayItem ("Culture")]
		public List<Culture> Cultures {
			get;
			set;
		}

		[XmlArray ("Technologies")]
		[XmlArrayItem ("Technology")]
		public List<Technology> Technology {
			get;
			set;
		}

		public GameInformation () {
			this.Cultures = new List<Culture> ();
			this.Technology = new List<Technology> ();
		}

		public static GameInformation ReadFromFile (string filename) {
			return StreamUtils.ReadFromFileCallBack (filename, ReadFromStream);
		}

		public static GameInformation ReadFromStream (Stream s) {
			return StreamUtils.XmlDeserialize<GameInformation> (s);
		}

		public void WriteToStream (Stream s) {
			StreamUtils.XmlSerialize<GameInformation> (s, this);
		}

		public void WriteToFile (string filename) {
			StreamUtils.WriteToFileCallBack (filename, this, StreamUtils.XmlSerialize<GameInformation>);
		}
	}
}