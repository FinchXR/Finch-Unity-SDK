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
using System.IO;

namespace Finch.Calibration
{
    /// <summary>
    /// Provides controller connection process.
    /// </summary>
    public class ConnectionStep : CalibrationStep
    {
        /// <summary>
        /// Scan type setting.
        /// </summary>
        public ScannerType Mode;

        /// <summary>
        /// Controller set setting.
        /// </summary>
        public ConnectionSet Set;

        /// <summary>
        /// Set true, if you will use Finch Trackers.
        /// </summary>
        public bool UseFinchTrackers;

        /// <summary>
        /// Animation of connection process.
        /// </summary>
        public AnimationBase ConnectionVisual;

        /// <summary>
        /// Animation of connection sucess.
        /// </summary>
        public AnimationBase SuccessVisual;

        /// <summary>
        /// Icons set of one hand.
        /// </summary>
        public GameObject OneHandIcons;

        /// <summary>
        /// Icons set of two hands.
        /// </summary>
        public GameObject TwoHandsIcons;

        private InternalConnectionStep step = new InternalConnectionStep();
        private sbyte rssi = -100;

        private void Start()
        {
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/ScannerInfo.txt");
            writer.WriteLine("Current mode: " + Mode + " rssi: " + rssi);
            writer.Close();
        }

        public override void Invoke()
        {
            gameObject.SetActive(true);
            step.Init(Set, Mode, rssi, UseFinchTrackers);
            
            step.Update();

            if (step.IsSetConnected && FinchCalibrationManager.WasCalibrated)
            {
                EndStep();
            }

            OneHandIcons.SetActive(Set == ConnectionSet.OneHand);
            TwoHandsIcons.SetActive(Set == ConnectionSet.TwoHands);
        }

        private void Update()
        {
            ConnectionStepState state = step.Update();

            ConnectionVisual.SetState(state == ConnectionStepState.WaitingConnection);
            SuccessVisual.SetState(state == ConnectionStepState.Success && ConnectionVisual.IsAnimationEnd);

            if (ConnectionVisual.IsAnimationEnd && SuccessVisual.IsAnimationEnd && state == ConnectionStepState.Success)
            {
                EndStep();
            }
        }

        private void EndStep()
        {
            Internal.FinchNodeManager.OnConnected += NormalizeControllerCount;
            Internal.FinchNodeManager.NormalizeNodeCount((int)Set);
            step.Exit();
            Internal.FinchCore.Finch_StopScan();
            gameObject.SetActive(false);
            OnStepEnd?.Invoke();
        }

        private void NormalizeControllerCount(NodeType node)
        {
            if (Set == ConnectionSet.OneHand && Internal.FinchNodeManager.GetControllersCount() == 2)
                Internal.FinchNodeManager.DisconnectNode(node);
        }
    }
}