using BattleTech;
using HBS.Logging;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangedPushBack.Extensions
{
    public static class MechExtensions
    {
        public static List<EffectData> GetAbilityStatusEffectsForTriggerType(this Mech mech, EffectTriggerType triggerType)
        {
            var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, $"Executing GetAbilityStatusEffectsForTriggerType for mech: {mech.DisplayName}");

            List<EffectData> list = new List<EffectData>();
            //for (int i = 0; i < mech.Abilities.Count; i++)
            for (int i = 0; i < mech.ComponentAbilities.Count; i++)
            {
                Ability ability = mech.ComponentAbilities[i];
                logger.LogAtLevel(LogLevel.Debug, $"Checking ability: {ability.Def.Description.Id}");

                for (int j = 0; j < ability.Def.EffectData.Count; j++)
                {
                    EffectData effectData = ability.Def.EffectData[j];
                    logger.LogAtLevel(LogLevel.Debug, $"Checking effect data: {effectData.Description.Id}");

                    if (effectData.targetingData.effectTriggerType == triggerType)
                    {
                        logger.LogAtLevel(LogLevel.Debug, $"Adding effect data to list: {effectData.Description.Id}");
                        list.Add(effectData);
                    }
                }
            }
            logger.LogAtLevel(LogLevel.Debug, $"Finished GetAbilityStatusEffectsForTriggerType for mech: {mech.DisplayName}");
            return list;
        }
    }
//==============================end of code
}
