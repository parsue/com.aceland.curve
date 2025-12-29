#nullable enable
using Unity.Collections;
using UnityEngine;

namespace AceLand.Curve
{
    public interface IEasingCurveBaker
    {
        Texture2D BuildLutTexture(
            EasingCurve curve,
            int lutSize,
            CurveLoopMode loopMode = CurveLoopMode.Clamp,
            bool linear = true
        );

        Texture2D BuildLutTexture(
            EasingCurve? curveX, EasingCurve? curveY, EasingCurve? curveZ, EasingCurve? curveW,
            int lutSize,
            CurveLoopMode loopMode = CurveLoopMode.Clamp,
            bool linear = true
        );

        NativeArray<float> BuildNativeLut(
            EasingCurve curve,
            int lutSize,
            Allocator allocator,
            CurveLoopMode loopMode = CurveLoopMode.Clamp
        );

        NativeArray<byte> BuildNativeByteLut(
            EasingCurve curve,
            int lutSize,
            Allocator allocator,
            CurveLoopMode loopMode = CurveLoopMode.Clamp
        );
        
        Texture2D BuildLutTexture(
            AnimationCurve curve,
            int lutSize,
            bool linear = true
        );

        Texture2D BuildLutTexture(
            AnimationCurve? curveX, AnimationCurve? curveY, AnimationCurve? curveZ, AnimationCurve? curveW,
            int lutSize,
            bool linear = true
        );

        NativeArray<float> BuildNativeLut(
            AnimationCurve curve,
            int lutSize,
            Allocator allocator
        );

        NativeArray<byte> BuildNativeByteLut(
            AnimationCurve curve,
            int lutSize,
            Allocator allocator
        );
    }
}