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
    /// Elements of Shift Controller.
    /// </summary>
    public enum ShiftElement : ushort
    {
        /// <summary>
        /// System button of the FinchShift or FinchTracker.
        /// </summary>
        HomeButton = 7,

        /// <summary>
        /// Curved button below the touchpad of the FinchShift.
        /// </summary>
        AppButton = 0,

        /// <summary>
        /// Button under the touchpad of the FinchShift.
        /// </summary>
        ButtonThumb = 9,

        /// <summary>
        /// Touchpad of the FinchShift.
        /// </summary>
        Touch = 15,

        /// <summary>
        /// Analog button under index finger of the FinchShift.
        /// </summary>
        Trigger = 4,

        /// <summary>
        /// Controller element under middle finger of the FinchShift.
        /// </summary>
        ButtonGrip = 5
    }

    /// <summary>
    /// Button extensions for Shift Controller.
    /// </summary>
    public static class ButtonsShiftExtensions
    {
        /// <summary>
        /// Returns true if the controller's element was pressed down.
        /// </summary>
        /// <param name="element">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller element was pressed down.</returns>
        public static bool GetPressDown(this Buttons b, ShiftElement element)
        {
            return b.GetPressDown((int)element);
        }

        /// <summary>
        /// Returns true if the controller's element is pressed down.
        /// </summary>
        /// <param name="element">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller element is pressed down.</returns>
        public static bool GetPress(this Buttons b, ShiftElement element)
        {
            return b.GetPress((int)element);
        }

        /// <summary>
        /// Returns true if the controller's element was released.
        /// </summary>
        /// <param name="element">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller's element was released.</returns>
        public static bool GetPressUp(this Buttons b, ShiftElement element)
        {
            return b.GetPressUp((int)element);
        }

        /// <summary>
        /// Returns time in milliseconds how long controller's element was pressed.
        /// </summary>
        /// <param name="element">Element of the controller (button, touchpad, etc).</param>
        /// <returns>Time in milliseconds how long controller's element was pressed.</returns>
        public static float GetPressTime(this Buttons b, ShiftElement element)
        {
            return b.GetPressTime((int)element);
        }
    }
}
