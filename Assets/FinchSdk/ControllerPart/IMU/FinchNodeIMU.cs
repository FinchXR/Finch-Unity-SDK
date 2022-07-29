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
    /// Basic IMU extension for controller.
    /// </summary>
    public static class FinchNodeIMUExtensions
    {
        private static IMUData[] imu = {
            new IMUData(NodeType.RightHand),
            new IMUData(NodeType.LeftHand),
            new IMUData(NodeType.LeftHand),
            new IMUData(NodeType.LeftHand)
        };

        /// <summary>
        /// IMU extensions for selected node.
        /// </summary>
        /// <param name="node">Selected controller.</param>
        /// <returns>Buttons states for selected node.</returns>
        public static IMUData IMU(this FinchNode node)
        {
            return imu[(int)node.Node];
        }
    }
}