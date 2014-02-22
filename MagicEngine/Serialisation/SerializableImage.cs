using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Drawing.Imaging;

namespace MagicEngine.Serialisation {
	[XmlType ("SerializableImage")]
	public class SerializableImage {
		[XmlIgnore]
		public Image Bitmap {
			get;
			set;
		}

		[XmlIgnore]
		public string TextualRepresentation {
			get {
				if (this.Bitmap != null) {
					using (MemoryStream ms = new MemoryStream ()) {
						this.Bitmap.Save (ms, ImageFormat.Png);
						return Convert.ToBase64String (ms.ToArray ());
					}
				} else {
					return null;
				}
			}
			set {
				if (value != null) {
					byte[] byteData = Convert.FromBase64String (value);
					MemoryStream ms = new MemoryStream (byteData, 0, byteData.Length);
					ms.Write (byteData, 0, byteData.Length);
					this.Bitmap = Image.FromStream (ms);
				} else {
					this.Bitmap = null;
				}
			}
		}

		public SerializableImage () : this (null) {
		}

		public SerializableImage (Image image) {
			this.Bitmap = image;
		}
	}
}

