using AceLand.Curve.Core;
using Unity.Scripting.LifecycleManagement;

namespace AceLand.Curve
{
    public static partial class AceCurve
    {
        public static IEasingCurveBaker Baker
        {
            get
            {
                _baker ??= EasingCurveBaker.Create();
                return _baker;
            }
        }

        [AutoStaticsCleanup]
        private static IEasingCurveBaker _baker;
    }
}