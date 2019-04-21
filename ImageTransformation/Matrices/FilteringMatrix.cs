using System;
using System.Collections.Generic;
using ImageTransformation.Extensions;
using ImageTransformation.TransformMethods;
using Real = System.Double;

namespace ImageTransformation.Matrices
{
    public class FilteringMatrix : SquareMatrix
    {
        public const Real DefaultFactor = 1;
        public const Real DefaultBias = 0;

        public Real Factor { get; private set; }
        public Real Bias { get; private set; }

        public static readonly Real[] Brightning =
            {
                (Real)1, (Real) 0.956, (Real) 0.62,
                (Real)1, (Real)(-0.272), (Real)(-0.647),
                (Real)1, (Real)(-1.108), (Real) 1.705
            };

        private const Real SoftBlurValue = (Real)0.2;
        public static readonly Real[] SoftBlur =
            {
                0,             SoftBlurValue, 0,
                SoftBlurValue, SoftBlurValue, SoftBlurValue,
                0,             SoftBlurValue, 0
            };

        private const Real HardBlurValue = 1;
        private const Real HardBlurValue2 = 0;
        public const Real HardBlurFactor = (Real)1.0 / 13;
        public static readonly Real[] HardBlur =
            {
                HardBlurValue2, HardBlurValue2, HardBlurValue, HardBlurValue2, HardBlurValue2,
                HardBlurValue2, HardBlurValue,  HardBlurValue, HardBlurValue,  HardBlurValue2,
                HardBlurValue,  HardBlurValue,  HardBlurValue, HardBlurValue,  HardBlurValue,
                HardBlurValue2, HardBlurValue,  HardBlurValue, HardBlurValue,  HardBlurValue2,
                HardBlurValue2, HardBlurValue2, HardBlurValue, HardBlurValue2, HardBlurValue2
            };

        public const Real MotionBlurFactor = (Real)1.0 / 9;
        public static readonly Real[] MotionBlur =
            {
                1, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 1, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 1, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 1, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 1, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 1, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 1, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 1, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1
            };

        public static readonly Real[] FindHorizontalEdges =
            {
                 0, 0, 0,
                -1, 1, 0,
                 0, 0, 0
            };
        
        public static readonly Real[] FindHorizontalEdges_2 =
            {
                 0,  0, 0, 0, 0,
                 0,  0, 0, 0, 0,
                -1, -1, 2, 0, 0,
                 0,  0, 0, 0, 0,
                 0,  0, 0, 0, 0
            };

        public static readonly Real[] FindVerticalEdges =
            {
                0, -1, 0,
                0,  2, 0,
                0, -1, 0
            };
        
        public static readonly Real[] FindVerticalEdges_2 =
            {
                0, 0, -1, 0, 0,
                0, 0, -1, 0, 0,
                0, 0,  4, 0, 0,
                0, 0, -1, 0, 0,
                0, 0, -1, 0, 0
            };

        public static readonly Real[] Find45DegreeEdges =
            {
                -1,  0, 0,  0,  0,
                 0, -2, 0,  0,  0,
                 0,  0, 6,  0,  0,
                 0,  0, 0, -2,  0,
                 0,  0, 0,  0, -1
            };
        
        public static readonly Real[] SimpleEdgeDetector =
            {
                -1, -1, -1,
                -1,  8, -1,
                -1, -1, -1
            };

        public static readonly Real[] SimpleEdgeDetector_2 =
            {
                -1, -1, -1,  -1, -1,
                -1, -2, -2,  -2, -1,
                -1, -2,  32, -2, -1,
                -1, -2, -2,  -2, -1,
                -1, -1, -1,  -1, -1
            };

        public static readonly Real[] SimpleEdgeDetector_3 =
            {
                -1, -1, -1, -1,  -1, -1, -1,
                -1, -2, -2, -2,  -2, -2, -1,
                -1, -2, -4, -4,  -4, -2, -1,
                -1, -2, -4,  78, -4, -2, -1,
                -1, -2, -4, -4,  -4, -2, -1,
                -1, -2, -2, -2,  -2, -2, -1,
                -1, -1, -1, -1,  -1, -1, -1
            };

        public static readonly Real[] Sharpen =
            {
                -1, -1, -1,
                -1,  9, -1,
                -1, -1, -1
            };

        public static readonly Real[] Sharpen_2 =
            {
                -1, -1, -1,  -1, -1,
                -1, -2, -2,  -2, -1,
                -1, -2,  36, -2, -1,
                -1, -2, -2,  -2, -1,
                -1, -1, -1,  -1, -1
            };

        public static readonly Real[] Sharpen_3 =
            {
                -1, -1, -1, -1, -1, -1, -1,
                -1, -2, -2, -2, -2, -2, -1,
                -1, -2, -4, -4, -4, -2, -1,
                -1, -2, -4, 86, -4, -2, -1,
                -1, -2, -4, -4, -4, -2, -1,
                -1, -2, -2, -2, -2, -2, -1,
                -1, -1, -1, -1, -1, -1, -1
            };

        public const Real SharpenFactor = (Real)1.0 / 8;
        public static readonly Real[] Sharpen_4 =
            {
                -1, -1, -1, -1, -1,
                -1,  2,  2,  2, -1,
                -1,  2,  8,  2, -1,
                -1,  2,  2,  2, -1,
                -1, -1, -1, -1, -1
            };

        public static readonly Real[] ExcessiveEdges =
            {
                1,  1, 1,
                1, -7, 1,
                1,  1, 1
            };

        public const Real EmbossBias = 128;
        public static readonly Real[] Emboss =
            {
                -1, -1, 0,
                -1,  0, 1,
                 0,  1, 1
            };

        public static readonly Real[] Emboss_2 =
            {
                -1, -1, -1, -1, 0,
                -1, -1, -1,  0, 1,
                -1, -1,  0,  1, 1,
                -1,  0,  1,  1, 1,
                 0,  1,  1,  1, 1
            };

        public const Real MeanFactor = (Real)1.0 / 9;
        public static readonly Real[] MeanFilter =
            {
                1, 1, 1,
                1, 1, 1,
                1, 1, 1
            };

        public const Real RgbToYiqFactor = (Real)1.0 / 9;
        public static readonly Real[] RGB_to_YIQ =
            {
                (Real)0.299, (Real) 0.587, (Real) 0.114,
                (Real)0.596, (Real)(-0.275), (Real)(-0.321),
                (Real)0.212, (Real)(-0.523), (Real) 0.311
            };

        public static readonly Real[] YIQ_to_RGB =
            {
                (Real)1, (Real) 0.956, (Real) 0.62,
                (Real)1, (Real)(-0.272), (Real)(-0.647),
                (Real)1, (Real)(-1.108), (Real) 1.705
            };

        public const Real ImageColorTransformationFactor = (Real)1.0 / 9;
        public static readonly Real[] ImageColorSpaceTransformation =
            {
                (Real)1,  (Real) 0, (Real)0,
                (Real)0,  (Real) 1, (Real)0,
                (Real)40, (Real)40, (Real)1
            };

        public static readonly Real[] ImageColorSpaceTransformation_2 =
            {
                (Real)10, (Real) 0, (Real)0,
                (Real)0,  (Real)10, (Real)0,
                (Real)0,  (Real) 0, (Real)1
            };

        public FilteringMatrix(params Real[] filteringMatrix)
            : base(filteringMatrix)
        {
            Factor = DefaultFactor;
            Bias = DefaultBias;
        }

        public FilteringMatrix(Real[,] filteringMatrix)
            : base(filteringMatrix)
        {
            Factor = DefaultFactor;
            Bias = DefaultBias;
        }

        public FilteringMatrix(FilterMatrixTransformMethod filteringMatrixTransformMethod)
        {
            var transformation = filterMatrixTransformations[filteringMatrixTransformMethod];
            Factor = transformation.Factor;
            Bias = transformation.Bias;
            InitializeSquareMatrixValues(transformation.FilterMatrix);
        }

        public byte GetValue(Real value)
        {
            return (byte)(Factor * value + Bias).LimitMeWithRound(Byte.MinValue, Byte.MaxValue);
        }

        private readonly Dictionary<FilterMatrixTransformMethod, FilterMatrixWithFactorAndBias> filterMatrixTransformations
            = new Dictionary<FilterMatrixTransformMethod, FilterMatrixWithFactorAndBias>
        {
            { FilterMatrixTransformMethod.Brightning, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, Brightning) },
            { FilterMatrixTransformMethod.Emboss, new FilterMatrixWithFactorAndBias(DefaultFactor, EmbossBias, Emboss) },
            { FilterMatrixTransformMethod.Emboss_2, new FilterMatrixWithFactorAndBias(DefaultFactor, EmbossBias, Emboss_2) },
            { FilterMatrixTransformMethod.ExcessiveEdges, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, ExcessiveEdges) },
            { FilterMatrixTransformMethod.Find45DegreeEdges, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, Find45DegreeEdges) },
            { FilterMatrixTransformMethod.FindHorizontalEdges, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, FindHorizontalEdges) },
            { FilterMatrixTransformMethod.FindHorizontalEdges_2, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, FindHorizontalEdges_2) },
            { FilterMatrixTransformMethod.FindVerticalEdges, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, FindVerticalEdges) },
            { FilterMatrixTransformMethod.FindVerticalEdges_2, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, FindVerticalEdges_2) },
            { FilterMatrixTransformMethod.HardBlur, new FilterMatrixWithFactorAndBias(HardBlurFactor, DefaultBias, HardBlur) },
            { FilterMatrixTransformMethod.ImageColorSpaceTransformation, new FilterMatrixWithFactorAndBias(ImageColorTransformationFactor, DefaultBias, ImageColorSpaceTransformation) },
            { FilterMatrixTransformMethod.ImageColorSpaceTransformation_2, new FilterMatrixWithFactorAndBias(ImageColorTransformationFactor, DefaultBias, ImageColorSpaceTransformation_2) },
            { FilterMatrixTransformMethod.MeanFilter, new FilterMatrixWithFactorAndBias(MeanFactor, DefaultBias, MeanFilter) },
            { FilterMatrixTransformMethod.MotionBlur, new FilterMatrixWithFactorAndBias(MotionBlurFactor, DefaultBias, MotionBlur) },
            { FilterMatrixTransformMethod.RGB_to_YIQ, new FilterMatrixWithFactorAndBias(RgbToYiqFactor, DefaultBias, RGB_to_YIQ) },
            { FilterMatrixTransformMethod.Sharpen, new FilterMatrixWithFactorAndBias(SharpenFactor, DefaultBias, Sharpen) },
            { FilterMatrixTransformMethod.Sharpen_2, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, Sharpen_2) },
            { FilterMatrixTransformMethod.Sharpen_3, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, Sharpen_3) },
            { FilterMatrixTransformMethod.Sharpen_4, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, Sharpen_4) },
            { FilterMatrixTransformMethod.SimpleEdgeDetector, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, SimpleEdgeDetector) },
            { FilterMatrixTransformMethod.SimpleEdgeDetector_2, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, SimpleEdgeDetector_2) },
            { FilterMatrixTransformMethod.SimpleEdgeDetector_3, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, SimpleEdgeDetector_3) },
            { FilterMatrixTransformMethod.SoftBlur, new FilterMatrixWithFactorAndBias(DefaultFactor, DefaultBias, SoftBlur) },
            { FilterMatrixTransformMethod.YIQ_to_RGB, new FilterMatrixWithFactorAndBias(RgbToYiqFactor, DefaultBias, YIQ_to_RGB) }
        };
    }
}
