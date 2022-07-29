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
using Finch.Internal;

namespace Finch
{
    internal static class FinchConverter
    {
        internal static FinchCore.Finch_Vector2 ToFinch(this Vector2 v)
        {
            return new FinchCore.Finch_Vector2(v.x, v.y);
        }

        internal static Vector2 ToUnity(this FinchCore.Finch_Vector2 v)
        {
            return new Vector2((float)v.X, (float)v.Y);
        }

        internal static FinchCore.Finch_Vector3 ToFinch(this Vector3 v)
        {
            return new FinchCore.Finch_Vector3(v.x, v.y, v.z);
        }

        internal static Vector3 ToUnity(this FinchCore.Finch_Vector3 v)
        {
            return new Vector3((float)v.X, (float)v.Y, (float)v.Z);
        }

        internal static FinchCore.Finch_Quaternion ToFinch(this Quaternion v)
        {
            return new FinchCore.Finch_Quaternion(v.x, v.y, v.z, v.w);
        }

        internal static Quaternion ToUnity(this FinchCore.Finch_Quaternion q)
        {
            return new Quaternion((float)q.X, (float)q.Y, (float)q.Z, (float)q.W);
        }
    }
}