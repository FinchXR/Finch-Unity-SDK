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
    /// State of chirality binding.
    /// </summary>
    public enum BindChiralityStepState
    {
        None = 0,
        Incorrect,
        Correct
    }

    public abstract class InternalBindChirality
    {
        public abstract BindChiralityStepState[] Update();
        public abstract bool IsStepEnd();

        protected Chirality leftChirality;
        protected Chirality rightChirality;

        public void StepEnd()
        {
            rightChirality = Internal.FinchNode.GetCapacitySensor(NodeType.RightHand);
            leftChirality = Internal.FinchNode.GetCapacitySensor(NodeType.LeftHand);

            if (leftChirality == Chirality.Right || rightChirality == Chirality.Left)
            {
                FinchNodeManager.SwapNodes(NodeType.LeftHand, NodeType.RightHand);
            }
        }
    }

    /// <summary>
    /// Provides controller chirality binding basic algorithms.
    /// </summary>
    public class InternalBindTwoShiftChirality : InternalBindChirality
    {
        private Chirality lastCorrect;

        public override BindChiralityStepState[] Update()
        {
            UpdateCapacities();
            UpdateLastCorrectGrab();

            if (leftChirality != Chirality.Any && rightChirality != Chirality.Any && (leftChirality == rightChirality))
                return new BindChiralityStepState[] { BindChiralityStepState.Incorrect, BindChiralityStepState.Incorrect };
            else
                return new BindChiralityStepState[] { GetState(leftChirality), GetState(rightChirality) };
        }

        public override bool IsStepEnd()
        {
            return (leftChirality != Chirality.Both && rightChirality != Chirality.Both && leftChirality != rightChirality)
                && ((FinchController.Left.IsConnected && FinchController.Right.IsConnected && leftChirality != Chirality.Any && rightChirality != Chirality.Any)
                || (!FinchController.Right.IsConnected && leftChirality != Chirality.Any)
                || (!FinchController.Left.IsConnected && rightChirality != Chirality.Any)
                || (!FinchController.Right.IsConnected && rightChirality != Chirality.Any)
                || (!FinchController.Left.IsConnected && leftChirality != Chirality.Any));
        }

        private BindChiralityStepState GetState(Chirality chirality)
        {
            switch (chirality)
            {
                case Chirality.Right:
                case Chirality.Left:
                    return BindChiralityStepState.Correct;

                case Chirality.Both:
                    return BindChiralityStepState.Incorrect;

                default:
                    return BindChiralityStepState.None;
            }
        }

        private void UpdateCapacities()
        {
            rightChirality = Internal.FinchNode.GetCapacitySensor(NodeType.RightHand);
            leftChirality = Internal.FinchNode.GetCapacitySensor(NodeType.LeftHand);

            if (leftChirality == Chirality.Right || rightChirality == Chirality.Left)
            {
                var temp = rightChirality;
                rightChirality = leftChirality;
                leftChirality = temp;
            }
        }

        private void UpdateLastCorrectGrab()
        {
            if (HasValues(Chirality.None, Chirality.Left))
            {
                lastCorrect = Chirality.Left;
            }

            if (HasValues(Chirality.None, Chirality.Right))
            {
                lastCorrect = Chirality.Right;
            }

            if (HasValues(Chirality.None, Chirality.Both))
            {
                leftChirality = lastCorrect == Chirality.Left ? Chirality.Both : Chirality.None;
                rightChirality = lastCorrect == Chirality.Right ? Chirality.Both : Chirality.None;
            }
        }

        private bool HasValues(Chirality stateA, Chirality stateB)
        {
            return stateA == leftChirality && stateB == rightChirality ||
                   stateB == leftChirality && stateA == rightChirality;
        }
    }
}
