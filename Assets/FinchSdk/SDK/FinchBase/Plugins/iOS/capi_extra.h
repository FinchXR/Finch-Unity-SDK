#pragma once
#include "capi_definition.h"

#ifdef __cplusplus
extern "C" {
#endif

/// Gets root coordinate system offset.
FINCH_API Finch_Vector3 Finch_GetRootOffset();

/// Sets root coordinate system offset.
FINCH_API void Finch_SetRootOffset(Finch_Vector3 v);

/// Returns the body rotation mode used in the Finch Core.
FINCH_API Finch_BodyRotationMode Finch_GetBodyRotationMode();

/// Sets the value of the body rotation mode.
FINCH_API void Finch_SetBodyRotationMode(Finch_BodyRotationMode mode);

/// Enables tracking or calibration features.
FINCH_API Finch_ErrorCode Finch_EnableFeature(Finch_Feature feature);

/// Disables tracking or calibration features.
FINCH_API Finch_ErrorCode Finch_DisableFeature(Finch_Feature feature);

FINCH_API Finch_Bool Finch_IsInputHmdUpsideDown();

FINCH_API void Finch_DeferCalibration();

FINCH_API uint64_t Finch_GetCalibrationId();

/// Sets forward direction of user by selected direction.
FINCH_API Finch_ErrorCode Finch_SetCalibrationDirection(Finch_Quaternion targetOrientation);

/// Sets forward direction of user by selected direction of hands.
FINCH_API Finch_ErrorCode Finch_SetCalibrationControllersPositions(Finch_Vector3 leftControllerPositionRelativelyToHmd,
                                                                   Finch_Vector3 rightControllerPositionRelativelyToHmd);

/// Returns node current orientation without calibration adjust.
FINCH_API Finch_Quaternion Finch_GetNodeTPosedRotation(Finch_Node node);

FINCH_API Finch_Quaternion Finch_GetTrackingBOrientation(Finch_Node node);

FINCH_API Finch_Vector3 Finch_GetTrackingBDirection(Finch_Node node);

FINCH_API Finch_Quaternion Finch_GetElbowEstimation(Finch_Chirality chirality);

FINCH_API Finch_Quaternion Finch_GetCalibrationAdjust(Finch_Node node, Finch_CalibrationAdjustOption calibrationAdjustOptions);

FINCH_API void Finch_SetCalibrationAdjust(Finch_Node node,
                                          Finch_Quaternion calibrationQuaternion,
                                          Finch_CalibrationAdjustOption calibrationAdjustOptions);

FINCH_API double Finch_GetVerticalCompensator(Finch_Node node);

FINCH_API void Finch_SetVerticalCompensator(Finch_Node node, double value);

/// Returns true, if node is reverted.
FINCH_API Finch_Bool Finch_IsCalibrationReverted(Finch_Node node);

/// Revert node orientation to another.
FINCH_API void Finch_RevertCalibration(Finch_Node node);

/// Swap the selected node calibrations.
FINCH_API Finch_ErrorCode Finch_SwapCalibrations(Finch_Node first, Finch_Node second);

FINCH_API Finch_ErrorCode Finch_RecenterHmd();

/// Returns the bone length skeletal model.
FINCH_API double Finch_GetBoneLength(Finch_Bone bone);

/// Sets the value of the selected bone length.
FINCH_API void Finch_SetBoneLength(Finch_Bone bone, double length);

/// Returns the clavicle base.
FINCH_API double Finch_GetClavicleBase();

/// Sets the clavicle base.
FINCH_API void Finch_SetClavicleBase(double length);

/// Returns the clavicle offset.
FINCH_API double Finch_GetClavicleOffset();

/// Sets the clavicle offset.
FINCH_API void Finch_SetClavicleOffset(double length);

/// Returns the controller width.
FINCH_API double Finch_GetControllerWidth();

/// Sets the controller width.
FINCH_API void Finch_SetControllerWidth(double width);

/// Returns the controller offset.
FINCH_API Finch_Vector3 Finch_GetControllerOffset(Finch_Chirality chirality);

/// Sets the both controller offsets by chirality controller offset.
FINCH_API void Finch_SetControllerOffset(Finch_Vector3 offset, Finch_Chirality chirality);

/// Update Finch Core Data without updating nodes data.
FINCH_API Finch_ErrorCode Finch_Apply();

FINCH_API Finch_ErrorCode Finch_SetUpdateInterval(uint32_t milliseconds);

FINCH_API uint64_t Finch_GetUpdateDeltaTime();

FINCH_API void Finch_SetUpdateDeltaTime(uint64_t nanoseconds);

/// Swap the selected conjugated nodes.
FINCH_API Finch_ErrorCode Finch_SwapNodes(Finch_Node first, Finch_Node second);

FINCH_API uint64_t Finch_GetNodeTime(Finch_Node node);

/// Get the node name node.
FINCH_API uint32_t Finch_GetNodeName(Finch_Node node, char* f, uint32_t length);

/// Get node address.
FINCH_API uint32_t Finch_GetNodeAddress(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeManufacturerName(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeModelNumber(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeSerialNumber(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeHardwareRevision(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeFirmwareRevision(Finch_Node node, char* f, uint32_t length);

FINCH_API uint32_t Finch_GetNodeSoftwareRevision(Finch_Node node, char* f, uint32_t length);

FINCH_API uint8_t Finch_GetNodeVendorIDSource(Finch_Node node);

FINCH_API uint16_t Finch_GetNodeVendorID(Finch_Node node);

FINCH_API uint16_t Finch_GetNodeProductID(Finch_Node node);

FINCH_API uint16_t Finch_GetNodeProductVersion(Finch_Node node);

FINCH_API uint32_t Finch_GetNodeRawData(Finch_Node node, uint8_t* data, uint32_t length);

FINCH_API Finch_ErrorCode Finch_SetNodeRawData(Finch_Node node, const uint8_t* data, uint32_t length);

/// Writes data to node.
FINCH_API Finch_ErrorCode Finch_SendDataToNode(Finch_Node node, const uint8_t* data, uint32_t length);

FINCH_API Finch_ErrorCode Finch_SetConsoleLogger(Finch_LoggerLevel lvl);

FINCH_API Finch_ErrorCode Finch_SetFileLogger(Finch_LoggerLevel lvl, const char* path, uint32_t length);

FINCH_API Finch_ErrorCode Finch_FlushLoggerLevels(Finch_LoggerLevel lvl);

FINCH_API uint64_t Finch_GetRecordId();

FINCH_API Finch_ErrorCode Finch_StartRecord(const char* path, uint32_t length);

FINCH_API Finch_ErrorCode Finch_EndRecord();

FINCH_API Finch_ErrorCode Finch_SetCallbackForRecordId(RecordIdCallback recordIdCallback);

FINCH_API Finch_ErrorCode Finch_SetElbowModelFromBuffer(const uint8_t* buffer, uint32_t length);

FINCH_API Finch_ErrorCode Finch_SetOpticalAnnData(Finch_Node node, Finch_Vector3 position, Finch_OpticalAnnResponse response);

#ifdef __cplusplus
}
#endif
