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

namespace Finch.Calibration.Shift
{
    /// <summary>
    /// Ñalibration step, during which there assignment chirality of Finch controllers.
    /// </summary>
    public class BindShiftChirality : CalibrationStep
    {
        /// <summary>
        /// Sprite picture of left controller.
        /// </summary>
        public SpriteRenderer LeftShift;

        /// <summary>
        /// Sprite picture of right controller.
        /// </summary>
        public SpriteRenderer RightShift;

        /// <summary>
        /// Color set.
        /// </summary>
        public Color[] HoldColors;

        private InternalBindChirality step;

        public override void Invoke()
        {
            step = new InternalBindTwoShiftChirality();
            gameObject.SetActive(true);
        }

        private void Update()
        {
            var state = step.Update();

            RightShift.color = HoldColors[(int)state[1]];
            LeftShift.color = HoldColors[(int)state[0]];

            if(step.IsStepEnd())
            {
                gameObject.SetActive(false);
                step.StepEnd();
                OnStepEnd?.Invoke();
            }
        }
    }
}
