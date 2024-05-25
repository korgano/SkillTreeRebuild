using BattleTech;
using BattleTech.Serialization;
using Harmony;
using HBS.Logging;
using RangedPushBack.Extensions;
using System;
using System.Collections.Generic;

namespace RangedPushBack.Patches
{
    class ActiveProbe
    {
        [HarmonyPatch(typeof(ActiveProbeSequence), "StripEvasivePips")]
        public static class ActiveProbeSequence_StripEvasivePips_Patch
        {

            static void Postfix(ActiveProbeSequence __instance, AbstractActor Target)
            {
                try
                {
                    var logger = Logger.GetLogger("RangedPushBack");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance: {__instance}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor: {__instance.owningActor.DisplayName}");
                    logger.LogAtLevel(LogLevel.Debug, $"Target: {Target.DisplayName}");
                    //logger.LogAtLevel(LogLevel.Debug, $"__ability: {__ability}");

                    Pilot pilot = __instance.owningActor.GetPilot();
                    Mech mech = __instance.owningActor as Mech;
                    logger.LogAtLevel(LogLevel.Debug, $"Mech component ActiveProbe check: {mech.HasActiveProbeGear()}");
                    if (((pilot.HasPushBackOne_Probe() == true) && (pilot.HasActiveProbeAbility() == true)) || (mech.HasActiveProbeGear() == true))
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Active Probe Sequence");
                        if (Target != null)
                        {
                            Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                            logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Active Probe");
                        }
                    }
                    else if (((pilot.HasPushBackFirst_Probe() == true) && (pilot.HasActiveProbeAbility() == true)) || (mech.HasActiveProbeGear() == true))
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackFirst enemies from Active Probe Sequence");
                        if (Target != null)
                        {
                            Target.ForceUnitToLastPhase();
                            __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO FIRST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                            logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to First phase - Active Probe");
                        }
                    }
                    else if (((pilot.HasPushBackLast_Probe()==true) && (pilot.HasActiveProbeAbility()==true)) || (mech.HasActiveProbeGear()==true))
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from Active Probe Sequence");
                        if (Target != null)
                        {
                            Target.ForceUnitToLastPhase();
                            __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                            logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to Last phase - Active Probe");
                        }
                    }
                }

                catch (Exception e)
                {
                    var logger = Logger.GetLogger("RangedPushBack");
                    logger.LogAtLevel(LogLevel.Error, (e));
                }

                //return null;
            }
        }
    }
}
