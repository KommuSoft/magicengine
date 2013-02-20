//
//  Utils.cs
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
using System.IO;
using System.Xml.Serialization;

namespace MagicEngine {

	public static class Utils {

		public static T ReadFromFileCallBack<T> (string filename, Func<Stream,T> callback) {
			FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);
			T result = callback(fs);
			fs.Close();
			return result;
		}
		public static void WriteToFileCallBack<T> (string filename, T val, Action<Stream,T> callback) {
			FileStream fs = File.Open(filename, FileMode.Create, FileAccess.Write);
			callback(fs, val);
			fs.Close();
		}
		public static T XmlDeserialize<T> (Stream s) {
			XmlSerializer ser = new XmlSerializer(typeof(T));
			return (T)ser.Deserialize(s);
		}
		public static void XmlSerialize<T> (Stream s, T val) {
			XmlSerializer ser = new XmlSerializer(typeof(T));
			ser.Serialize(s, val);
		}

	}

}

