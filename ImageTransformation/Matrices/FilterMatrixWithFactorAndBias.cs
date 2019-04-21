using System;
using Real = System.Double;

namespace ImageTransformation
{
    public class FilterMatrixWithFactorAndBias
    {
        public Real Factor { get; private set; }

        public Real Bias { get; private set; }

        public Real[] FilterMatrix { get; private set; }

        public FilterMatrixWithFactorAndBias(Real factor, Real bias, Real[] filterMatrix)
        {
            Factor = factor;
            Bias = bias;
            FilterMatrix = filterMatrix;
        }
    }
}
