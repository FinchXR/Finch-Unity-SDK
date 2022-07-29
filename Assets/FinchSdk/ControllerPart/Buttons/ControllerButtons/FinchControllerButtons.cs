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
    /// Basic button extension for controller.
    /// </summary>
    public static class FinchControllerButtonExtensions
    {
        private static Buttons[] buttons = {
            new Buttons(NodeType.RightHand),
            new Buttons(NodeType.LeftHand)
        };

        /// <summary>
        /// Buttons extensions for selected node.
        /// </summary>
        /// <param name="controller">Selected controller.</param>
        /// <returns>Buttons states for selected node.</returns>
        public static Buttons Buttons(this FinchController controller)
        {
            return buttons[(int)controller.Node];
        }
    }
}