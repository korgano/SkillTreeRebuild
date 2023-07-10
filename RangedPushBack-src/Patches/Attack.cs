using BattleTech;
using BattleTech.Save.SaveGameStructure;
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
        //public static object hitInfo { get; private set; }

        //[HarmonyPatch(typeof(AttackDirector), "OnAttackSequenceResolveDamage")]
        //[HarmonyPostfix]
        /*public void OnAttackSequenceResolveDamage(MessageCenterMessage message, AttackDirector __instance, AbstractActor attacker, ICombatant chosenTarget, int stackItemUID)
        {
            var SelectedTarget = chosenTarget as AbstractActor;
            var logger = HBS.Logging.Logger.GetLogger("RangedPushBack"); Pilot pilot = attacker.GetPilot();
            if (pilot.HasPushBackOne())
            {
                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from OnAttackSequenceResolveDamage");
                if (SelectedTarget != null)
                {
                    SelectedTarget.ForceUnitOnePhaseDown(attacker.GUID, stackItemUID, false);
                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                }

            }
            else if (pilot.HasPushBackLast())
            {
                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from OnAttackSequenceResolveDamage");
                if (SelectedTarget != null)
                {
                    SelectedTarget.ForceUnitToLastPhase();
                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(SelectedTarget.GUID, SelectedTarget.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                }
            }

            AttackSequenceResolveDamageMessage attackSequenceResolveDamageMessage = (AttackSequenceResolveDamageMessage)message;
            WeaponHitInfo hitInfo = attackSequenceResolveDamageMessage.hitInfo;
            if (hitInfo.attackSequenceId != AttackDirector.AttackSequence.id)
            {
                return;
            }
            if (!AttackDirector.AttackSequence.messageCoordinator.CanProcessMessage(attackSequenceResolveDamageMessage))
            {
                this.messageCoordinator.StoreMessage(attackSequenceResolveDamageMessage);
                return;
            }
            if (AttackDirector.AttackSequence.logger.IsLogEnabled)
            {
                AttackDirector.AttackSequence.logger.Log(string.Format("[OnAttackSequenceResolveDamage]  ID {0}, Group {1}, Weapon {2}, AttackerId [{3}], TargetId [{4}]", new object[] { AttackDirector.AttackSequence.id, hitInfo.attackGroupIndex, hitInfo.attackWeaponIndex, hitInfo.attackerId, hitInfo.targetId }));
            }
            int attackGroupIndex = attackSequenceResolveDamageMessage.hitInfo.attackGroupIndex;
            int attackWeaponIndex = attackSequenceResolveDamageMessage.hitInfo.attackWeaponIndex;
            Weapon weapon = AttackDirector.AttackSequence.GetWeapon(attackGroupIndex, attackWeaponIndex);
            if (AttackDirector.AttackSequence.meleeAttackType == MeleeAttackType.DFA)
            {
                float num = Mathf.Max(0f, AttackDirector.AttackSequence.attacker.StatCollection.GetValue("DFASelfDamage"));
                AttackDirector.AttackSequence.attacker.TakeWeaponDamage(attackSequenceResolveDamageMessage.hitInfo, 64, weapon, num, 0f, 0, DamageType.DFASelf);
                AttackDirector.AttackSequence.attacker.TakeWeaponDamage(attackSequenceResolveDamageMessage.hitInfo, 128, weapon, num, 0f, 0, DamageType.DFASelf);
                if (AttackDirector.damageLogger.IsLogEnabled)
                {
                    AttackDirector.damageLogger.Log(string.Format("@@@@@@@@ {0} takes {1} damage to its legs from the DFA attack!", AttackDirector.AttackSequence.attacker.DisplayName, num));
                }
            }
            List list = new List();
            AttackDirector.AttackSequence.chosenTarget.ResolveWeaponDamage(attackSequenceResolveDamageMessage.hitInfo);
            list.Add(AttackDirector.AttackSequence.chosenTarget);
            if (hitInfo.GetFirstHitLocationForTarget(AttackDirector.AttackSequence.chosenTarget.GUID) >= 0)
            {
                AttackDirector.AttackSequence.attackCompletelyMissed = false;
            }
            for (int i = 0; i < attackSequenceResolveDamageMessage.hitInfo.secondaryTargetIds.Length; i++)
            {
                ICombatant combatant = AttackDirector.AttackSequence.Director.Combat.FindCombatantByGUID(attackSequenceResolveDamageMessage.hitInfo.secondaryTargetIds[i], false);
                if (combatant != null && !list.Contains(combatant))
                {
                    list.Add(combatant);
                    combatant.ResolveWeaponDamage(attackSequenceResolveDamageMessage.hitInfo);
                }
            }
            AttackDirector.AttackSequence attackSequence = AttackDirector.AttackSequence.Director.GetAttackSequence(hitInfo.attackSequenceId);
            for (int j = 0; j < attackSequence.allAffectedTargetIds.Count; j++)
            {
                AbstractActor abstractActor = AttackDirector.AttackSequence.Director.Combat.FindActorByGUID(attackSequence.allAffectedTargetIds[j]);
                if (abstractActor != null)
                {
                    int firstHitLocationForTarget = hitInfo.GetFirstHitLocationForTarget(abstractActor.GUID);
                    if (firstHitLocationForTarget >= 0 && !abstractActor.IsDead)
                    {
                        foreach (EffectData effectData in weapon.weaponDef.statusEffects)
                        {
                            if (effectData.targetingData.effectTriggerType == EffectTriggerType.OnHit)
                            {
                                string text = string.Format("{0}Effect_{1}_{2}", effectData.targetingData.effectTriggerType.ToString(), AttackDirector.AttackSequence.attacker.GUID, attackSequenceResolveDamageMessage.hitInfo.attackSequenceId);
                                AttackDirector.AttackSequence.Director.Combat.MessageCenter.PublishMessage(new EffectTriggerMessage(text, abstractActor.GUID, effectData, hitInfo.attackerId, attackSequenceResolveDamageMessage.hitInfo.attackSequenceId, firstHitLocationForTarget, attackSequenceResolveDamageMessage.hitInfo.attackWeaponIndex, attackSequenceResolveDamageMessage.hitInfo.attackGroupIndex));
                            }
                        }
                    }
                }
            }
        }*/


        /*[HarmonyPatch(typeof(AttackDirector), "OnAttackSequenceResolveDamage")]
        public static class AttackDirector_OnAttackSequenceResolveDamage_Patch
        {
            public static void Postfix(MessageCenterMessage message, AttackDirector __instance, AbstractActor attacker, ICombatant chosenTarget, int stackItemUID)
            {
                AttackSequenceResolveDamageMessage attackSequenceResolveDamageMessage = (AttackSequenceResolveDamageMessage)message;
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "attackSequenceResolveDamageMessage value initialized");
                if (message == attackSequenceResolveDamageMessage)
                {
                    var SelectedTarget = chosenTarget as AbstractActor;
                    logger.LogAtLevel(LogLevel.Debug, "attackSequenceResolveDamageMessage changed");
                    Pilot pilot = attacker.GetPilot();
                    if (pilot.HasPushBackOne())
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from OnAttackSequenceResolveDamage");
                        if (SelectedTarget != null)
                        {
                            SelectedTarget.ForceUnitOnePhaseDown(attacker.GUID, stackItemUID, false);
                            logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                        }

                    }
                    else if (pilot.HasPushBackLast())
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from OnAttackSequenceResolveDamage");
                        if (SelectedTarget != null)
                        {
                            SelectedTarget.ForceUnitToLastPhase();
                            __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(SelectedTarget.GUID, SelectedTarget.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                            logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                        }
                    }
                }
            }
        }*/

        //[HarmonyPostfix]
        /*public static void OnAttackSequenceResolveDamage_Postfix(MessageCenterMessage message, AttackDirector.AttackSequence __instance)
        {
            var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");

            AttackDirector.AttackSequence attackSequence = __instance.Director.GetAttackSequence(hitInfo.attackSequenceId);
            if (attackSequence != null)
            {
                ICombatant attacker = __instance.attacker;
                ICombatant chosenTarget = __instance.chosenTarget;
                Pilot pilot = __instance.attacker.GetPilot();
                if (pilot.HasPushBackOne())
                {
                    chosenTarget.ForceUnitOnePhaseDown(attacker.GUID, __instance.SequenceGUID, false);
                }
                else if (pilot.HasPushBackLast())
                {
                    chosenTarget.ForceUnitToLastPhase();
                }
            }
        }*/

        /*[HarmonyPatch(typeof(AttackDirector), "OnAttackComplete")]
        public static class AttackDirector_OnAttackComplete_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(AttackDirector __instance, MessageCenterMessage message)
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                AttackCompleteMessage attackCompleteMessage = (AttackCompleteMessage)message;
                int sequenceId = attackCompleteMessage.sequenceId;
                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne attack sequence complete message IDs");
                AttackDirector.AttackSequence attackSequence = __instance.GetAttackSequence(sequenceId);
                AbstractActor abstractActor = attackSequence.chosenTarget as AbstractActor;
                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne attack targets");
                if (attackSequence != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne attack sequence");
                    if (attackSequence.attacker.GetPilot().HasPushBackOne())
                    {
                        Pilot pilotName = attackSequence.attacker.GetPilot();
                        string actorName = pilotName.ToString();
                        abstractActor.ForceUnitOnePhaseDown(actorName, attackCompleteMessage.stackItemUID, false);
                        logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                    }
                    else if (attackSequence.attacker.GetPilot().HasPushBackLast())
                    {
                        abstractActor.ForceUnitToLastPhase();
                        string Target = abstractActor.ToString();
                        __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target, Target, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                        logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                    }
                }
            }

        }*/

        //[HarmonyPatch(typeof(AttackStackSequence), "OnAttackComplete")]
        //public static class AttackStackSequence_OnAttackComplete_Patch
        //{
        /*public static bool Prefix(AttackStackSequence __instance, MessageCenterMessage message)
        {
            Pilot pilot = __instance.owningActor.GetPilot();
            var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
            if ((message as AttackCompleteMessage).stackItemUID == __instance.SequenceGUID)
            {
                if (__instance.willConsumeFiring)
                {
                    for (int i = 0; i < __instance.directorSequences[0].allAffectedTargetIds.Count; i++)
                    {
                        ICombatant combatant = __instance.Combat.FindCombatantByGUID(__instance.directorSequences[0].allAffectedTargetIds[i], false);
                        logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Attack Stack Sequence");
                        if (combatant != null)
                        {
                            combatant.HandleDeath(__instance.owningActor.GUID);
                            if (!combatant.IsDead)
                            {
                                logger.LogAtLevel(LogLevel.Debug, "PushBackOne Enemy is not dead");
                                AbstractActor abstractActor = combatant as AbstractActor;
                                if (abstractActor != null)
                                {
                                    abstractActor.CheckForInstability();
                                    abstractActor.HandleKnockdown(__instance.RootSequenceGUID, __instance.owningActor.GUID, Vector2.one, null);
                                    if (pilot.HasPushBackOne())
                                    {
                                        abstractActor.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                                        logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies");
                                    }
                                    if (pilot.HasPushBackLast())
                                    {
                                        abstractActor.ForceUnitToLastPhase();
                                        logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase");
                                        __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(abstractActor.GUID, abstractActor.GUID, "PUSHED TO INITIATIVE 1", FloatieMessage.MessageNature.Debuff));
                                        logger.LogAtLevel(LogLevel.Debug, "Generating push enemy to last phase message");
                                    }
                                    continue;
                                }
                            }
                        }
                    }
                }
                __instance.directorSequences.RemoveAt(0);
                AttackStackSequence.attackLogger.Log(string.Concat(new object[]
                {
            "OnAttackComplete for stackSequence ",
            __instance.SequenceGUID,
            ", remaining sequences: ",
            __instance.directorSequences.Count
                }));
                if (__instance.directorSequences.Count == 0)
                {
                    __instance.OrdersAreComplete = true;
                    __instance.Combat.MessageCenter.RemoveSubscriber(MessageCenterMessageType.OnAttackComplete, new ReceiveMessageCenterMessage(__instance.OnAttackComplete));
                    return false;
                }
                __instance.state = AttackStackSequence.ASS_State.Delaying;
            }
            return true;
        }
    }*/


        /*catch (Exception e)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Error, (e));
        }*/
    }
    }
