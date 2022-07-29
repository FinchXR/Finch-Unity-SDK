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

using System;
using UnityEngine;

namespace Finch
{
    /// <summary>
    /// Provides information about Finch device: rotation, position, device's elements states, battery level. Allows to control device's haptic feedback (vibration).
    /// </summary>
    public abstract class FinchNode
    {
        /// <summary>
        /// Finch device's chirality (left or right).
        /// </summary>
            protected Chirality chirality;

        public NodeType Node;

        /// <summary>
        /// Device's rotation.
        /// </summary>
        public Quaternion Rotation
        {
            get { return Internal.FinchInput.GetRotation(Node).ToUnity(); }
        }

        /// <summary>
        /// Device's position.
        /// </summary>
        public Vector3 Position
        {
            get { return Internal.FinchInput.GetPosition(Node).ToUnity(); }
        }


        /// <summary>
        /// Defines controller vibration time in milliseconds. 
        /// </summary>
        /// <param name="pattern">Vibration pattern.</param>
        public void HapticPulse(FinchHapticPattern pattern)
        {
            Internal.FinchNodeManager.HapticPulse(Node, pattern);
        }

        /// <summary>
        /// Connection state.
        /// </summary>
        public bool IsConnected
        {
            get { return Internal.FinchNodeManager.IsConnected(Node); }
        }

        /// <summary>
        /// Battery charge in percent.
        /// </summary>
        public ushort BatteryCharge
        {
            get { return Internal.FinchInput.GetBatteryCharge(Node); }
        }
    }
}
