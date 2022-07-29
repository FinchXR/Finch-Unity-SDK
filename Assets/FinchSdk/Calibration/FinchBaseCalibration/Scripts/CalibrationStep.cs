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
using System;

namespace Finch.Calibration
{
    /// <summary>
    /// Base class that describes the calibration step.
    /// </summary>
    public abstract class CalibrationStep : MonoBehaviour
    {
        /// <summary>
        /// The event invokes when calibration step ends.
        /// </summary>
        public Action OnStepEnd;

        public abstract void Invoke();
    }
}