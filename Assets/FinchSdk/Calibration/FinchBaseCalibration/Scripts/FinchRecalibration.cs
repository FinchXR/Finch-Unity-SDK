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
    /// Provides a recalibration call.
    /// </summary>
    public class FinchRecalibration : MonoBehaviour
    {
        [SerializeField]
        private bool CalibrateOnStart;

        private void Start()
        {
            if (CalibrateOnStart)
            {
                FinchCalibrationManager.Calibrate();
            }

            Finch.Internal.FinchNodeManager.OnDisconnected += (node) => FinchCalibrationManager.Calibrate();
        }

        private void Update()
        {
            bool rightReady = FinchController.Right.Buttons().GetPressTime(ShiftElement.HomeButton) > 1f;
            bool leftReady = FinchController.Left.Buttons().GetPressTime(ShiftElement.HomeButton) > 1f;

            bool connections = FinchController.Right.IsConnected && FinchController.Left.IsConnected;

            bool recall = connections ? (rightReady && leftReady) : (rightReady || leftReady);

            if (recall)
            {
                FinchCalibrationManager.Calibrate();
            }
        }
    }
}