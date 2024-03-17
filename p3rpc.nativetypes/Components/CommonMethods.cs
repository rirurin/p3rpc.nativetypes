using p3rpc.nativetypes.Interfaces;
using SharedScans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.nativetypes.Components
{
    internal class CommonMethods
    {
        private string FMemory_Free_SIG = "E8 ?? ?? ?? ?? 48 8B 4D ?? 4C 8B BC 24 ?? ?? ?? ?? 48 85 C9 74 ?? E8 ?? ?? ?? ?? 4C 8B A4 24 ?? ?? ?? ??";
        private string UGlobalWork_GetUUIResources_SIG = "E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? B2 20";
        private string GetUGlobalWork_SIG = "48 89 5C 24 ?? 57 48 83 EC 20 48 8B 0D ?? ?? ?? ?? 33 DB";
        private string FAppCalculationItem_Lerp_SIG = "E8 ?? ?? ?? ?? 8B 86 ?? ?? ?? ?? F3 44 0F 58 C0";
        protected string FUObjectArray_SIG = "48 8B 05 ?? ?? ?? ?? 48 8B 0C ?? 48 8D 04 ?? 48 85 C0 74 ?? 44 39 40 ?? 75 ?? F7 40 ?? 00 00 00 30 75 ?? 48 8B 00";
        protected string FGlobalNamePool_SIG = "4C 8D 05 ?? ?? ?? ?? EB ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B C0 C6 05 ?? ?? ?? ?? 01 48 8B 44 24 ?? 48 8B D3 48 C1 E8 20 8D 0C ?? 49 03 4C ?? ?? E8 ?? ?? ?? ?? 48 8B C3";
        public CommonMethods(ISharedScans scans)
        {
            scans.AddScan<ICommonMethods.FMemory_Free>(FMemory_Free_SIG);
            scans.AddScan<ICommonMethods.UGlobalWork_GetUUIResources>(UGlobalWork_GetUUIResources_SIG);
            scans.AddScan<ICommonMethods.GetUGlobalWork>(GetUGlobalWork_SIG);
            scans.AddScan<ICommonMethods.FAppCalculationItem_Lerp>(FAppCalculationItem_Lerp_SIG);
            scans.AddScan("FUObjectArray", FUObjectArray_SIG);
            scans.AddScan("FGlobalNamePool", FGlobalNamePool_SIG);
        }
    }
}
