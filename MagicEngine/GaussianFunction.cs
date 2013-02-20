//
//  GaussianFunction.cs
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

	[XmlType("GaussianFunction")]
	public class GaussianFunction {

		[XmlAttribute("Mu")]
		public double Mu {
			get;
			set;
		}
		[XmlAttribute("SigmaInv")]
		public double SigmaInv {
			get;
			set;
		}
		[XmlAttribute("Weight")]
		public double Weight {
			get;
			set;
		}

		public GaussianFunction () : this(0.0d,1.0d,0.0d) {
		}
		public GaussianFunction (double mu, double sigmainv, double weight) {
			this.Mu = mu;
			this.SigmaInv = sigmainv;
			this.Weight = weight;
		}

		public double Eval (double x) {
			double zx = (x-Mu)*SigmaInv;
			return Math.Exp(-0.5d*zx*zx)*SigmaInv*Weight*Maths.InvSqrt2PI;
		}

	}
}

