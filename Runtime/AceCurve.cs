using AceLand.Curve.Core;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#else
using UnityEngine;
#endif

namespace AceLand.Curve
{
#if UNITY_6000_5_OR_NEWER
    public static partial class AceCurve
#else
    public static class AceCurve
#endif
    {
        public static IEasingCurveBaker Baker
        {
            get
            {
                _baker ??= EasingCurveBaker.Create();
                return _baker;
            }
        }

#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private static IEasingCurveBaker _baker;
        
#if !UNITY_6000_5_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void ClearStatic()
        {
            _baker = null;
        }
#endif
    }
}