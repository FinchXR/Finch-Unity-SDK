#pragma once
#include <cstdint>
#include <type_traits>

#if defined(_WIN32)
#    if defined(FINCH_C_LIB_EXPORT)
#        define FINCH_API __declspec(dllexport)
#    elif defined(FINCH_C_LIB_IMPORT)
#        define FINCH_API __declspec(dllimport)
#    else
#        define FINCH_API
#    endif
#else
#    if defined(FINCH_C_LIB_EXPORT)
#        define FINCH_API __attribute__((visibility("default")))
#    elif defined(FINCH_C_LIB_IMPORT)
#        define FINCH_API
#    else
#        define FINCH_API
#    endif
#endif

using RecordIdCallback = std::add_pointer_t<void(uint64_t recordId)>;

struct Finch_Vector2 {
    double x;
    double y;
};

struct Finch_Vector3 {
    double x;
    double y;
    double z;
};

struct Finch_Quaternion {
    double x;
    double y;
    double z;
    double w;
};

enum class Finch_Bool : uint8_t {
    False,
    True,
};

enum class Finch_ErrorCode : uint8_t {
    None,
    AlreadyInitialized,
    NotInitialized,
    IllegalArgument,
    RuntimeError,
};

enum class Finch_NodeType : uint8_t {
    Hand,
    UpperArm,
    LowerArm,
};

enum class Finch_Node : uint8_t {
    RightHand,
    LeftHand,
    RightUpperArm,
    LeftUpperArm,
    RightLowerArm,
    LeftLowerArm,
};

enum class Finch_Chirality : uint8_t {
    Right,
    Left,
    Both,
};

enum class Finch_ControllerType : uint8_t {
    Dash,
    Shift,
    Ring,
    RingX,
};

enum class Finch_DashElement : uint16_t {
    HomeButton          = 0x1 << 7,
    ButtonOne           = 0x1 << 0,
    ButtonTwo           = 0x1 << 1,
    ButtonThree         = 0x1 << 2,
    ButtonFour          = 0x1 << 3,
    ButtonThumb         = 0x1 << 9,
    Touch               = 0x1 << 15,
    Trigger             = 0x1 << 4,
    ButtonGrip          = 0x1 << 5,
    IsTouchPadAvailable = 0x1 << 11,

    ManualCalibrationCounter = 0x1 << 13,
    ManualCalibrationResult  = 0x1 << 14,
};

enum class Finch_ShiftElement : uint16_t {
    HomeButton          = 0x1 << 7,
    ButtonOne           = 0x1 << 0,
    ButtonTwo           = 0x1 << 1,
    ButtonThree         = 0x1 << 2,
    ButtonFour          = 0x1 << 3,
    ButtonThumb         = 0x1 << 9,
    Touch               = 0x1 << 15,
    Trigger             = 0x1 << 4,
    ButtonGrip          = 0x1 << 5,
    LeftCapacity        = 0x1 << 6,
    RightCapacity       = 0x1 << 8,
    LedChirality        = 0x1 << 10,
    IsLedOn             = 0x1 << 12,
    IsTouchPadAvailable = 0x1 << 11,

    ManualCalibrationCounter = 0x1 << 13,
    ManualCalibrationResult  = 0x1 << 14,
};

enum class Finch_RingElement : uint16_t {
    HomeButton      = 0x1 << 7,
    Touch           = 0x1 << 15,
    SwipeCounter    = 0x1 << 6,
    Tap             = 0x1 << 5,
    SwipeUp         = 0x1 << 0,
    SwipeDown       = 0x1 << 1,
    SwipeLeft       = 0x1 << 2,
    SwipeRight      = 0x1 << 3,
    CapacitySensor  = 0x1 << 8,
    ChargeCaseState = 0x1 << 9,
    Analog          = 0x1 << 4,

    ManualCalibrationCounter = 0x1 << 13,
    ManualCalibrationResult  = 0x1 << 14,
};

enum class Finch_CalibrationType : uint8_t {
    None,               // Don't call calibrate next update.
    Forward,            // Sets forward direction of user by forward direction.
    Hmd,                // Sets forward direction of user by current horizontal hmd direction.
    TargetDirection,    // Sets forward direction of user by selected direction.
    TargetControllers,  // Sets forward direction of user by selected direction of hands.
    ExternalRewrite,    // Apply calibration quaternions from external source. Values were not set will become identity.
    ExternalAppend,     // Apply calibration quaternions from external source. Values were not set will be saved from previous calibration.
    Reset,              // Reset calibration.
};

enum class Finch_CalibrationOption : uint8_t {
    TPose       = 0x1 << 0,
    ResetTPose  = 0x1 << 1,
    Revert      = 0x1 << 2,
    ResetRevert = 0x1 << 3,
    Deferred    = 0x1 << 4
};

enum class Finch_BodyRotationMode : uint8_t {
    None,
    HandRotation,
    HandMotion,
    HmdRotation,
    ShoulderRotationA,
    ShoulderRotationB,
    OneShoulderRotation
};

enum class Finch_BoneType : uint8_t {
    Hand,
    UpperArm,
    LowerArm,
    HeadBase,
    Neck,
    Chest,
    ShoulderBlade,
};

enum class Finch_Bone : uint8_t {
    RightHand,
    LeftHand,
    RightUpperArm,
    LeftUpperArm,
    RightLowerArm,
    LeftLowerArm,
    HeadBase,
    Neck,
    Chest,
    RightShoulderBlade,
    LeftShoulderBlade,
};

enum class Finch_PlatformType : uint8_t {
    External,
    Internal,
    Unity3D,
};

enum class Finch_ScannerType : uint8_t {
    Bonded,
    BA,  // Bonded and Advertising, with Bonded priority.
    Advertising,
};

enum class Finch_UpdateOption : uint8_t {
    Internal       = 0x1 << 0,
    HmdOrientation = 0x1 << 1,
    HmdPosition    = 0x1 << 2,
};

enum class Finch_ImuDataOption : uint8_t {
    GlobalCs   = 0x1 << 0,
    LocalCs    = 0x1 << 1,
    Calculated = 0x1 << 2,  // Otherwise from raw data.
    Smoothed   = 0x1 << 3,
};

enum class Finch_RotationType : uint8_t {
    TPose,
    FPose,
};

enum class Finch_CalibrationAdjustOption : uint8_t {
    IsPre                 = 0x1 << 0,
    IsPost                = 0x1 << 1,
    UseDefaultCS          = 0x1 << 2,
    TrackingA             = 0x1 << 3,
    TrackingB             = 0x1 << 4,
    RelativeHorizontalHmd = 0x1 << 5,
};

enum class Finch_Feature : uint8_t {
    UseConvergedPositions     = 0,
    UseSmoothedPositions      = 1,
    UseInputHmdFixes          = 3,
    UseFCalibrationPose       = 4,
    Use6NodesMode             = 5,
    UseOpticalTracking        = 6,
    RotateY40FPoseControllers = 7,
};

enum class Finch_LoggerLevel : uint8_t {
    Profiler,
    Debug,
    Info,
    Warn,
    Error,
    Critical,
    Off,
};

enum class Finch_OpticalAnnResponse : uint8_t {
    InFov,
    OutOfFov,
    NotRecognised,
};
