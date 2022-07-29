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

using UnityEngine;
using Finch.Internal;

namespace Finch
{
    /// <summary>
    /// Main Finch class. Provides Finch data updates - provides data for FinchCore and gets data from FinchCore according to FinchSettings.
    /// </summary>
    public class FinchManager : MonoBehaviour
    {
        /// <summary>
        /// Character's head position and rotation quaternions.
        /// </summary>
        [Tooltip("Leave this field empty if you want to use data of Camera.main")]
        public Transform Head;

        /// <summary>
        /// Defines Finch controller type according to Finch device that you are going to use.
        /// </summary>
        public ControllerType ControllerType = ControllerType.Shift;

        private const FinchCore.Finch_LoggerLevel loggerLevel = FinchCore.Finch_LoggerLevel.Debug;

        private void Awake()
        {
            Head = Head ?? Camera.main.transform;

            FinchBase.SetConsoleLogger(loggerLevel);

            string path = Application.persistentDataPath;
            FinchBase.SetFileLogger(loggerLevel, path, (uint)path.Length);//TODO: rename to directory path.
            FinchBase.Init((FinchCore.Finch_ControllerType)ControllerType, 
                FinchCore.Finch_UpdateOption.Internal | FinchCore.Finch_UpdateOption.HmdOrientation | FinchCore.Finch_UpdateOption.HmdPosition 
                );
            FinchCore.Finch_SetBodyRotationMode(FinchCore.Finch_BodyRotationMode.HmdRotation);
        }

        private void OnApplicationQuit()
        {
            FinchBase.Exit();
        }

        private void LateUpdate()
        {
            FinchBase.Update(Head.position.ToFinch(), Head.rotation.ToFinch(), Time.time);
        }
    }
}
