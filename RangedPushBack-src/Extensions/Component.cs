using BattleTech;
using HBS.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangedPushBack.Extensions
{
    public static class ComponentExtensions
    {
        public static bool CheckPushBackOneComponent(this Mech mech, List<string> PushBackOneAbilities)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running throught component abilities");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackOneAbilities");
                        if (PushBackOneAbilities.Contains(abilityDef.Id))
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities include items on PushBackOneAbilities list");
                            return true;
                        }
                    }
                }
            }
            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities DO NOT include items on PushBackOneAbilities list");
            return false;
        }

        public static bool HasPushBackOne(this Mech mech)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, mech.MechDef.Name);
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if MECH has PushBackOne");
            return CheckPushBackOneComponent(mech, ModInit.Settings.PushBackOneAbilities);
        }

        public static bool CheckPushBackLastComponent(this Mech mech, List<string> PushBackLastAbilities)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running throught component abilities");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on PushBackLastAbilities");
                        if (PushBackLastAbilities.Contains(abilityDef.Id))
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities include items on PushBackLastAbilities list");
                            return true;
                        }
                    }
                }
            }
            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities DO NOT include items on PushBackLastAbilities list");
            return false;
        }

        public static bool HasPushBackLast(this Mech mech)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, mech.MechDef.Name);
            logger.LogAtLevel(LogLevel.Debug, "Running check to see if MECH has PushBackLast");
            return CheckPushBackLastComponent(mech, ModInit.Settings.PushBackLastAbilities);
        }
    }
}
