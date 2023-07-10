using BattleTech;
using HBS.Logging;
using System.Collections.Generic;

namespace RangedPushBack.Extensions
{
    public static class PilotExtensions
    {
        public static bool CheckPushBackOneAbilities(this Pilot pilot, List<string> PushBackOneAbilities)
        {
            foreach (var ability in PushBackOneAbilities)
            {
                var logger = Logger.GetLogger("RangedPushBack");
                List<string> pilotAbilityDefNames = pilot.pilotDef.abilityDefNames;
                logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackOneAbilities");
                if (pilotAbilityDefNames.Contains(ability))
                {
                    logger.LogAtLevel(LogLevel.Debug, "Pilot abilities include items on PushBackOneAbilities list");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackOne(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, pilot.pilotDef.Description.Id);
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
                    logger.LogAtLevel(LogLevel.Debug, "Pilot abilities include items on PushBackLastAbilities list");
                    return true;
                }
                continue;
            }

            return false;
        }

        public static bool HasPushBackLast(this Pilot pilot)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, pilot.pilotDef.Description.Id);
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if pilot has PushBackLast");
            return CheckPushBackLastAbilities(pilot, ModInit.Settings.PushBackLastAbilities);
        }
    }
}



