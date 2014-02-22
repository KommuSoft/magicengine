//
//  RenderElement.cs
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
using OpenTK;

namespace MagicEngine {
	public class RenderElement {
		private int vertexbuffer = -0x01;
		private Vector3d[] pos;
		private Vector3d[] nor;
		private Vector2d[] tex;
		private int[] idx;

		public RenderElement (Vector3d[] pos, Vector3d[] nor, Vector2d[] tex, int[] idx) {
			this.pos = pos;
			this.nor = nor;
			this.tex = tex;
			this.idx = idx;
		}
	}
}

