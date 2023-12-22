using BattleTech;
using HBS.Logging;
using System;
using System.Collections.Generic;

namespace RangedPushBack.Extensions
{
    public static class ComponentExtensions
    {

        //==================================Mech Active Probe Check======================================================
        public static bool CheckActiveProbeComponent(this Mech mech)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running through component abilities - CheckActiveProbeComponent");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on Active Probe Components");
                        if (abilityDef.Targeting == AbilityDef.TargetingType.ActiveProbe)
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities include Active Probe Targeting");
                            return true;
                        }
                    }
                }
            }
            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities DO NOT include Active Probe Targeting");
            return false;
        }

        public static bool HasActiveProbeGear(this Mech mech)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"Running check to see if {mech.MechDef.Name} has ActiveProbe");
            return CheckActiveProbeComponent(mech);
        }



        //====================================Mortar Ability Def Check=============================================
        public static bool CheckPushBackOneComponent(this Mech mech, List<string> PushBackOneAbilities)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running through component abilities - CheckPushBackOneComponent");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on component PushBackOneAbilities");
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
            logger.LogAtLevel(LogLevel.Debug, $"Running check to see if {mech.MechDef.Name} has PushBackOne");
            return CheckPushBackOneComponent(mech, ModInit.Settings.PushBackOneAbilities);
        }

        public static bool CheckPushBackLastComponent(this Mech mech, List<string> PushBackLastAbilities)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running through component abilities - CheckPushBackLastComponent");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on component PushBackLastAbilities");
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
            logger.LogAtLevel(LogLevel.Debug, $"Running check to see if {mech.MechDef.Name} has PushBackLast");
            return CheckPushBackLastComponent(mech, ModInit.Settings.PushBackLastAbilities);
        }

        public static bool CheckPushBackFirstComponent(this Mech mech, List<string> PushBackFirstAbilities)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            for (int i = 0; i < mech.allComponents.Count; i++)
            {
                if (mech.allComponents[i].componentDef.AbilityDefs != null)
                {
                    logger.LogAtLevel(LogLevel.Debug, "Running through component abilities - CheckPushBackFirstComponent");
                    for (int j = 0; j < mech.allComponents[i].componentDef.AbilityDefs.Count; j++)
                    {
                        AbilityDef abilityDef = mech.allComponents[i].componentDef.AbilityDefs[j];
                        logger.LogAtLevel(LogLevel.Debug, "Running check on component PushBackFirstAbilities");
                        if (PushBackFirstAbilities.Contains(abilityDef.Id))
                        {
                            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities include items on PushBackFirstAbilities list");
                            return true;
                        }
                    }
                }
            }
            logger.LogAtLevel(LogLevel.Debug, "Mech component abilities DO NOT include items on PushBackFirstAbilities list");
            return false;
        }

        public static bool HasPushBackFirst(this Mech mech)
        {
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"Running check to see if {mech.MechDef.Name} has PushBackFirst");
            return CheckPushBackLastComponent(mech, ModInit.Settings.PushBackFirstAbilities);
        }

        //end of code
    }
}
