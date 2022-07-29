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
using Finch;

namespace Finch.Calibration.Shift
{
    /// <summary>
    /// Provides recenter of controllers orientation.
    /// </summary>
    public class RecenterShiftStep : CalibrationStep
    {
        private bool isTwoHanded { get { return FinchController.Left.IsConnected && FinchController.Right.IsConnected; } }

        public override void Invoke()
        {
            gameObject.SetActive(true);
        }

        void Update()
        {
            bool pressLeft = FinchController.Left.Buttons().GetPress(ShiftElement.ButtonThumb);
            bool pressRight = FinchController.Right.Buttons().GetPress(ShiftElement.ButtonThumb);

            if ((isTwoHanded && pressLeft && pressRight) || (!isTwoHanded && (pressLeft || pressRight)))
            {
                Calibrate();

                OnStepEnd?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void Calibrate()
        {
            Finch.Internal.Calibration.ReplyManager.Calibration(Finch.Internal.FinchCore.Finch_CalibrationType.Hmd, Finch.Internal.FinchCore.Finch_CalibrationOptions.None);
        }
    }
}