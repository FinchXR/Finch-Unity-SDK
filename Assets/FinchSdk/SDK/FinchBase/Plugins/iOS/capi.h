#pragma once
#include "capi_definition.h"

#ifdef __cplusplus
extern "C" {
#endif

/// Get the version of FinchCore.
FINCH_API uint32_t Finch_GetVersion(char* f, uint32_t length);

/// Init FinchCore.
FINCH_API Finch_ErrorCode Finch_Init(Finch_ControllerType controllerType,
                                     Finch_PlatformType platformType,
                                     Finch_UpdateOption updateOptions);

/// Exit FinchCore.
FINCH_API Finch_ErrorCode Finch_Exit();

/// Returns the type of controller that used in the FinchCore.
FINCH_API Finch_ControllerType Finch_GetControllerType();

/// Returns bone rotation.
FINCH_API Finch_Quaternion Finch_GetBoneRotation(Finch_Bone bone, Finch_RotationType type);

/// Returns controller orientation.
FINCH_API Finch_Quaternion Finch_GetControllerOrientation(Finch_Chirality chirality);

/// Returns hmd orientation.
FINCH_API Finch_Quaternion Finch_GetHmdOrientation();

/// Returns bone position. In case of non-positional update position is relatively midpoint of left and right shoulders.
FINCH_API Finch_Vector3 Finch_GetBonePosition(Finch_Bone bone);

/// Returns controller position. In case of non-positional update position is relatively midpoint of left and right shoulders.
FINCH_API Finch_Vector3 Finch_GetControllerPosition(Finch_Chirality chirality);

/// Returns hmd position. In case of non-positional update position is relatively midpoint of left and right shoulders.
FINCH_API Finch_Vector3 Finch_GetHmdPosition();

/// Returns node angular acceleration.
FINCH_API Finch_Vector3 Finch_GetNodeAngularAcceleration(Finch_Node node, Finch_ImuDataOption imuDataOptions);

/// Returns node linear acceleration in meters per second squared.
FINCH_API Finch_Vector3 Finch_GetNodeLinearAcceleration(Finch_Node node, Finch_ImuDataOption imuDataOptions);

/// Returns node angular velocity in radians per second.
FINCH_API Finch_Vector3 Finch_GetNodeAngularVelocity(Finch_Node node, Finch_ImuDataOption imuDataOptions);

/// Returns bone linear velocity.
FINCH_API Finch_Vector3 Finch_GetNodeLinearVelocity(Finch_Node node, Finch_ImuDataOption imuDataOptions);

/// Returns coordinates of the touch.
FINCH_API Finch_Vector2 Finch_GetTouchAxes(Finch_Node node);

/// Returns events flag of the element.
FINCH_API uint16_t Finch_GetEvents(Finch_Node node);

/// Returns analog value of the element in the range 0 to 1.
FINCH_API float Finch_GetAnalog(Finch_Node node, uint16_t element);

/// Returns battery charge in percentages.
FINCH_API uint8_t Finch_GetNodeCharge(Finch_Node node);

/// Calibrates all controllers.
FINCH_API Finch_ErrorCode Finch_Calibration(Finch_CalibrationType type, Finch_CalibrationOption option);

/// Sets user defined coordinate system.
FINCH_API Finch_ErrorCode Finch_SetCs(Finch_Vector3 x, Finch_Vector3 y, Finch_Vector3 z);

/// Sets coordinate system to default coordinate system.
FINCH_API Finch_ErrorCode Finch_SetDefaultCs();

/// Update Finch Core Data.
FINCH_API Finch_ErrorCode Finch_Update();

/// Update Finch Core Data with a rotation of the HMD.
FINCH_API Finch_ErrorCode Finch_HmdRotationUpdate(Finch_Quaternion qhmd);

/// Update Finch Core Data with a transform of the HMD.
FINCH_API Finch_ErrorCode Finch_HmdTransformUpdate(Finch_Quaternion qhmd, Finch_Vector3 phmd);

FINCH_API Finch_ErrorCode Finch_StartScan(Finch_ScannerType scannerType, int8_t rssiThreshold);

FINCH_API Finch_ErrorCode Finch_StopScan();

FINCH_API Finch_ErrorCode Finch_DisconnectNode(Finch_Node node);

/// Returns is node connected.
FINCH_API Finch_Bool Finch_IsNodeConnected(Finch_Node node);

FINCH_API Finch_ErrorCode Finch_SuspendNode(Finch_Node node);

FINCH_API Finch_ErrorCode Finch_ResumeNode(Finch_Node node);

FINCH_API Finch_ErrorCode Finch_TriggerHapticPulse(Finch_Node node, uint32_t milliseconds, uint8_t strength);

#ifdef __cplusplus
}
#endif
