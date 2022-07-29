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

namespace Finch.Calibration.Tools
{
    /// <summary>
    /// Provides movement for another object.
    /// </summary>
    public class Follower : MonoBehaviour
    {
        /// <summary>
        /// The object to follow.
        /// </summary>
        public Transform ObjectToFollow;

        /// <summary>
        /// Offset vector.
        /// </summary>
        public Vector3 Offset = Vector3.forward * 5f;

        /// <summary>
        /// At this specified angle calibration tip will freeze and will stop to follow movements of user's head.
        /// </summary>
        public float MaxRotationDelta = 2;

        /// <summary>
        /// This value represents how smooth calibration tip will follow user's movements.
        /// </summary>
        public float StithnessY = 5f;

        private float angle;

        private void Update()
        {
            float delta = ObjectToFollow.eulerAngles.y - angle;

            if (Mathf.Abs(delta) > 180)
            {
                delta = (Mathf.Abs(delta) - 360) * Mathf.Sign(delta);
            }

            if (Mathf.Abs(delta) > MaxRotationDelta)
            {
                float resultAngle = (ObjectToFollow.eulerAngles.y - Mathf.Sign(delta) * MaxRotationDelta);
                delta = resultAngle - angle;

                if (Mathf.Abs(delta) > 180)
                {
                    delta = (Mathf.Abs(delta) - 360) * Mathf.Sign(delta);
                }

                angle += delta * (MaxRotationDelta == 0 ? 1 : Mathf.Clamp01(Time.deltaTime * StithnessY));
            }

            float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 deltaX = Offset.x * (Vector3.right * cos + Vector3.forward * sin);
            Vector3 deltaY = Offset.y * Vector3.up;
            Vector3 deltaZ = Offset.z * (Vector3.right * sin + Vector3.forward * cos);

            transform.position = ObjectToFollow.position + deltaX + deltaY + deltaZ;
            transform.LookAt(ObjectToFollow.position, Vector3.up);
            transform.eulerAngles = Vector3.up * transform.eulerAngles.y;

        }
    }
}