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
using System.Text;
using Finch.Internal;

namespace Finch
{
    /// <summary>
    /// Provides functions to manage nodes.
    /// </summary>
    public static class FinchNodeManager
    {
        /// <summary>
        /// Current controller connection type.
        /// </summary>
        public static ControllerType ControllerType { get { return (ControllerType)FinchDataManager.ControllerType; } }

        #region Scanner
        /// <summary>
        /// Is scanner scanning right now.
        /// </summary>
        public static bool IsScanning { get { return Internal.FinchNodeManager.IsScanning; } }

        /// <summary>
        /// Start scanner to connect nodes.
        /// </summary>
        /// <returns>Is scanner start succesful.</returns>
        public static bool StartScan(FinchCore.Finch_ScannerType type)
        {
            return Internal.FinchNodeManager.StartScan(type);
        }

        /// <summary>
        /// Stop scanner.
        /// </summary>
        public static void StopScan()
        {
            Internal.FinchNodeManager.StopScan();
        }
        #endregion

        /// <summary>
        /// Swaps nodes.
        /// </summary>
        /// <param name="firstNode">First node to swap.</param>
        /// <param name="secondNode">Second node to swap.</param>
        public static void SwapNodes(NodeType firstNode, NodeType secondNode)
        {
            Internal.FinchNodeManager.SwapNodes(firstNode, secondNode);
        }

        public static bool IsConnected(NodeType node)
        {
            return Internal.FinchNodeManager.IsConnected(node);
        }

        /// <summary>
        /// Disconnects node.
        /// </summary>
        /// <param name="node">Certain node.</param>
        public static void DisconnectNode(NodeType node)
        {
            Internal.FinchNodeManager.DisconnectNode(node);
        }
    }
}
