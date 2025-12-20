using AceLand.Curve.Core;

namespace AceLand.Curve
{
    public static class AceCurve
    {
        public static IEasingCurveBaker Baker
        {
            get
            {
                _baker ??= EasingCurveBaker.Create();
                return _baker;
            }
        }

        private static IEasingCurveBaker _baker;
    }
}