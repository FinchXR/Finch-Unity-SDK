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
using System.Linq;

namespace Finch.Calibration
{
    /// <summary>
    /// Manages calibration.
    /// </summary>
    public class FinchCalibrationManager : MonoBehaviour
    {
        /// <summary>
        /// Call when calibration starts.
        /// </summary>
        public static Action OnCalibrationStart;

        /// <summary>
        /// Call when calibration ends.
        /// </summary>
        public static Action OnCalibrationEnd;

        /// <summary>
        /// True if calibration in process.
        /// </summary>
        public static bool IsCalibrating { get; private set; }

        /// <summary>
        /// True if calibration process was ended once.
        /// </summary>
        public static bool WasCalibrated { get; private set; }

        /// <summary>
        /// List of calibration steps.
        /// </summary>
        public List<CalibrationStep> Steps;

        private static FinchCalibrationManager instance;
        private static int calibrationStep;

        private void Awake()
        {
            instance = this;
            Steps.ForEach(x => 
            { 
                x.OnStepEnd += NextStep; 
                x.gameObject.SetActive(false); 
            });
        }

        /// <summary>
        /// Start calibration.
        /// </summary>
        public static void Calibrate()
        {
            IsCalibrating = true;
            calibrationStep = 0;
            OnCalibrationStart?.Invoke();
            instance?.Steps.ForEach(x => x.gameObject.SetActive(false));
            instance?.Steps[0]?.Invoke();
        }

        /// <summary>
        /// Load next calibration step.
        /// </summary>
        private void NextStep()
        {
            calibrationStep++;

            if (calibrationStep >= Steps.Count)
            {
                WasCalibrated = true;
                IsCalibrating = false;
                OnCalibrationEnd?.Invoke();
            }
            else
            {
                Steps[calibrationStep].Invoke();
            }
        }
    }
}
