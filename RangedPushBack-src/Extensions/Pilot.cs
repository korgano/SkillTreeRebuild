using BattleTech;
using BattleTech.StringInterpolation;
using HBS.Logging;
using RangedPushBack.Patches;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BattleTech.AbilityDef;
using Logger = HBS.Logging.Logger;

namespace RangedPushBack.Extensions
{
    public static class PilotExtensions
    {
        //=====================================Active Probe Targeting Check===========================================//
        /*public static bool HasActiveProbeAbility(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            if (pilot != null)
            {
                logger.LogAtLevel(LogLevel.Debug, "Checking Pilot for abilities that have Active Probe Targeting");
                Ability ability = pilot.Abilities.Find((Ability x) => x.Def.Targeting == AbilityDef.TargetingType.ActiveProbe);
                logger.LogAtLevel(LogLevel.Debug, $"Pilot has abilities that have Active Probe Targeting: {ability.Def.Id}");
                if (ability != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Pilot has Active Probe Targeting = True");
                    return true;
                }
            }
            logger.LogAtLevel(LogLevel.Debug, "Pilot has Active Probe Targeting = False");
            return false;
        }
        */
        public static bool HasActiveProbeAbility(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            if (pilot != null)
            {
                logger.LogAtLevel(LogLevel.Debug, "Checking Pilot for abilities that have Active Probe Targeting");
                Ability ability = pilot.Abilities.Find((Ability x) => x.Def.Targeting == AbilityDef.TargetingType.ActiveProbe);
                if (ability != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot {pilot.pilotDef.Description.DisplayName} has abilities that have Active Probe Targeting: {ability.Def.Id}");
                    logger.LogAtLevel(LogLevel.Debug, "Pilot has Active Probe Targeting = True");
                    return true;
                }
            }
            logger.LogAtLevel(LogLevel.Debug, $"Pilot {pilot.pilotDef.Description.DisplayName} has Active Probe Targeting = False");
            return false;
        }

        //==================================PushBack Ability Check and Application to Weapon===========================================//
        /*public static bool HasStatusEffect(this Pilot pilot, AbstractActor abstractActor, )
        {
            var logger = Logger.GetLogger("RangedPushBack");
            if (pilot != null)
            {
                logger.LogAtLevel(LogLevel.Debug, "Checking Pilot for abilities that have Active Probe Targeting");
                if (abstractActor.Combat.EffectManager.GetAllEffectsTargeting(pilot).FindAll((Effect x) => x.EffectData.Description.Id.Contains("StatusEffect-Missi") || x.EffectData.Description.Id.Contains("StatusEffect-NARC")).Count > 0)
                {
                    weapons = references.GetItemList<Weapon>(abstractActor, "Weapons");
                    foreach (Weapon weapon in abstractActor.Weapons)
                    {
                        weapon.Hydrate(Ability);
                    }
                }
                
            }
            logger.LogAtLevel(LogLevel.Debug, "Pilot has Active Probe Targeting = False");
            return false;
        }*/

        /*public static bool HasAbilityAndWeaponEffect_Missile(this Pilot pilot, AbstractActor abstractActor, List<string> pilotAbilityDefNames)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            if (pilot != null)
            {
                logger.LogAtLevel(LogLevel.Debug, "Running check on pilotAbilityDefNames");
                foreach (var ability in pilotAbilityDefNames)
                {
                    if (pilot.pilotDef.abilityDefNames.Contains(ability))
                    {
                        logger.LogAtLevel(LogLevel.Debug, "Pilot abilities include items on pilotAbilityDefNames list");
                        List<Weapon> MissileWeapons = new List<Weapon>(abstractActor.Weapons.FindAll((Weapon x) => x.weaponDef.Category == WeaponCategory.Missile));
                        if (abstractActor.Combat.EffectManager.GetAllEffectsTargeting(pilot).FindAll((Effect x) => x.EffectData.Description.Id.Contains("StatusEffect-MISSILEER") || x.EffectData.Description.Id.Contains("StatusEffect-NARC")).Count > 0)
                        {
                            foreach (Weapon weapon in abstractActor.Weapons)
                            {
                                if (MissileWeapons.Contains(weapon))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            logger.LogAtLevel(LogLevel.Debug, "Pilot has Active Probe Targeting = False");
            return false;
        }*/


        //=====================================Active Probe Abilities=======================================//
        public static bool CheckPushBackOneAbilities_Probe(this Pilot pilot, List<string> PushBackOneAbilities_Probe)
        {
            foreach (var ability in PushBackOneAbilities_Probe)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackOneAbilities");
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackOneAbilities list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackOne_Probe(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackOne");
            return CheckPushBackOneAbilities_Probe(pilot, ModInit.Settings.PushBackOneAbilities_Probe);
        }

        public static bool CheckPushBackLastAbilities_Probe(this Pilot pilot, List<string> PushBackLastAbilities_Probe)
        {
            foreach (var ability in PushBackLastAbilities_Probe)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackLastAbilities");

                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackLastAbilities list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackLast_Probe(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackLast");
            return CheckPushBackLastAbilities_Probe(pilot, ModInit.Settings.PushBackLastAbilities_Probe);
        }
        
        //=====================================Attack Abilities=======================================//

        public static bool CheckPushBackOneAbilities(this Pilot pilot, List<string> PushBackOneAbilities)
        {
            foreach (var ability in PushBackOneAbilities)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackOneAbilities");
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackOneAbilities list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackOne(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackOne");
            return CheckPushBackOneAbilities(pilot, ModInit.Settings.PushBackOneAbilities);
        }

        public static bool CheckPushBackLastAbilities(this Pilot pilot, List<string> PushBackLastAbilities)
        {
            foreach (var ability in PushBackLastAbilities)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackLastAbilities");

                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackLastAbilities list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackLast(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackLast");
            return CheckPushBackLastAbilities(pilot, ModInit.Settings.PushBackLastAbilities);
        }
    }
}



