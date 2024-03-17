using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591

namespace p3rpc.nativetypes.Interfaces
{
    public interface ICommonMethods
    {
        public unsafe delegate void FMemory_Free(nint ptr);
        public unsafe delegate UUIResources* UGlobalWork_GetUUIResources();
        public unsafe delegate UGlobalWork* GetUGlobalWork();
        public unsafe delegate float FAppCalculationItem_Lerp(float source, FAppCalculationItem* values, int count, byte bIsLoop);
    }
}
