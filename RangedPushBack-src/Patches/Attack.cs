using BattleTech;
<<<<<<< HEAD
using BattleTech.Data;
using BattleTech.DataObjects;
using BattleTech.Save.SaveGameStructure;
using BattleTech.StringInterpolation;
=======
>>>>>>> test
using Harmony;
using HBS.Logging;
using RangedPushBack.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RangedPushBack.Patches
{
    class Attack
    {
<<<<<<< HEAD
        private static bool hasLogged = false;
        // To track whether the log has been executed
        /*[HarmonyPatch(typeof(AttackDirector.AttackSequence), "OnAttackSequenceResolveDamage")]
        public static class AttackSequence_OnAttackSequenceResolveDamage_Patch
=======
        [HarmonyPatch(typeof(AttackDirector.AttackSequence), "OnAttackSequenceGroupEnd")]
        public static class AttackSequence_OnAttackSequenceGroupEnd_Patch
>>>>>>> test
        {
            // Create a HashSet to store the AbstractActor Targets that have already been processed
            public static HashSet<AbstractActor> processedTargets = new HashSet<AbstractActor>();

            static void Postfix(AttackDirector.AttackSequence __instance, MessageCenterMessage message)
            {
                try
                {
                    var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance: {__instance}");
<<<<<<< HEAD
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor: {__instance.attacker.DisplayName}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor type: {__instance.attacker.UnitType}");

                    AttackSequenceResolveDamageMessage attackSequenceResolveDamageMessage = (AttackSequenceResolveDamageMessage)message;
                    int attackGroupIndex = attackSequenceResolveDamageMessage.hitInfo.attackGroupIndex;
                    int attackWeaponIndex = attackSequenceResolveDamageMessage.hitInfo.attackWeaponIndex;
                    Weapon weapon = __instance.GetWeapon(attackGroupIndex, attackWeaponIndex);

                    Pilot pilot = __instance.attacker.GetPilot();
                    AbstractActor attacker = __instance.attacker;
                    //Mech mech = __instance.attacker as Mech;
=======
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.CurrentRound: {__instance.Director.Combat.TurnDirector.CurrentRound} - Phase: {__instance.Director.Combat.TurnDirector.CurrentPhase}");
                    logger.LogAtLevel(LogLevel.Debug, $"OnAttackSequenceGroupEnd method called. Attacker: {__instance.attacker.DisplayName}, Target: {__instance.chosenTarget.DisplayName}");

                    Pilot pilot = __instance.attacker.GetPilot();
                    AbstractActor attacker = __instance.attacker;
>>>>>>> test
                    ICombatant combatant = __instance.chosenTarget;
                    if (combatant is AbstractActor Target)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Target: {Target.DisplayName}");
                        // Check if the Target has already been processed
                        if (!processedTargets.Contains(Target))
                        {
                            logger.LogAtLevel(LogLevel.Debug, $"Does ProcessedTargets include target: {processedTargets.Contains(Target)}");
                            // Add the Target to the processedTargets HashSet
<<<<<<< HEAD
                            //logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.DisplayName}: Has Active Probe = {pilot.HasActiveProbeAbility()}, Mech has Active Probe Gear = {mech.HasActiveProbeGear()}");
                            processedTargets.Add(Target);
                            if (Target != null)
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBack enemies from Attack Sequence Resolve Damage");
                                //if (pilot.HasPushBackOne() && (!(pilot.HasPushBackOne_Probe() == true) || !(pilot.HasPushBackLast_Probe() == true)))
=======
                            logger.LogAtLevel(LogLevel.Debug, $"Before adding target - processedTargets count: {processedTargets.Count}");
                            processedTargets.Add(Target);
                            logger.LogAtLevel(LogLevel.Debug, $"After adding target - processedTargets count: {processedTargets.Count}");
                            if (Target != null)
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBack enemies from Attack Sequence Resolve Damage");
>>>>>>> test
                                if (pilot.HasPushBackOne())
                                {
                                    Target.ForceUnitOnePhaseDown(attacker.GUID, __instance.stackItemUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Attack");
<<<<<<< HEAD
                                    logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                                //else if (pilot.HasPushBackLast() && (!(pilot.HasPushBackOne_Probe() == true) || !(pilot.HasPushBackLast_Probe() == true)))
=======
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                                else if (pilot.HasPushBackFirst())
                                {
                                    Target.ForceUnitToFirstPhase();
                                    __instance.Director.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO FIRST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to First phase - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
>>>>>>> test
                                else if (pilot.HasPushBackLast())
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Director.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
<<<<<<< HEAD
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase - Attack");
                                    logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
=======
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to Last phase - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
>>>>>>> test
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
<<<<<<< HEAD
                    logger.LogError(ex);
                }
            }
        }*/
        [HarmonyPatch(typeof(AttackDirector.AttackSequence), "OnAttackSequenceResolveDamage")]
        public static class AttackSequence_OnAttackSequenceResolveDamage_Patch
        {
            // Create a HashSet to store the AbstractActor Targets that have already been processed
            public static HashSet<AbstractActor> processedTargets = new HashSet<AbstractActor>();

            static void Postfix(AttackDirector.AttackSequence __instance, MessageCenterMessage message)
            {
                try
                {
                    var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance: {__instance}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.CurrentRound: {__instance.Director.Combat.TurnDirector.CurrentRound} - Phase: {__instance.Director.Combat.TurnDirector.CurrentPhase}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor: {__instance.attacker.DisplayName}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor type: {__instance.attacker.UnitType}");

                    Pilot pilot = __instance.attacker.GetPilot();
                    AbstractActor attacker = __instance.attacker;
                    ICombatant combatant = __instance.chosenTarget;
                    if (combatant is AbstractActor Target)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Target: {Target.DisplayName}");
                        // Check if the Target has already been processed
                        if (!processedTargets.Contains(Target))
                        {
                            logger.LogAtLevel(LogLevel.Debug, $"Does ProcessedTargets include target: {processedTargets.Contains(Target)}");
                            // Add the Target to the processedTargets HashSet
                            processedTargets.Add(Target);
                            if (Target != null)
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBack enemies from Attack Sequence Resolve Damage");
                                if (pilot.HasPushBackOne())
                                {
                                    Target.ForceUnitOnePhaseDown(attacker.GUID, __instance.stackItemUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                                else if (pilot.HasPushBackLast())
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Director.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                    logger.LogError(ex);
                }
            }
        }

        [HarmonyPatch(typeof(Team), "OnPhaseEnd")]
        public static class Team_OnPhaseEnd_Patch
        {
            public static void Postfix(ref List<IStackSequence> __result, int phase)
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");

                if (__result != null && __result.Count > 0)
                {
                    // Log only once when List<IStackSequence> begins iterating
                    if (!hasLogged)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Team_OnPhaseEnd_Patch triggered");
                        hasLogged = true;
                    }

                    // Loop through the stack sequences
                    for (int i = 0; i < __result.Count; i++)
                    {
                        IStackSequence stackSequence = __result[i];

                        // Check if this is the final item in the list
                        bool isFinalItem = i == __result.Count - 1;

                        // Execute the line to clear the processedTargets list after OnPhaseEnd has returned list
                        AttackSequence_OnAttackSequenceResolveDamage_Patch.processedTargets.Clear();

                        // Log only for the final item
                        if (isFinalItem)
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Executed AttackSequence_OnAttackSequenceResolveDamage_Patch processed targets wipe at Team.OnPhaseEnd");
                        }
                    }
                }
=======
                    logger.LogError($"Exception in AttackSequence_OnAttackSequenceResolveDamage_Patch: {ex.GetType().Name} - {ex.Message}");
                }
            }
        }

        [HarmonyPatch(typeof(TurnDirector), "OnRoundEndComplete")]
        public static class TurnDirector_OnRoundEndComplete_Patch
        {
            static void Postfix()
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                // Erase the processedTargets HashSet
                AttackSequence_OnAttackSequenceGroupEnd_Patch.processedTargets.Clear();
                logger.LogAtLevel(LogLevel.Debug, "Executed AttackSequence_OnAttackSequenceGroupEnd_Patch processed targets wipe via PostFix TurnDirector.OnRoundEndComplete patch");
>>>>>>> test
            }
        }

        //end of class
    }
}
