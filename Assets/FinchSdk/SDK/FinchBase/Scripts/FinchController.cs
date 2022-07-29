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
    /// Provides information about Finch controller: rotation, position, controller's elements states, battery level. Allows to control controller's haptic feedback (vibration).
    /// </summary>
    public class FinchController : FinchNode
    {
        /// <summary>
        /// Instance of the right Finch controller.
        /// </summary>
        public static readonly FinchController Right = new FinchController(Chirality.Right, NodeType.RightHand);

        /// <summary>
        /// Instance of the left Finch controller.
        /// </summary>
        public static readonly FinchController Left = new FinchController(Chirality.Left, NodeType.LeftHand);

        private FinchController(Chirality nodeChirality, NodeType nodeType)
        {
            chirality = nodeChirality;
            Node = nodeType;
        }

        /// <summary>
        /// Returns controller instance according to its chirality.
        /// </summary>
        /// <param name="chirality">Controller's chirality: left or right.</param>
        /// <returns>Finch Controller of specified chirality.</returns>
        public static FinchController GetController(Chirality chirality)
        {
            switch (chirality)
            {
                case Chirality.Left:
                    return Left;

                case Chirality.Right:
                    return Right;

                default:
                    return null;
            }
        }
    }
}
