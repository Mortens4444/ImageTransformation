using System;
using System.Collections.Generic;
using System.Drawing;
using ImageTransformation.BitmapInformation;
using ImageTransformation.TransformMethods;

namespace ImageTransformation
{
	public class TransformatedImageFactory
	{
		private readonly Dictionary<ColorTransformMethod, Type> colorTransformators = new Dictionary<ColorTransformMethod, Type>
			{
				{ ColorTransformMethod.BlackAndWhite, typeof(BlackAndWhiteTransformator) },
				{ ColorTransformMethod.Bluescale, typeof(BluescaleTransformator) },
				{ ColorTransformMethod.BT_601_Grayscale, typeof(Bt601GrayscaleTransformator) },
				{ ColorTransformMethod.BT_609_Grayscale, typeof(Bt609GrayscaleTransformator) },
				{ ColorTransformMethod.BT_709_Grayscale, typeof(Bt709GrayscaleTransformator) },
				{ ColorTransformMethod.CMY_CM_scale, typeof(CyanMagentascaleTransformator) },
				{ ColorTransformMethod.CMY_CY_scale, typeof(CyanYellowscaleTransformator) },
				{ ColorTransformMethod.CMY_C_scale, typeof(CyanscaleTransformator) },
				{ ColorTransformMethod.CMY_MY_scale, typeof(MagentaYellowscaleTransformator) },
				{ ColorTransformMethod.CMY_M_scale, typeof(MagentascaleTransformator) },
				{ ColorTransformMethod.CMY_To_RGB, typeof(CmyToRgbTransformator) },
				{ ColorTransformMethod.CMY_Y_scale, typeof(YellowscaleTransformator) },
				{ ColorTransformMethod.Exp, typeof(ExpTransformator) },
				{ ColorTransformMethod.Grayscale_1, typeof(Grayscale1Transformator) },
				{ ColorTransformMethod.Grayscale_2, typeof(Grayscale2Transformator) },
				{ ColorTransformMethod.Grayscale_3, typeof(Grayscale3Transformator) },
				{ ColorTransformMethod.GreenBluescale, typeof(GreenBluescaleTransformator) },
				{ ColorTransformMethod.Greenscale, typeof(GreenscaleTransformator) },
				{ ColorTransformMethod.Inverse, typeof(InverseTransformator) },
				{ ColorTransformMethod.Inverse_Blue, typeof(InverseBlueTransformator) },
				{ ColorTransformMethod.Inverse_Green, typeof(InverseGreenTransformator) },
				{ ColorTransformMethod.Inverse_Green_Blue, typeof(InverseGreenBlueTransformator) },
				{ ColorTransformMethod.Inverse_Red, typeof(InverseRedTransformator) },
				{ ColorTransformMethod.Inverse_Red_Blue, typeof(InverseRedBlueTransformator) },
				{ ColorTransformMethod.Inverse_Red_Green, typeof(InverseRedGreenTransformator) },
				{ ColorTransformMethod.Normalized, typeof(NormalizedTransformator) },
				{ ColorTransformMethod.Pow, typeof(PowTransformator) },
				{ ColorTransformMethod.Random, typeof(RandomTransformator) },
				{ ColorTransformMethod.RedBluescale, typeof(RedBluescaleTransformator) },
				{ ColorTransformMethod.RedGreenscale, typeof(RedGreenscaleTransformator) },
				{ ColorTransformMethod.Redscale, typeof(RedscaleTransformator) },
				{ ColorTransformMethod.RGB_To_CMY, typeof(RgbToCmyTransformator) },
				{ ColorTransformMethod.RGB_To_YUV, typeof(RgbToYuvTransformator) },
				{ ColorTransformMethod.RMY_Grayscale, typeof(RmyGrayscaleTransformator) },
				{ ColorTransformMethod.SimpleAvarageGrayscale, typeof(SimpleAvarageGrayscaleTransformator) },
				{ ColorTransformMethod.Swap_RGB_To_BGR, typeof(SwapRgbToBgrTransformator) },
				{ ColorTransformMethod.Swap_RGB_To_BRG, typeof(SwapRgbToBrgTransformator) },
				{ ColorTransformMethod.Swap_RGB_To_GBR, typeof(SwapRgbToGbrTransformator) },
				{ ColorTransformMethod.Swap_RGB_To_GRB, typeof(SwapRgbToGrbTransformator) },
				{ ColorTransformMethod.Swap_RGB_To_RBG, typeof(SwapRgbToRbgTransformator) },
				{ ColorTransformMethod.WeightedAvarageGrayscale, typeof(WeightedAvarageGrayscaleTransformator) },
				{ ColorTransformMethod.YUV_To_RGB, typeof(YuvToRgbTransformator) },
				{ ColorTransformMethod.YUV_UV_scale, typeof(UVscaleTransformator) },
				{ ColorTransformMethod.YUV_U_scale, typeof(UscaleTransformator) },
				{ ColorTransformMethod.YUV_V_scale, typeof(VscaleTransformator) },
				{ ColorTransformMethod.YUV_YU_scale, typeof(YUscaleTransformator) },
				{ ColorTransformMethod.YUV_YV_scale, typeof(YVscaleTransformator) },
				{ ColorTransformMethod.YUV_Y_scale, typeof(YscaleTransformator) }
			};

		private readonly Dictionary<ImageTransformMethod, List<Type>> imageTransformators = new Dictionary<ImageTransformMethod, List<Type>>
			{
				{ ImageTransformMethod.DifferenceEdgeDetector, new List<Type> { typeof(DifferenceEdgeDetectorTransformator) } },
				{ ImageTransformMethod.EigCornerDetection, new List<Type> { typeof(Bt709GrayscaleTransformator), typeof(EigCornerDetectionTransformator) } },
				{ ImageTransformMethod.HarrisCornerDetection, new List<Type> { typeof(HarrisCornerDetectionTransformator) } },
				{ ImageTransformMethod.HomogenityEdgeDetector, new List<Type> { typeof(HomogenityEdgeDetectorTransformator) } },
				{ ImageTransformMethod.InverseSobelEdgeDetector, new List<Type> { typeof(Bt709GrayscaleTransformator), typeof(InverseSobelEdgeDetectorTransformator) } },
				{ ImageTransformMethod.Laplace_v1, new List<Type> { typeof(RmyGrayscaleTransformator), typeof(LaplaceV1Transformator) } },
				{ ImageTransformMethod.Laplace_v2, new List<Type> { typeof(RmyGrayscaleTransformator), typeof(LaplaceV2Transformator) } },
				{ ImageTransformMethod.ModifiedHarrisCornerDetection, new List<Type> { typeof(ModifiedHarrisCornerDetectionTransformator) } },
				{ ImageTransformMethod.MortensV1, new List<Type> { typeof(RmyGrayscaleTransformator), typeof(MortensV1Transformator) } },
				{ ImageTransformMethod.RobertsEdgeDetector, new List<Type> { typeof(RmyGrayscaleTransformator), typeof(RobertsEdgeDetectorTransformator) } },
				{ ImageTransformMethod.SobelEdgeDetector, new List<Type> { typeof(Bt709GrayscaleTransformator), typeof(SobelEdgeDetectorTransformator) } }
			};

		public Image Get(ColorTransformMethod transformationMethod, Image originalImage)
		{
			if (transformationMethod == ColorTransformMethod.Original)
			{
				return originalImage;
			}
			var transformator = Activator.CreateInstance(colorTransformators[transformationMethod], originalImage) as Transformator;
			return Transform(transformator);
		}

		public Image Get(Image originalImage, Color fromColor, Color toColor, Color replacerColor)
		{
			var transformator = new ColorReplacerTransformator(originalImage, fromColor, toColor, replacerColor);
			return Transform(transformator);
		}

		public Image Get(Image originalImage, int blockSize)
		{
			var transformator = new BlockTransformator(originalImage, blockSize);
			return Transform(transformator);
		}

		public Image Get(Image originalImage, FilterMatrixTransformMethod filterMatrixTransformMethod)
		{
			var transformator = new FilteringMatrixTransformator(originalImage, filterMatrixTransformMethod);
			return Transform(transformator);
		}
		
		public Image Get(ImageTransformMethod transformationMethod, Image originalImage)
		{
			var transormatorTypes = imageTransformators[transformationMethod];
			var image = (Image)originalImage.Clone();
			foreach (var transormatorType in transormatorTypes)
			{
				var transformator = Activator.CreateInstance(transormatorType, image) as Transformator;
				image = Transform(transformator);
			}
			return image;
		}

		private static Bitmap Transform(Transformator transformator)
		{
			transformator.Transform();
			transformator.FinalizeChangesInRgbByteArray();
			return transformator.Bitmap;
		}
	}
}
