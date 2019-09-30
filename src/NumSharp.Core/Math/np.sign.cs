﻿using System;
using NumSharp.Backends;

namespace NumSharp
{
    public static partial class np
    {
        /// <summary>
        ///     Compute tangent element-wise. <br></br>
        ///     Equivalent to np.sin(x)/np.cos(x) element-wise.
        /// </summary>
        /// <param name="x">Angle, in radians (2 \pi rad equals 360 degrees).</param>
        /// <param name="outType">The dtype the returned ndarray should be of, only non integer values are supported.</param>
        /// <returns>The sine of each element of x. This is a scalar if x is a scalar.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.tan.html</remarks>
        public static NDArray sign(in NDArray x, NPTypeCode? outType = null)
            => x.TensorEngine.Sign(x, outType);

        /// <summary>
        ///     Trigonometric sine, element-wise.
        /// </summary>
        /// <param name="x">Angle, in radians (2 \pi rad equals 360 degrees).</param>
        /// <param name="outType">The dtype the returned ndarray should be of, only non integer values are supported.</param>
        /// <returns>The sine of each element of x. This is a scalar if x is a scalar.</returns>
        /// <remarks>https://docs.scipy.org/doc/numpy/reference/generated/numpy.tan.html</remarks>
        public static NDArray sign(in NDArray x, Type outType) 
            => x.TensorEngine.Sign(x, outType);
    }
}
