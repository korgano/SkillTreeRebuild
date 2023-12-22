using BattleTech;
using HBS.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangedPushBack.Extensions
{
    public static class AbstractActor_ext
    {
        public static void ForceUnitToFirstPhase(this AbstractActor Target)
        {
            if (Target.Combat.TurnDirector.IsInterleaved && Target.Initiative != Target.Combat.Constants.Phase.PhaseSpecial)
            {
                var logger = HBS.Logging.Logger.GetLogger("RangedPushBack");
                Target.Initiative = Target.Combat.Constants.Phase.PhaseSpecial;
                Target.Combat.MessageCenter.PublishMessage(new ActorPhaseInfoChanged(Target.GUID));
                logger.LogAtLevel(LogLevel.Debug, "Executed ForceUnitToFirstPhase");
            }
        }
    }
}
