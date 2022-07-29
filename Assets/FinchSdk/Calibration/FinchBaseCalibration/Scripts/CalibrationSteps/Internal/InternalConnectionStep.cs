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

namespace Finch.Calibration
{
    /// <summary>
    /// States of connection set step.
    /// </summary>
    public enum ConnectionStepState
    {
        WaitingConnection,
        Success
    }

    /// <summary>
    /// Type of scanning.
    /// </summary>
    public enum ScannerType
    {
        /// <summary>
        /// Only connect controllers from device bluetooth bonded list.
        /// </summary>
        Bonded = FinchCore.Finch_ScannerType.Bonded,
        /// <summary>
        /// Connect controllers from device bluetooth bonded list and advertising controllers.
        /// </summary>
        BA = FinchCore.Finch_ScannerType.BA,
        /// <summary>
        /// Only connect advertising controllers.
        /// </summary>
        Advertising = FinchCore.Finch_ScannerType.Advertising
    }

    /// <summary>
    /// Set of controllers.
    /// </summary>
    public enum ConnectionSet
    {
        /// <summary>
        /// None controllers.
        /// </summary>
        None = 0,
        /// <summary>
        /// One controller - right or left.
        /// </summary>
        OneHand = 1,
        /// <summary>
        /// Two controllers - right and left.
        /// </summary>
        TwoHands = 2
    }

    /// <summary>
    /// Provides basic algorithms of controller connection step.
    /// </summary>
    public class InternalConnectionStep
    {
        private const float timeToStartScanner = 0.2f;
        private const float timeScannerEnable = 10f;
        private const float timeScannerDisable = 0.5f;

        private bool isScanning;
        private float nextChangeScannerStateTime;

        private sbyte rssi = -100;
        private FinchCore.Finch_ScannerType mode;
        private ConnectionSet connectionSet;
        private bool usingUpperArms = false;

        public bool IsSetConnected
        {
            get
            {
                int controllersConnected = Internal.FinchNodeManager.GetControllersCount();
                int trackersConnected = Internal.FinchNodeManager.GetTrackersCount();

                return controllersConnected >= (int)connectionSet &&
                       (trackersConnected >= (int)connectionSet || !usingUpperArms);
            }
        }

        public void Init(ConnectionSet set, ScannerType scannerType, sbyte currentRSSI, bool useUpperArm = false)
        {
            isScanning = false;
            nextChangeScannerStateTime = Time.time;

            rssi = currentRSSI;
            mode = (FinchCore.Finch_ScannerType)scannerType;
            connectionSet = set;

            usingUpperArms = useUpperArm;
        }

        public ConnectionStepState Update()
        {
            UpdateScanner();
            return IsSetConnected ? ConnectionStepState.Success : ConnectionStepState.WaitingConnection;
        }

        private void UpdateScanner()
        {
            if (Time.time < timeToStartScanner || Time.time < nextChangeScannerStateTime)
            {
                return;
            }

            nextChangeScannerStateTime = Time.time + (isScanning ? timeScannerDisable : timeScannerEnable);

            if (isScanning)
            {
                isScanning = false;
                FinchCore.Finch_StopScan();
            }
            else
            {
                isScanning = FinchCore.Finch_StartScan(mode, rssi) == FinchCore.Finch_ErrorCode.None;
            }
        }

        public void Exit()
        {
            Internal.FinchNodeManager.NormalizeNodeCount((int)connectionSet);
        }
    }
}