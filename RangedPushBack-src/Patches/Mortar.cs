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
using static BattleTech.AbilityDef;

namespace RangedPushBack.Patches
{
    class Mortar
    {
        static List<EffectData> GetArtilleryAbilityStatusEffects(Mech mech)
        {
            var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
            List<EffectData> abilityStatusEffects = new List<EffectData>();

            logger.LogAtLevel(LogLevel.Debug, $"Total components in mech {mech.DisplayName}: {mech.allComponents.Count}");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                var component = mech.allComponents[i];
                if (component.componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Running through {mech.DisplayName} component abilities - GetArtilleryAbilityStatusEffects");
                    for (int j = 0; j < component.componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = component.componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, $"Running check on Artillery Components for {mech.DisplayName} and AbilityDef = {abilityDef.Description.Id}");

                        if (abilityDef.specialRules == AbilityDef.SpecialRules.Artillery)
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Found Artillery");
<<<<<<< HEAD
                            //List<EffectData> abilityStatusEffectsForTriggerType = mech.GetComponentStatusEffectsForTriggerType(EffectTriggerType.OnHit);
=======
>>>>>>> test
                            List<EffectData> abilityStatusEffectsForTriggerType = mech.GetAbilityStatusEffectsForTriggerType(EffectTriggerType.OnHit);
                            logger.LogAtLevel(LogLevel.Debug, $"Detect Artillery on {mech.DisplayName} with status Effect Trigger: OnHit = {abilityDef.Description.Id}");
                            logger.LogAtLevel(LogLevel.Debug, $"Detect GetComponentStatusEffectsForTriggerType: {mech.GetAbilityStatusEffectsForTriggerType(EffectTriggerType.OnHit)}");

                            // Additional log to show the contents of abilityStatusEffectsForTriggerType
                            foreach (EffectData effectData in abilityStatusEffectsForTriggerType)
                            {
                                logger.LogAtLevel(LogLevel.Debug, $"EffectData on {mech.DisplayName} in abilityStatusEffectsForTriggerType: {effectData.Description.Id}");
                                abilityStatusEffects.Add(effectData); // Add the effectData to the list
                            }
                        }
                    }
                }
            }
            //return new List<EffectData>();
            return abilityStatusEffects; // Return the populated list

        }

        //==================================================================================================================//

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
                    Mech mech = __instance.OwningMech;
                    Pilot pilot = __instance.OwningMech.GetPilot();
                    logger.LogAtLevel(LogLevel.Debug, $"__instance: {__instance}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningMech: {__instance.OwningMech.DisplayName}");
                    logger.LogAtLevel(LogLevel.Debug, $"__instance.owningActor.Pilot: {__instance.OwningMech.GetPilot().Description.DisplayName}");
<<<<<<< HEAD

                    // Get the list of ability status effects from the pilot
                    List<EffectData> abilityStatusEffects = GetArtilleryAbilityStatusEffects(mech);
                    logger.LogAtLevel(LogLevel.Debug, $"Got Artillery Status Effects for {mech.DisplayName}: Count = {abilityStatusEffects.Count}");

                    // Loop through enemies hit during the impact
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Processing combatant: {combatant.DisplayName}");
                        foreach (EffectData effectData in abilityStatusEffects)
                        {
                            logger.LogAtLevel(LogLevel.Debug, $"Applying effect to {combatant.DisplayName}: {effectData.Description.Id}");

                            Weapon __referenceWeapon = __instance.referenceWeapon;
                            int firstHitLocationForTarget = default(WeaponHitInfo).GetFirstHitLocationForTarget(combatant.GUID);

                            // Construct a unique effect name based on attacker and target
                            string effectName = $"{effectData.targetingData.effectTriggerType}_{__instance.owningActor.GUID}_{combatant.GUID}";

                            // Create the effect using the EffectManager
                            __instance.Combat.EffectManager.CreateEffect(effectData, effectName, __instance.SequenceGUID, __instance.owningActor, combatant, default(WeaponHitInfo), firstHitLocationForTarget, false);
                            logger.LogAtLevel(LogLevel.Debug, $"Created StatusEffect from {AbilityDef.SpecialRules.Artillery}");
                            if (!effectData.targetingData.hideApplicationFloatie)
                            {
                                __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(__instance.owningActor.GUID, combatant.GUID, effectData.Description.Name, FloatieMessage.MessageNature.Debuff));
                            }
                        }
                    }
                
                    // Pushback Handling
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        if (combatant is AbstractActor Target)
                        {
//                            Mech mech = __instance.OwningMech;
                            Weapon __referenceWeapon = __instance.referenceWeapon;
                           
                            if (mech.HasPushBackOne())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Mortar");
                                }
                            }
                            else if (mech.HasPushBackLast())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to last phase - Mortar");
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

=======

                    // Get the list of ability status effects from the pilot
                    List<EffectData> abilityStatusEffects = GetArtilleryAbilityStatusEffects(mech);
                    logger.LogAtLevel(LogLevel.Debug, $"Got Artillery Status Effects for {mech.DisplayName}: Count = {abilityStatusEffects.Count}");

                    // Loop through enemies hit during the impact
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Processing combatant: {combatant.DisplayName}");
                        foreach (EffectData effectData in abilityStatusEffects)
                        {
                            logger.LogAtLevel(LogLevel.Debug, $"Applying effect to {combatant.DisplayName}: {effectData.Description.Id}");

                            Weapon __referenceWeapon = __instance.referenceWeapon;
                            int firstHitLocationForTarget = default(WeaponHitInfo).GetFirstHitLocationForTarget(combatant.GUID);

                            // Construct a unique effect name based on attacker and target
                            string effectName = $"{effectData.targetingData.effectTriggerType}_{__instance.owningActor.GUID}_{combatant.GUID}";

                            // Create the effect using the EffectManager
                            __instance.Combat.EffectManager.CreateEffect(effectData, effectName, __instance.SequenceGUID, __instance.owningActor, combatant, default(WeaponHitInfo), firstHitLocationForTarget, false);
                            logger.LogAtLevel(LogLevel.Debug, $"Created StatusEffect from {AbilityDef.SpecialRules.Artillery}");
                            if (!effectData.targetingData.hideApplicationFloatie)
                            {
                                __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(__instance.owningActor.GUID, combatant.GUID, effectData.Description.Name, FloatieMessage.MessageNature.Debuff));
                            }
                        }
                    }
                
                    // Pushback Handling
                    foreach (ICombatant combatant in __instance.Targets)
                    {
                        if (combatant is AbstractActor Target)
                        {
//                            Mech mech = __instance.OwningMech;
                            Weapon __referenceWeapon = __instance.referenceWeapon;
                           
                            if (mech.HasPushBackOne())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackOne enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitOnePhaseDown(__instance.owningActor.GUID, __instance.SequenceGUID, false);
                                    logger.LogAtLevel(LogLevel.Debug, "Applying -1 initiative to enemies - Mortar");
                                }
                            }
                            else if (mech.HasPushBackFirst())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackFirst enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitToFirstPhase();
                                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO FIRST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to First phase - Mortar");
                                }
                            }
                            else if (mech.HasPushBackLast())
                            {
                                logger.LogAtLevel(LogLevel.Debug, "Attempting to get PushBackLast enemies from Mech Mortar Sequence: On Impact");
                                if (Target != null)
                                {
                                    Target.ForceUnitToLastPhase();
                                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(Target.GUID, Target.GUID, "PUSHED TO LAST INITIATIVE PHASE", FloatieMessage.MessageNature.Debuff));
                                    logger.LogAtLevel(LogLevel.Debug, "Pushing enemy to Last phase - Mortar");
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

        //end of code
>>>>>>> test
    }
}
