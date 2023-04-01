using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunctions
{
    public static float EaseInSine(float x) {
        return 1f - Mathf.Cos((x * Mathf.PI) / 2f);
    }
    public static float EaseOutSine(float x) {
        return 1f - Mathf.Sin((x * Mathf.PI) / 2f);
    }
    public static float EaseInOutSine(float x) {
        return -(Mathf.Cos(x * Mathf.PI) - 1f) / 2f;
    }

    public static float EaseInQuad(float x) {
        return x * x;
    }
    public static float EaseOutQuad(float x) {
        return 1f - (1f - x) * (1f - x);
    }
    public static float EaseInOutQuad(float x) {
        return x < 0.5f ? 2f * x * x : 1f - Mathf.Pow(-2f * x + 2f, 2f) / 2f;
    }

    public static float EaseInCubic(float x) {
        return x * x * x;
    }
    public static float EaseOutCubic(float x) {
        return 1f - Mathf.Pow(1f - x, 3f);
    }
    public static float EaseInOutCubic(float x) {
        return x < 0.5f ? 4f * x * x * x : 1f - Mathf.Pow(-2f * x + 2f, 3f) / 2f;
    }

    public static float EaseInQuart(float x) {
        return x * x * x * x;
    }
    public static float EaseOutQuart(float x) {
        return 1f - Mathf.Pow(1f - x, 4f);
    }
    public static float EaseInOutQuart(float x) {
        return x < 0.5f ? 4f * x * x * x * x: 1f - Mathf.Pow(-2f * x + 2f, 4f) / 2f;
    }

    public static float EaseInQuint(float x) {
        return x * x * x * x * x;
    }
    public static float EaseOutQuint(float x) {
        return 1f - Mathf.Pow(1f - x, 5f);
    }
    public static float EaseInOutQuint(float x) {
        return x < 0.5f ? 4f * x * x * x * x * x: 1f - Mathf.Pow(-2f * x + 2f, 5f) / 2f;
    }

    public static float EaseInExpo(float x) {
        return x == 0f ? 0f : Mathf.Pow(2f, 10f * x - 10f);
    }
    public static float EaseOutExpo(float x) {
        return x == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * x);
    }
    public static float EaseInOutExpo(float x) {
        return x == 0
            ? 0
            : x == 1
            ? 1
            : x < 0.5f ? Mathf.Pow(2f, 20f * x - 10f) / 2f
            : (2f - Mathf.Pow(2f, -20f * x + 10f)) / 2f;
    }

    public static float EaseInCirc(float x) {
        return 1f - Mathf.Sqrt(1f - Mathf.Pow(x, 2f));
    }
    public static float EaseOutCirc(float x) {
        return Mathf.Sqrt(1f - Mathf.Pow(x, 2f));
    }
    public static float EaseInOutCirc(float x) {
        return x < 0.5f
            ? (1f - Mathf.Sqrt(1f - Mathf.Pow(2f * x, 2f))) / 2f
            : (Mathf.Sqrt(1f - Mathf.Pow(-2f * x + 2f, 2f)) + 1f) / 2f;
    }

    public static float EaseInBack(float x) {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;

        return c3 * x * x * x - c1 * x * x;
    }
    public static float EaseOutBack(float x) {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;

        return 1f + c3 * Mathf.Pow(x - 1f, 3f) + c1 * Mathf.Pow(x - 1f, 2f);
    }
    public static float EaseInOutBack(float x) {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;

        return x < 0.5f
            ? (Mathf.Pow(2f * x, 2f) * ((c2 + 1f) * 2f * x - c2)) / 2f
            : (Mathf.Pow(2f * x - 2f, 2f) * ((c2 + 1f) * (x * 2f - 2f) + c2) + 2f) / 2f;
    }

    public static float EaseInElastic(float x) {
        const float c4 = (2 * Mathf.PI) / 3f;

        return x == 0
            ? 0
            : x == 1
            ? 1
            : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10f - 10.75f) * c4);
                }
    public static float EaseOutElastic(float x) {
        const float c4 = (2 * Mathf.PI) / 3f;

        return x == 0
            ? 0
            : x == 1
            ? 1
            : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10f - 0.75f) * c4) + 1;
    }
    public static float EaseInOutElastic(float x) {
        const float c5 = (2 * Mathf.PI) / 4.5f;

        return x == 0
            ? 0
            : x == 1
            ? 1
            : x < 0.5
            ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2
            : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2 + 1;
    }

    public static float EaseInBounce(float x) {
        return 1 - EaseOutBounce(1 - x);
    }
    public static float EaseOutBounce(float x) {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1 / d1) {
            return n1 * x * x;
        } else if (x < 2 / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5 / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
    public static float EaseInOutBounce(float x) {
        return x < 0.5
            ? (1 - EaseOutBounce(1 - 2 * x)) / 2
            : (1 + EaseOutBounce(2 * x - 1)) / 2;
    }
}
