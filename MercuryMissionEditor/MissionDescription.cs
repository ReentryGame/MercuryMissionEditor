using System;
using System.Collections.Generic;
using MercuryV2;

namespace MercuryV2.Mission
{
    public class MissionDescription
    {
        public enum SpacePrograms { Mercury = 0, Gemini = 1, Apollo = 2 };

        public SpacePrograms SpaceProgram { get; set; } = SpacePrograms.Mercury;
        public enum RocketType
        {
            MercuryRedstone, MercuryAtlas
        }
        public RocketType Rocket = RocketType.MercuryRedstone;

        public bool StartInOrbit = false;
        public DateTime ScheduledLaunchTime;
        public TimeSpan InitialTimeToRetrograde = TimeSpan.FromMinutes(120.0f);

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BriefingText { get; set; }
        public int FlightPlanPrefabId { get; set; }
        public float MinutesBeforeLaunch { get; set; }

        public float TargetAp { get; set; }
        public float TargetPe { get; set; }
        public float Inclination { get; set; }
        public bool DisableDefaultAudioSFX { get; set; } = false;
        public string LoadState { get; set; } = "";

        public List<MissionCommand> MissionCommands = new List<MissionCommand>();
        public List<MissionGoals> MissionGoals = new List<MissionGoals>();
        public List<MissionActivity> MissionActivities = new List<MissionActivity>();
        internal bool Complete = false;

        public MissionDescription()
        {

        }

        public void AddCommand(MissionCommand mc)
        {
            MissionCommands.Add(mc);
        }
    }

    public class MissionActivity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public float TimeLimit { get; set; }
        public bool Started;
        public bool Completed;
        public bool Cancelled;

        public List<ActivityStep> Steps = new List<ActivityStep>();
    }

    public class ActivityStep
    {
        public enum StepGoal
        {
            Yaw_Degrees_Value1,
            Roll_Degrees_Value1,
            Pitch_Degrees_Value1,
            Require_FlightMode,
            GoToAttitude_Pitch_Value1_Yaw_Value2_Roll_Value3,
            WaitForSeconds_Value1,
            AttainAngularRate_1Pitch_2Roll_3Yaw
        };
        public enum ASCSConfiguration { ASCSAuto, AUXDamp, FBW, RSCS, Manual, ManualAndASCSAuto, ManualPropAndFlyByWire, RSCSAndFBW, AUXDampAndManual };
        public StepGoal Goal { get; set; }
        public string Description { get; set; }
        public ASCSConfiguration FlightMode { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public string Progress;
        public bool Completed;
    }

    public class MissionGoals
    {
        public enum GoalType { ReachAltitude_Target1, ReachOrbit_PeTarget1_ApTarget2, Splashdown, CompleteActivityWithIndex_Target1, OrbitEarthNumTimes_Value1 }
        public GoalType Type { get; set; }
        public string Description { get; set; }
        public float Target1 { get; set; }
        public float Target2 { get; set; }
        public float Target3 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string Progress;
        public bool Completed;
    }

    public class MissionCommand
    {
        public enum MessageIsFrom { Commander, MCC };
        public enum Failiure { NULL, DriftYawRight }

        public enum ExecuteAction
        {
            Message = 0, // Deliver message only

            // 10 group. orbit checks
            IsAp_Value1 = 10,
            IsPe_Value1,
            IsAp_Value1_IsPe_Value2,
            IsInclination_Value1,
            WaitUntilCompletedNrOrbits,

            // 30 group - radio checks
            IsAtRadioStation_String1 = 30,
            PerformBloodCheck,

            // 50 group - altitude and such
            AltitudeLess_Value1 = 50,
            AltitudeGreater_Value1,
            AtCoordinate_Value1_Value2,
            Altitude_Landing_Feet_LessThan_Value1,
            Longitude_Between_Value1_Value2,
            Latitude_Between_Value1_Value2,

            // 70 group - spacecraft specific
            Seperation_Booster = 70,
            Seperation_Tower,
            Seperation_LV,
            Seperation_Retro,
            State_Dot05GDetected,
            State_InHiDragZone,
            State_OutsideHighDragZone,
            State_DrogueDeploy,
            State_MainDeploy,
            State_UmbillicalDisconnect,
            State_RetroSequenceStarting,
            State_RetroBurning,
            State_Splashdown,
            State_SECO,

            // 100 group
            CheckPin_PinID_PinPositin = 100,
            CheckFuse_FuseID_Bool1,
            CheckPullHandle_PullHandleID_PullDirection,
            CheckKnobIdSelection_Value1,

            // 1000 group
            ResetTimestamp = 1000,
            ActivityCompleted_Value1,
            StartOrbitParticles,
            StopOrbitParticles,
            StartFailiure,
            StopFailiure,
            CompleteMission
        }

        public ExecuteAction Action { get; set; }
        public float Timestamp { get; set; }
        public float DisplayTime { get; set; } = 3.0f;
        public MessageIsFrom From { get; set; } = MessageIsFrom.MCC;
        public string Message { get; set; }
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String3 { get; set; }
        public bool Bool1 { get; set; }
        public float ThresholdLimit { get; set; }
        public PinID PinID { get; set; }
        public PinPosition PinPosition { get; set; }
        public FuseID FuseID { get; set; }
        public DragHandleID PullHandleID { get; set; }
        public DragHandlePosition PullHandlePosition { get; set; }
        public KnobID KnobID { get; set; }
        public Failiure Fault { get; set; }
        public bool PlayAudioClip_String3 { get; set; }
        public bool Delivered;
        public bool Completed;
        public bool Priority;


        public MissionCommand()
        {

        }
    }
}