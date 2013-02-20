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
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.IO;

using MagicEngine.Information;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform;

/*using OOGL.Animation;
using OOGL.Shaders;
using OOGL.Textures;
using OOGL;

using OOGL.GUI;
using OOGL.GUI.Abstract;
using OOGL.GUI.VertexStructures;*/

namespace MagicEngine.UserInterface {

	public class MainGameWindow : GameWindow {

		private Matrix4 perspective;
		private double time = 0.0d;
		/*private Model model;
		private Controller controller;*/

		public MainGameWindow () : base(800,600) {
			this.Title = "MagicEngine";
		}

		protected override void OnLoad (EventArgs e) {
			this.OnResize(e);
			GL.ClearColor(Color.SkyBlue);
			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.ColorMaterial);
			GL.Enable(EnableCap.CullFace);

			float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
			float[] mat_shininess = { 50.0f };
			float[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
			float[] light_ambient = { 0.5f, 0.5f, 0.5f, 1.0f };
 
			GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
			GL.ShadeModel(ShadingModel.Smooth);
 
			GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
			GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);
			GL.Light(LightName.Light0, LightParameter.Position, light_position);
			GL.Light(LightName.Light0, LightParameter.Ambient, light_ambient);
			GL.Light(LightName.Light0, LightParameter.Diffuse, mat_specular);
 
			GL.Enable(EnableCap.Lighting);
			GL.Enable(EnableCap.Light0);
			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.ColorMaterial);
			GL.Enable(EnableCap.CullFace);

			/*Ms3dLoader.File ms3dFile = new Ms3dLoader.File(ResourceLocator.GetFullPath("Models/Beta_Kamujin/Beta_Kamujin.ms3d"));
			Sample[] tracks = Sample.Load(ResourceLocator.GetFullPath("Models/Beta_Kamujin/Beta_Kamujin.animations"));
			ShaderProgram modelShader = new ShaderProgram(ResourceLocator.GetFullPath("Shaders/skeletalAnimation.vs"), ResourceLocator.GetFullPath("Shaders/skeletalAnimation.fs"));
			this.model = ms3dFile.ToModel(modelShader, tracks);
			ths.controller = new Controller(model);*/

			base.OnLoad(e);
		}

		protected override void OnRenderFrame (FrameEventArgs e) {
			base.OnRenderFrame(e);
			GL.Clear(ClearBufferMask.ColorBufferBit|ClearBufferMask.DepthBufferBit);
			GL.LoadIdentity();
			time += 30.0d*e.Time;
			GL.Translate(0.0d, 0.0d, -3.0d);
			//GL.Rotate(time, 0.0d, 1.0d, 0.0d);
			//GL.Rotate(0.1d*time, 1.0d, 0.0d, 0.0d);
			GL.Begin(BeginMode.Quads);
			GL.Normal3(0.0d, 0.0d, 1.0d);
			uint c;
			//GL.Color3(Color.Goldenrod);
			double dx = 1.0d/215.0d;
			for(int i = 350, j = -215; i < 780; i++,j++) {
				c = ColorUtils.FromWavelength(i);
				GL.Color3((byte)(c>>0x10), (byte)((c>>0x08)&0xff), (byte)(c&0xff));
				GL.Vertex3(dx*j, -0.5d, 0.25d);
				//ColorUtils.FromWavelength(i+1);
				//GL.Color3(ref c);
				GL.Vertex3(dx*j+dx, -0.5d, 0.25d);
				GL.Vertex3(dx*j+dx, 0.5d, 0.25d);
				//c = ColorUtils.FromWavelength(i);
				//GL.Color3(ref c);
				GL.Vertex3(dx*j, 0.5d, 0.25d);
			}//*/
			/*double r = 0.25d;
			double s = -0.25d;
			GL.Color3(Color.Goldenrod);
			GL.Normal3(0.0d, 0.0d, 1.0d);
			GL.Vertex3(s, s, r);
			GL.Vertex3(r, s, r);
			GL.Vertex3(r, r, r);
			GL.Vertex3(s, r, r);
			GL.Color3(Color.CadetBlue);
			GL.Normal3(0.0d, 1.0d, 0.0d);
			GL.Vertex3(s, r, r);
			GL.Vertex3(r, r, r);
			GL.Vertex3(r, r, s);
			GL.Vertex3(s, r, s);
			GL.Color3(Color.BlueViolet);
			GL.Normal3(1.0d, 0.0d, 0.0d);
			GL.Vertex3(r, r, s);
			GL.Vertex3(r, r, r);
			GL.Vertex3(r, s, r);
			GL.Vertex3(r, s, s);

			GL.Color3(Color.DarkOliveGreen);
			GL.Normal3(0.0d, 0.0d, -1.0d);
			GL.Vertex3(s, r, s);
			GL.Vertex3(r, r, s);
			GL.Vertex3(r, s, s);
			GL.Vertex3(s, s, s);
			GL.Color3(Color.IndianRed);
			GL.Normal3(0.0d, -1.0d, 0.0d);
			GL.Vertex3(s, s, s);
			GL.Vertex3(r, s, s);
			GL.Vertex3(r, s, r);
			GL.Vertex3(s, s, r);
			GL.Color3(Color.PapayaWhip);
			GL.Normal3(-1.0d, 0.0d, 0.0d);
			GL.Vertex3(s, s, s);
			GL.Vertex3(s, s, r);
			GL.Vertex3(s, r, r);
			GL.Vertex3(s, r, s);//*/
			GL.End();
			/*model.Draw(controller, 0.025f, Matrix4.Rotate(Vector3.UnitY, Functions.PIF));*/
			GL.Flush();
			this.SwapBuffers();
		}

		protected override void OnResize (EventArgs e) {
			int w = this.Width;
			int h = this.Height;
			double ratio = (double)w/h;
			GL.MatrixMode(MatrixMode.Projection);
			this.perspective = Matrix4.Perspective((float)(Math.PI/3.0d), (float)ratio, 1.0f, 1000.0f);
			GL.LoadIdentity();
			GL.MultMatrix(ref perspective);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.Viewport(0, 0, w, h);
			base.OnResize(e);
		}

		public static int Main (string[] args) {
			GameInformation gi = new GameInformation();
			using(MainGameWindow mgw = new MainGameWindow()) {
				mgw.Run();
			}
			return 0x00;
		}

	}
}

