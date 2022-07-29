// Copyright 2018 - 2022 FinchXR Ltd. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorOption
{
    public Color AnimatedColor;
    public float Timer;

    public static bool operator ==(ColorOption c1, ColorOption c2)
    {
        return c1.AnimatedColor == c2.AnimatedColor && c1.Timer == c2.Timer;
    }

    public static bool operator !=(ColorOption c1, ColorOption c2)
    {
        return c1.AnimatedColor != c2.AnimatedColor || c1.Timer != c2.Timer;
    }

    public override bool Equals(object o)
    {
        return (ColorOption)o == this;
    }

    public override int GetHashCode()
    {
        return ((object)this).GetHashCode();
    }

}

[System.Serializable]
public class AnimatedSpriteColor
{
    public Color MaskColor;
    public ColorOption[] ColorOptions;

    public Color GetColor(float time, float lerpTime, bool loop)
    {
        float sumTimer = 0;

        foreach (var i in ColorOptions)
        {
            sumTimer += i.Timer;
        }

        if (ColorOptions.Length == 0)
        {
            return Color.black;
        }

        if (ColorOptions.Length == 1)
        {
            return ColorOptions[0].AnimatedColor;
        }

        bool clearColor = true;

        if (loop)
        {
            clearColor = time % sumTimer == time;
            time %= sumTimer;
        }

        float animationTime = 0;
        int colorStart = -1;
        int colorEnd = -1;

        for (int i = 0; i < ColorOptions.Length; i++)
        {
            animationTime += ColorOptions[i].Timer;

            if (time < animationTime)
            {
                colorStart = i - 1;
                colorEnd = i;
                animationTime -= ColorOptions[i].Timer;
                break;
            }
        }

        if (colorEnd == -1)
        {
            colorStart = colorEnd = ColorOptions.Length - 1;
        }
        else if (colorStart == -1)
        {
            colorStart = loop && !clearColor ? ColorOptions.Length - 1 : 0;
        }

        float path = Mathf.Clamp01((time - animationTime) / lerpTime);

        return Color.Lerp(ColorOptions[colorStart].AnimatedColor, ColorOptions[colorEnd].AnimatedColor, path);
    }

    public static bool operator ==(AnimatedSpriteColor c1, AnimatedSpriteColor c2)
    {
        if (c1.MaskColor != c2.MaskColor || c1.ColorOptions.Length != c2.ColorOptions.Length)
        {
            return false;
        }
       
        for (int i = 0; i < c1.ColorOptions.Length; i++)
        {
            if (c1.ColorOptions[i] != c2.ColorOptions[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator !=(AnimatedSpriteColor c1, AnimatedSpriteColor c2)
    {
        return !(c1 == c2);
    }

    public override bool Equals(object o)
    {
        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprites : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer Sprite;

    public bool AnimatedOnStart = true;

    [Header("Color animation")]
    public AnimatedSpriteColor[] AnimatedColors = new AnimatedSpriteColor[0];

    public float LerpTime = 0.5f;
    public bool Loop = true;

    public bool AnimationPass { get { return animationTime >= AnimatedColors.Length * LerpTime; } }

    private Texture2D texture;
    private float animationTime;
    private const int textureSize = 3;

    [ExecuteInEditMode]
    void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
        texture = new Texture2D(textureSize, textureSize);
        Sprite.material.SetTexture("_RecTex", texture);
    }

    private void OnEnable()
    {
        ResetState(!AnimatedOnStart);
    }

    public void ResetState(bool force)
    {
        animationTime = force ? 100 : 0;
        Update();
    }

    private void Update ()
    {
        Sprite.material.SetFloat("_MaxAlpha", Sprite.color.a);
        Sprite.material.SetFloat("_MaxColors", AnimatedColors.Length);

        animationTime += Time.deltaTime;

        for (int i = 0; i < Mathf.Min(textureSize + 1, AnimatedColors.Length); i++)
        {
            texture.SetPixel(0, i, AnimatedColors[i].MaskColor);
            texture.SetPixel(1, i, AnimatedColors[i].GetColor(animationTime, LerpTime, Loop));
        }

        texture.Apply();
    }
    public void SetAnimatedColors(AnimatedSpriteColor color, bool force)
    {
        SetAnimatedColors(new AnimatedSpriteColor[] { color }, force);
    }

    public void SetAnimatedColors(AnimatedSpriteColor[] colors, bool force = false)
    {
        if (!SameAnimations(colors))
        {
            AnimatedColors = colors;
            ResetState(force);
        }
    }

    public bool SameAnimations(AnimatedSpriteColor[] colors)
    {
        if (colors.Length != AnimatedColors.Length)
        {
            return false;
        }

        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i] != AnimatedColors[i])
            {
                return false;
            }
        }

        return true;
    }
}
