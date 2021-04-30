﻿using System;
using System.Threading.Tasks;
using DecimalMath;
using NumSharp.Utilities;

namespace NumSharp.Backends
{
    public partial class DefaultEngine
    {
        public override NDArray Tan(in NDArray nd, Type dtype) => Tan(nd, dtype?.GetTypeCode());

        public override NDArray Tan(in NDArray nd, NPTypeCode? typeCode = null)
        {
            if (nd.size == 0)
                return nd.Clone();

            var @out = Cast(nd, ResolveUnaryReturnType(nd, typeCode), copy: true);
            var len = @out.size;

            unsafe
            {
                switch (@out.GetTypeCode)
                {
#if _REGEN
                    %foreach except(supported_numericals, "Decimal"),except(supported_numericals_lowercase, "decimal")%
	                case NPTypeCode.#1:
	                {
                        var out_addr = (#2*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.To#1(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                %
                    case NPTypeCode.Decimal:
	                {
                        var out_addr = (decimal*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = (DecimalEx.Tan(out_addr[i])));
                        return @out;
	                }
	                default:
		                throw new NotSupportedException();
#else
	                case NPTypeCode.Byte:
	                {
                        var out_addr = (byte*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToByte(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Int16:
	                {
                        var out_addr = (short*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToInt16(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.UInt16:
	                {
                        var out_addr = (ushort*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToUInt16(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Int32:
	                {
                        var out_addr = (int*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToInt32(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.UInt32:
	                {
                        var out_addr = (uint*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToUInt32(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Int64:
	                {
                        var out_addr = (long*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToInt64(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.UInt64:
	                {
                        var out_addr = (ulong*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToUInt64(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Char:
	                {
                        var out_addr = (char*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToChar(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Double:
	                {
                        var out_addr = (double*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToDouble(Math.Tan(out_addr[i])));
                        return @out;
	                }
	                case NPTypeCode.Single:
	                {
                        var out_addr = (float*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = Converts.ToSingle(Math.Tan(out_addr[i])));
                        return @out;
	                }
                    case NPTypeCode.Decimal:
	                {
                        var out_addr = (decimal*)@out.Address;
                        Parallel.For(0, len, i => out_addr[i] = (DecimalEx.Tan(out_addr[i])));
                        return @out;
	                }
	                default:
		                throw new NotSupportedException();
#endif
                }
            }
        }
    }
}
