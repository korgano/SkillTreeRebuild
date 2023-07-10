using BattleTech;
using BattleTech.Save.SaveGameStructure;
using BattleTech.StringInterpolation;
using Harmony;
using HBS.Logging;
using Newtonsoft.Json.Linq;
using RangedPushBack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RangedPushBack.Patches
{
    internal class Mortar
    {
        [HarmonyPatch(typeof(MechMortarSequence), MethodType.Constructor)]
        [HarmonyPatch(new[] { typeof(AbstractActor), typeof(List<Vector3>), typeof(List<ICombatant>), typeof(Weapon), typeof(Ability) })]
        public static class MechMortarSequence_RefWeapon_Patch
        {
            public static void Postfix(MechMortarSequence __instance, Weapon referenceWeapon)
            {
                //Updates initial MechMortarSequence function to support bigger list of Thumper cannons
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                __instance.isThumper = ModInit.Settings.ThumperIDs.Contains(referenceWeapon.Description.Id);
                logger.LogAtLevel(LogLevel.Debug, "Checked list of Thumper IDs");
            }
        }

        //==================================================================================================================//

        [HarmonyPatch(typeof(MechMortarSequence), "OnImpact")]
        public static class MechMortarSequence_OnImpact_PushBackPatch
        {
            public static void Postfix(MechMortarSequence __instance)
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                try
                {
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        if (combatant is AbstractActor Target)
                        {
                            Mech mech = __instance.OwningMech;
                            if (mech.HasPushBackOne())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                                }
                            }
                            else if (mech.HasPushBackLast())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies  from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogAtLevel(LogLevel.Error, $"An exception occurred in MechMortarSequence_OnImpact_Patch: {ex}");
                }
            }
        }

        /*
        [HarmonyPatch(typeof(MechMortarSequence), "OnImpact")]
        public static class MechMortarSequence_OnImpact_Patch
        {
            public static void Postfix(MechMortarSequence __instance)
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                try
                {
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        if (combatant is AbstractActor Target)
                        {
                            Mech mech = __instance.OwningMech;
                            if (mech.HasPushBackOne())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                                }
                            }
                            else if (mech.HasPushBackLast())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies  from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogAtLevel(LogLevel.Error, $"An exception occurred in MechMortarSequence_OnImpact_Patch: {ex}");
                }
            }
        }
         */

    }
}
