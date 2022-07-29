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

namespace Finch.Calibration
{
    /// <summary>
    /// Describes the configuration of controllers used in application.
    /// </summary>
    public enum PlayableSet
    {
        /// <summary>
        /// Any available set from the list below.
        /// </summary>
        Any = 0,
        /// <summary>
        /// One arm 3DoF mode (one FinchRing)
        /// </summary>
        OneThreeDof = 1,
        /// <summary>
        /// Two arms 3DoF mode (two FinchRings)
        /// </summary>
        TwoThreeDof = 2,
        /// <summary>
        /// One arm 6DoF mode (one FinchTracker and one FinchRing)
        /// </summary>
        OneSixDof = 11,
        /// <summary>
        /// Two arms 6DoF mode (two FinchTrackers and two FinchRings)
        /// </summary>
        TwoSixDof = 22
    }
}
