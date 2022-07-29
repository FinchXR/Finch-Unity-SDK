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
    /// Provides buttons states of the controllers.
    /// </summary>
    public class Buttons
    {
        private NodeType node;

        /// <summary>
        /// Buttons states of selected node.
        /// </summary>
        /// <param name="currentNode">Element of the controller (button, touchpad, etc).</param>
        public Buttons(NodeType currentNode)
        {
            node = currentNode;
        }

        /// <summary>
        /// Returns true if the controller's element was pressed down.
        /// </summary>
        /// <param name="elementId">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller element was pressed down.</returns>
        public bool GetPressDown(int elementId)
        {
            return Internal.FinchInput.GetPressDown(node, elementId);
        }

        /// <summary>
        /// Returns true if the controller's element was released.
        /// </summary>
        /// <param name="elementId">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller's element was released.</returns>
        public bool GetPressUp(int elementId)
        {
            return Internal.FinchInput.GetPressUp(node, elementId);
        }

        /// <summary>
        /// Returns true if the controller's element is pressed down.
        /// </summary>
        /// <param name="elementId">Element of the controller (button, touchpad, etc).</param>
        /// <returns>True if the controller element is pressed down.</returns>
        public bool GetPress(int elementId)
        {
            return Internal.FinchInput.GetPress(node, elementId);
        }

        /// <summary>
        /// Returns time in milliseconds how long controller's element was pressed.
        /// </summary>
        /// <param name="elementId">Element of the controller (button, touchpad, etc).</param>
        /// <returns>Returns the time the button was pressed</returns>
        public float GetPressTime(int elementId)
        {
            return Internal.FinchInput.GetPressTime(node, elementId);
        }
    }
}
