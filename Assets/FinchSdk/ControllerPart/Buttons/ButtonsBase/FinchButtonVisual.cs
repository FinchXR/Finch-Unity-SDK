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

namespace Finch
{
    /// <summary>
    /// Lights material when button pressed 
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class FinchButtonVisual : MonoBehaviour
    {
        /// <summary>
        /// Is controller primary.
        /// </summary>
        public Chirality Chirality;

        protected abstract bool isPressing { get; }

        private MeshRenderer mesh;
        private readonly Color pressedColor = Color.white;
        private readonly Color unpressedColor = Color.black;

        private void Awake()
        {
            mesh = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            mesh.material.color = isPressing ? pressedColor : unpressedColor;
        }
    }
}
