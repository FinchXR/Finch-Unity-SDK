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
using Finch.Internal;

namespace Finch
{
    /// <summary>
    /// Describes type of the controller.
    /// </summary>
    public enum ControllerType : byte
    {
        /// <summary>3DoF and 6DoF FinchShift controller.</summary>
        Shift = FinchCore.Finch_ControllerType.Shift,
        Ring = FinchCore.Finch_ControllerType.Ring,
        ShiftOptic = 4,
        RingOptic = 5
    }

    /// <summary>
    /// Data update type, according to HMD device type.
    /// </summary>
    public enum UpdateType : byte
    {
        /// <summary>
        /// Only rotation is used for tracking.
        /// </summary>
        HmdRotation = FinchCore.Finch_UpdateOption.Internal | FinchCore.Finch_UpdateOption.HmdOrientation,

        /// <summary>
        /// Both position and rotation are used for tracking. Use this option if you have headset that allows head tracking (for example, HTC Vive).
        /// </summary>
        HmdTransform = FinchCore.Finch_UpdateOption.Internal | FinchCore.Finch_UpdateOption.HmdOrientation | Internal.FinchCore.Finch_UpdateOption.HmdPosition
    }

    /// <summary>
    /// Events of controller touchpad.
    /// </summary>
    public enum TouchpadEvents
    {
        /// <summary>
        /// Swipe up on the FinchRing or FinchTracker touchpad.
        /// </summary>
        SwipeUp = 0,

        /// <summary>
        /// Swipe down on the FinchRing or FinchTracker touchpad.
        /// </summary>
        SwipeDown = 1,

        /// <summary>
        /// Swipe to the left on the FinchRing or FinchTracker touchpad.
        /// </summary>
        SwipeLeft = 2,

        /// <summary>
        /// Swipe to the right on the FinchRing or FinchTracker touchpad.
        /// </summary>
        SwipeRight = 3,

        /// <summary>
        /// This event appears if there was any change of Touchpad's state.    
        /// </summary>
        SwipeAny = 6,
    }

}