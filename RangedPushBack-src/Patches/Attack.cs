using BattleTech;
using Harmony;
using HBS.Logging;
using RangedPushBack.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RangedPushBack.Patches
{
    class Attack
    {
        [HarmonyPatch(typeof(AttackDirector.AttackSequence), "OnAttackSequenceGroupEnd")]
        public static class AttackSequence_OnAttackSequenceGroupEnd_Patch
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
                    logger.LogAtLevel(LogLevel.Debug, $"OnAttackSequenceGroupEnd method called. Attacker: {__instance.attacker.DisplayName}, Target: {__instance.chosenTarget.DisplayName}");

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
                            logger.LogAtLevel(LogLevel.Debug, $"Before adding target - processedTargets count: {processedTargets.Count}");
                            processedTargets.Add(Target);
                            logger.LogAtLevel(LogLevel.Debug, $"After adding target - processedTargets count: {processedTargets.Count}");
                            if (Target != null)
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBack enemies from Attack Sequence Resolve Damage");
                                if (pilot.HasPushBackOne())
                                {
                                    Target.ForceUnitOnePhaseDown(attacker.GUID, __instance.stackItemUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                                else if (pilot.HasPushBackFirst())
                                {
                                    Target.ForceUnitToFirstPhase();
                                    __instance.Director.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO FIRST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to First phase - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                                else if (pilot.HasPushBackLast())
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Director.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to Last phase - Attack");
                                    //logger.LogAtLevel(LogLevel.Debug, $"Weapon applied: {weapon.defId}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
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
            }
        }

        //end of class
    }
}
