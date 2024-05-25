using BattleTech;
using BattleTech.StringInterpolation;
using HBS.Logging;
using RangedPushBack.Patches;
using System.Collections.Generic;
using Logger = HBS.Logging.Logger;

namespace RangedPushBack.Extensions
{
    public static class PilotExtensions
    {
        //=====================================Active Probe Targeting Check===========================================//
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

        //=====================================Active Probe Abilities=======================================//
        public static bool CheckPushBackOneAbilities_Probe(this Pilot pilot, List<string> PushBackOneAbilities_Probe)
        {
            foreach (var ability in PushBackOneAbilities_Probe)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackOneAbilities_Probe");
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackOneAbilities_Probe list: {ability}");
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
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackOne_Probe");
            return CheckPushBackOneAbilities_Probe(pilot, ModInit.Settings.PushBackOneAbilities_Probe);
        }

        public static bool CheckPushBackLastAbilities_Probe(this Pilot pilot, List<string> PushBackLastAbilities_Probe)
        {
            foreach (var ability in PushBackLastAbilities_Probe)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackLastAbilities_Probe");

                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackLastAbilities_Probe list: {ability}");
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
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackLast_Probe");
            return CheckPushBackLastAbilities_Probe(pilot, ModInit.Settings.PushBackLastAbilities_Probe);
        }

        public static bool CheckPushBackFirstAbilities_Probe(this Pilot pilot, List<string> PushBackFirstAbilities_Probe)
        {
            foreach (var ability in PushBackFirstAbilities_Probe)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackFirstAbilities_Probe");

                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackFirstAbilities_Probe list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackFirst_Probe(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackFirst");
            return CheckPushBackLastAbilities_Probe(pilot, ModInit.Settings.PushBackFirstAbilities_Probe);
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

        public static bool CheckPushBackFirstAbilities(this Pilot pilot, List<string> PushBackFirstAbilities)
        {
            foreach (var ability in PushBackFirstAbilities)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackFirstAbilities");

                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, $"Pilot abilities include items on PushBackFirstAbilities list: {ability}");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackFirst(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"{pilot.pilotDef.Description.Id} = {pilot.pilotDef.Description.DisplayName}");
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushFirstLast");
            return CheckPushBackLastAbilities(pilot, ModInit.Settings.PushBackFirstAbilities);
        }

        //end of code
    }
}



