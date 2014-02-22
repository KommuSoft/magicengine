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

namespace MagicEngine.Information {
	public class Technology : NameGuidableBase {
		protected Technology () : base () {
		}

		protected Technology (Guid guid) : base (guid) {
		}

		protected Technology (string name) : base (name) {
		}

		protected Technology (Guid guid, string name) : base (guid, name) {
		}
	}
}

