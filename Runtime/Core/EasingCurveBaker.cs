using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace AceLand.Curve.Core
{
    internal class EasingCurveBaker : IEasingCurveBaker
    {
        internal static EasingCurveBaker Create() => new();
        private EasingCurveBaker() {}
        
        public Texture2D BuildLutTexture(
            EasingCurve curve,
            int lutSize,
            CurveLoopMode loopMode = CurveLoopMode.Clamp,
            bool linear = true
        )
        {
            if (lutSize<= 1) lutSize= 2;

            var tex = new Texture2D(1, lutSize, TextureFormat.R8, mipChain: false, linear)
            {
                wrapMode = TextureWrapMode.Clamp,
                filterMode = FilterMode.Bilinear
            };

            var lutBytes = new byte[lutSize];
            for (var i = 0; i < lutSize; i++)
            {
                var t = (float)i / (lutSize- 1);
                var y = curve.Evaluate(t, loopMode);
                lutBytes[i] = (byte)Mathf.RoundToInt(y * 255f);
            }

            tex.SetPixelData(lutBytes, 0);
            tex.Apply(updateMipmaps: false, makeNoLongerReadable: false);
            return tex;
        }
        
        public Texture2D BuildLutTexture(
            EasingCurve? curveX, EasingCurve? curveY, EasingCurve? curveZ, EasingCurve? curveW,
            int lutSize,
            CurveLoopMode loopMode = CurveLoopMode.Clamp,
            bool linear = true
        )
        {
            if (lutSize <= 1) lutSize= 2;

            var tex = new Texture2D(1, lutSize, TextureFormat.ARGB32, mipChain: false, linear)
            {
                wrapMode = TextureWrapMode.Clamp,
                filterMode = FilterMode.Bilinear
            };

            var pixels = new Color[lutSize];
            for (var i = 0; i < lutSize; i++)
            {
                var t = (float)i / (lutSize- 1);
                var r = curveX?.Evaluate(t, loopMode) ?? 0;
                var g = curveY?.Evaluate(t, loopMode) ?? 0;
                var b = curveZ?.Evaluate(t, loopMode) ?? 0;
                var a = curveW?.Evaluate(t, loopMode) ?? 0;
                pixels[i] = new Color(r, g, b, a);
            }

            tex.SetPixelData(pixels, 0);
            tex.Apply(updateMipmaps: false, makeNoLongerReadable: false);
            return tex;
        }
        
        public NativeArray<float> BuildNativeLut(
            EasingCurve curve,
            int lutSize,
            Allocator allocator,
            CurveLoopMode loopMode = CurveLoopMode.Clamp
        )
        {
            if (lutSize<= 1) lutSize= 2;

            var lut = new NativeArray<float>(lutSize, allocator, NativeArrayOptions.UninitializedMemory);

            for (var i = 0; i < lutSize; i++)
            {
                var t = (float)i / (lutSize- 1);
                var b = curve.Evaluate(t, loopMode);
                lut[i] = b;
            }

            return lut;
        }

        public NativeArray<byte> BuildNativeByteLut(
            EasingCurve curve,
            int lutSize,
            Allocator allocator,
            CurveLoopMode loopMode = CurveLoopMode.Clamp
        )
        {
            if (lutSize<= 1) lutSize= 2;

            var lut = new NativeArray<byte>(lutSize, allocator, NativeArrayOptions.UninitializedMemory);
            for (var i = 0; i < lutSize; i++)
            {
                var t = (float)i / (lutSize- 1);
                var y = curve.Evaluate(t, loopMode);
                lut[i] = (byte)math.round(y * 255f);
            }
            return lut;
        }
    }
}