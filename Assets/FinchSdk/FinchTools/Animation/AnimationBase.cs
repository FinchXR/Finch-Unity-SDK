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

public abstract class AnimationBase : MonoBehaviour
{
    public bool IsAnimationEnd 
    { 
        get
        {
            return LoopAnimation || 
                    animationState && linearAnimationPath >= 1 || 
                   !animationState && linearAnimationPath <= 0;
        }
    }

    public AnimationCurve AnimationCurve;
    public float AnimationTime = 0.3f;
    public bool DefaultState;
    public bool LoopAnimation;

    protected bool animationState;
    protected float linearAnimationPath
    {
        get
        {
            float path = (Time.time - lastTimeChangeState) / AnimationTime;

            if (LoopAnimation)
            {
                path %= 1;
            }
            else
            {
                path = Mathf.Clamp01(path);
            }

            return animationState ? path : (1 - path);
        }
    }

    protected float curveAnimationPath
    {
        get
        {
            return AnimationCurve.Evaluate(linearAnimationPath);
        }
    }

    private float lastTimeChangeState;

    private void Awake()
    {
        lastTimeChangeState = -100;
        animationState = DefaultState;
    }

    public void SetState(bool state)
    {
        if (state != animationState)
        {
            animationState = state;
            lastTimeChangeState = Time.time;
        }
    }
}
