using Harmony;
using HBS.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RangedPushBack
{
    public class ModInit
    {
        public static MCBLSettings Settings = new MCBLSettings();

        public const string HarmonyPackage = "us.kregano.RangedPushBack";

        public static void Init(string directory, string settingsJSON)
        {
            try
            {
                ModInit.Settings = JsonConvert.DeserializeObject<MCBLSettings>(settingsJSON);
            }
            catch (Exception)
            {
                ModInit.Settings = new MCBLSettings();
            }
            var harmony = HarmonyInstance.Create(HarmonyPackage);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            var logger = Logger.GetLogger("RangedPushBack");
            logger.LogAtLevel(LogLevel.Debug, "Ranged Initiative Debuff DLL Initialized");
        }
    }

    public class MCBLSettings
    {
        //These settings need to be in mod.json
        public List<string> PushBackOneAbilities = new List<string>();
        public List<string> PushBackLastAbilities = new List<string>();
        public List<string> ThumperIDs = new List<string>();
    }
}
