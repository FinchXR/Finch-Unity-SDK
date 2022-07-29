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
    /// Provides IMU Data.
    /// </summary>
    public class IMUData
    {
        private NodeType node;

        /// <summary>
        /// Current node IMU states.
        /// </summary>
        /// <param name="currentNode">Selected Finch node.</param>
        public IMUData(NodeType currentNode)
        {
            node = currentNode;
        }

        /// <summary>
        /// Returns node's linear acceleration in meters per second squared.
        /// </summary>
        /// <param name="node">Certain node.</param>
        /// <returns>Linear acceleration in meters per second squared.</returns>
        public Vector3 GetLinearAcceleration()
        {
            return Internal.FinchInput.GetLinearAcceleration(node).ToUnity();
        }

        /// <summary>
        /// Returns node angular speed in radians per second.
        /// </summary>
        /// <param name="node">Certain node.</param>
        /// <returns>Node angular speed in radians per second.</returns>
        public Vector3 GetAngularVelocity()
        {
            return Internal.FinchInput.GetAngularVelocity(node).ToUnity();
        }
    }
}