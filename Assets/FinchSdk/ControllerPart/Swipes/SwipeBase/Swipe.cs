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
    /// Provides swipes.
    /// </summary>
    public class Swipe
    {
        private NodeType node;

        /// <summary>
        /// Current node swipes states.
        /// </summary>
        /// <param name="currentNode">Selected Finch node.</param>
        public Swipe(NodeType currentNode)
        {
            node = currentNode;
        }

        /// <summary>
        /// True if user has swiped from left to right.
        /// </summary>
        public bool SwipeRight { get { return Internal.FinchInput.GetTouchpadEvent(node, (int)TouchpadEvents.SwipeRight); } }

        /// <summary>
        /// True if user has swiped from right to left.
        /// </summary>
        public bool SwipeLeft { get { return Internal.FinchInput.GetTouchpadEvent(node, (int)TouchpadEvents.SwipeLeft); } }

        /// <summary>
        /// True if user has swiped from bottom to top.
        /// </summary>
        public bool SwipeTop { get { return Internal.FinchInput.GetTouchpadEvent(node, (int)TouchpadEvents.SwipeUp); } }

        /// <summary>
        /// True if user has swiped from top to bottom.
        /// </summary>
        public bool SwipeBottom { get { return Internal.FinchInput.GetTouchpadEvent(node, (int)TouchpadEvents.SwipeDown); } }

        /// <summary>
        /// Touchpad touch point coordinates.
        /// </summary>
        public Vector2 TouchAxes
        {
            get { return Internal.FinchInput.GetTouchAxes(node).ToUnity(); }
        }
    }
}
