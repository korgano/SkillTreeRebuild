using BattleTech;
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
                    Pilot pilot = __instance.owningActor.GetPilot();
                    if (pilot.HasPushBackOne())
                    {
                        var logger = Logger.GetLogger("RangedPushBack");
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Active Probe Sequence");
                        if (Target != null)
                        {
                            Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                            logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                        }
                    }
                    else if (pilot.HasPushBackLast())
                    {
                        var logger = Logger.GetLogger("RangedPushBack");
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from Active Probe Sequence");
                        if (Target != null)
                        {
                            Target.ForceUnitToLastPhase();
                            __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                            logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
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
