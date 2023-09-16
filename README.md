SkillTreeRebuild
======
A revamped skill tree for HBS BattleTech.

Based on Abifilier by gnivler & ajkroeg/tbone, abilities inspired by bloodydoves' BTA3062, and with special thanks to yimjeric (Multi-Target on all Mechs) for demonstrating a better way to do skill tree changes.

Features Mortar/Thumper AbilityDef tweaks from Mechfanatic.

Does **NOT** include any Resolverator code. Uses only Abilifier (NO CAE), which currently lacks that feature.

Now dependent on [IRModUtils](https://github.com/BattletechModders/IRBTModUtils) due to Abilifier updates.

[New Skill Tree](SkillTree_revamp.md)

[Ranged Pushback Functionality](RangedPushBack.md)

[Artillery Status Effects](ArtilleryEffects.md)

# How to Replace the Existing Skill Tree
=======
In your mod.json file, add this to your Manifest:
  { "Type": "SimGameConstants", "Path": "simGameConstants", "ShouldMergeJSON": true },

Inside the folder, make a SimGameConstants.json file with the Progression block within {}. 

Issues to Keep in Mind
======

-Sensor Lock will **NOT** work unless the ability is named AbilityDefT5A. You must adjust the skill requirement for the ability in its JSON file before moving it to another location in the skill tree.

-Do **NOT** include any FloatieEffects with the value "null". This will cause the game to soft crash while trying to load a mission.

FAQ
======

-Can I use your code for my own mods?

Sure, just give credit to all involved.


-Why did you rename the AbilityDefs from the Abilifier team?

To make it easier for me to figure out what was where in the skill tree, plus with abilities earned every 2 levels, including the skill level in the name wasn't accurate anymore.


-How come there's two Coolant Vent entries?

I kept the stock Coolant Vent entry so that any mod that replaces it with Juggernaut won't break, then added a new one so you'd have to choose between them.


-Can I submit a Pull Request to get abilities added to this mod?

Sure, just make sure you give a brief description of what the ability does and what name you want to be credited under in the Pull Request.


-Why do some icons/parts of icons show up as black?

Not sure, this seems to be some sort of SVG error or problem ModTek has with Inkscape SVGs.
