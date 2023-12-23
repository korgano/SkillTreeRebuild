# New Feature: Ranged Initiative Manipulation

## What it does:
Adds +1 initiative to targets (4 => 3) or pushes enemies from the current phase to the first phase (5 or 10, depending on if you have certain mods installed) or final phase (Phase 1 or phase used for Assault Mechs).

## How it works:
`"PushBackOneAbilities": [],` : Defines which attacks (standard and mortar) push enemies back one phase.

`"PushBackOneAbilities_Probe": ["AbilityDef_ActiveProbe_Ping"],` : Defines which abilities using active probe targeting push enemies back one phase. Default active probe ability is `AbilityDef_ActiveProbe_Ping`.

`"PushBackFirstAbilities": [],` : Defines which attacks (standard and mortar) push enemies back to first phase. **NOTE:** In game code, Phase 1 is known as PhaseSpecial. If mods modify this value, this may no longer function as intended.

`"PushBackFirstAbilities_Probe": [],` : Defines which abilities using active probe targeting push enemies back to first phase. **NOTE:** In game code, Phase 1 is known as PhaseSpecial. If mods modify this value, this may no longer function as intended.

`"PushBackLastAbilities": [],` : Defines which attacks (standard and mortar) push enemies back to final phase.

`"PushBackLastAbilities_Probe": ["AbilityDef_ScoutStomp"],` : Defines which abilities using active probe targeting push enemies back to final phase. Default ability is `AbilityDef_ScoutStomp`.

`"ThumperIDs": ["Weapon_Mortar_Thumper"]` : Controls whether a mortar weapon receives Thumper cannon animations/processing. Default Thumper is `Weapon_Mortar_Thumper`.

## Known Issues
~~- Multi-Targeting attacks can cause multiple applications of pushback.~~

- Multi-Targeting attacks no longer cause multiple pushback applications, but only one attack can apply pushback to a target per initiative phase. Once a phase ends, another attack can apply pushback to the same target.

- Has not been tested with pilots with multiple pushback skills.