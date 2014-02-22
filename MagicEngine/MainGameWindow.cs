//
//  MainGameWindow.cs
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
using MagicEngine.Information;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using MagicEngine.Utils;
using System.Drawing;

namespace MagicEngine.UserInterface {
	public class MainGameWindow : GameWindow {
		private Matrix4 perspective;

		public MainGameWindow () : base (800, 600) {
			this.Title = "MagicEngine";
		}

		protected override void OnLoad (EventArgs e) {
			this.OnResize (e);
			GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			GL.Enable (EnableCap.DepthTest);
			GL.Enable (EnableCap.ColorMaterial);
			GL.Enable (EnableCap.CullFace);

			float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
			float[] mat_shininess = { 50.0f };
			float[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
			float[] light_ambient = { 0.5f, 0.5f, 0.5f, 1.0f };
 
			GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			GL.ShadeModel (ShadingModel.Smooth);
 
			GL.Material (MaterialFace.Front, MaterialParameter.Specular, mat_specular);
			GL.Material (MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);
			GL.Light (LightName.Light0, LightParameter.Position, light_position);
			GL.Light (LightName.Light0, LightParameter.Ambient, light_ambient);
			GL.Light (LightName.Light0, LightParameter.Diffuse, mat_specular);
 
			GL.Enable (EnableCap.Lighting);
			GL.Enable (EnableCap.Light0);
			GL.Enable (EnableCap.DepthTest);
			GL.Enable (EnableCap.ColorMaterial);
			GL.Enable (EnableCap.CullFace);

			base.OnLoad (e);
		}

		protected override void OnRenderFrame (FrameEventArgs e) {
			base.OnRenderFrame (e);
			GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.LoadIdentity ();
			GL.Translate (0.0d, 0.0d, -3.0d);
			GL.Begin (BeginMode.Quads);
			GL.Normal3 (0.0d, 0.0d, 1.0d);
			uint c;
			double dx = 1.0d / 215.0d;
			for (int i = 350, j = -215; i < 780; i++,j++) {
				c = ColorUtils.FromWavelength (i);
				GL.Color3 ((byte)(c >> 0x10), (byte)((c >> 0x08) & 0xff), (byte)(c & 0xff));
				GL.Vertex3 (dx * j, -0.5d, 0.25d);
				GL.Vertex3 (dx * j + dx, -0.5d, 0.25d);
				GL.Vertex3 (dx * j + dx, 0.5d, 0.25d);
				GL.Vertex3 (dx * j, 0.5d, 0.25d);
			}
			GL.End ();
			GL.Flush ();
			this.SwapBuffers ();
		}

		protected override void OnResize (EventArgs e) {
			int w = this.Width;
			int h = this.Height;
			double ratio = (double)w / h;
			GL.MatrixMode (MatrixMode.Projection);
			this.perspective = Matrix4.CreatePerspectiveFieldOfView ((float)(Math.PI / 3.0d), (float)ratio, 1.0f, 1000.0f);
			GL.LoadIdentity ();
			GL.MultMatrix (ref perspective);
			GL.MatrixMode (MatrixMode.Modelview);
			GL.Viewport (0, 0, w, h);
			base.OnResize (e);
		}

		public static int Main (string[] args) {
			return 0x00;
		}
	}
}

