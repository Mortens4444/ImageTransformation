﻿using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class VscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public VscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public VscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public VscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public VscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + RedIndex], this[i + GreenIndex], this[i], ColorSpaceType.RGB);
                this[i] = componentValue;
                this[i + GreenIndex] = componentValue;
                var y = this[i + RedIndex] - yuvColor.Y;
                var value = (y < 0) ? (byte)(Byte.MaxValue + y) : (byte)y;
                this[i + RedIndex] = value;
            }
        }
    }
}