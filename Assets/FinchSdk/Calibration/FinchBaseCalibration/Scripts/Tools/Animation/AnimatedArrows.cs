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

namespace Finch.Calibration.Tools
{
    /// <summary>
    /// Animation for arrows in calibration steps.
    /// </summary>
    public class AnimatedArrows : MonoBehaviour
    {
        public SpriteRenderer[] Sprites = new SpriteRenderer[0];
        public float TimeShow = 0.5f;
        public Color ActiveColor = Color.white;
        public Color DisableColor = Color.white;

        private float timeInit;

        private void OnEnable()
        {
            timeInit = Time.time;
        }

        void Update()
        {
            if (Sprites.Length > 0)
            {
                int idActive = (int)((Time.time - timeInit) / TimeShow) % Sprites.Length;

                for (int i = 0; i < Sprites.Length; i++)
                {
                    Sprites[i].color = i == idActive ? ActiveColor : DisableColor;
                }
            }
        }
    }
}