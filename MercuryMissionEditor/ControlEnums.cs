using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryV2
{
    public enum PinID
    {
        NULL, CabinLight, PhotoLight, LaunchControl, StbyBtry, IsolBtry, Ammeter,
        AudioBus, FansACBus, CabinFan, SuitFan, ASCSAC, ASCSMode, ASCSAuto, ASCSGyro,
        ArmSquib, RetroDelay, RetroAtt, AutoRetroJett, RetractScope, AttitudeSelect,
        WarningLightsBrightness, VOXSwitch, Beacon, Transmit, UHFSelect, UHFDF,
        TLMLoFreq, LandingBag, RescueAids, AudioCabinPress, AudioO2Emer, AudioFuelQuan,
        AudioRetroWarn, LightsTest, AudioH2OCabin, AudioH2OSuit, AudioRetroReset,
        InletValve, Maneuver
    };
    public enum PinPosition { NULL, Left, Middle, Right, Up, Down };

    public enum FuseID
    {
        NULL, SuitFan, InvrContrl, RetroJett, RetroMan, ProGramr, BloodPress,
        AntSwitch, ComvRcvrA, TrimHiFreq, EmerReserveDeploy, EmerLandBag, EmerRescueAids,
        PeriScope, ASCSDot05G, EmerDot05G, EmerDrogueDeploy, EmerMainDeploy, ReserveDeploy,
        AuxBcn, No1RetroRckt, No2RetroRckt, No3RetroRckt, EmerRetroSeq, EmerRetroJett,
        PhaseShifter, EmerCapSepCntrl, EmerEscapeRckt, TowerSepContrl, EmerTowerSep,
        EmerTowerJett, EmerPosgrd
    };
    public enum KnobID
    {
        NULL, DCSelector, ACSelector, RetroTimeModifier, CabinTemp, SuitTemp, InverterTemp,
        EPIInclination,
    };
    public enum DragHandleID
    {
        NULL, Decompress, Repressurize, ManualControl, RollLock, PitchLock, YawLock,
        RingJettTower, RingSepCapsule, RingOpenSnorkelNow, RingDeployMainNow,
        RingDeployReserveNow, EmerO2
    };
    public enum DragHandlePosition { NULL, In, Out };
}