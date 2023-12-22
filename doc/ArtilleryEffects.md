# Artillery Status Effects

## What it does:
The base game has no ability to apply `EffectData` included in any `AbilityDef_Mortar_[Name]` file to mortar/Thumper attacks. Through Postfix Harmony Patching, any status effect in the `EffectData` array will be applied to the targets.

## How it works:
Add `EffectData` code to the `AbilityDef` file like so:

```
"EffectData" :
	[
		{
            "Description" : {
                "Id" : "StatusEffect-Artillery-GimpWalkSpeed",
                "Name" : "ACTUATOR WRENCHED",
                "Details" : "Thumper blasts damage opponent's Actuators, slowing their movement speed.",
                "Icon" : "uixSvgIcon_ability_gimpthem"
            },
            "effectType" : "StatisticEffect",
            "nature" : "Debuff",
            "durationData" : {
                "duration" : 2,
                "ticksOnActivations" : true,
                "useActivationsOfTarget" : true,
                "ticksOnEndOfRound" : false,
                "ticksOnMovements" : false,
                "stackLimit" : 1,
                "clearedWhenAttacked" : false
            },
            "targetingData" : {
                "effectTriggerType" : "OnHit",
                "effectTargetType" : "SingleTarget",
                "showInTargetPreview" : true,
                "showInStatusPanel" : true,
                "hideApplicationFloatie" : false
            },
            "statisticData" : {
                "statName" : "WalkSpeed",
                "operation" : "Float_Multiply",
                "modValue" : "0.5",
                "modType" : "System.Single",
                "additionalRules" : "NotSet",
                "targetCollection" : "NotSet",
                "targetWeaponCategory" : "NotSet",
                "targetWeaponType" : "NotSet",
                "targetAmmoCategory" : "NotSet",
                "targetWeaponSubType" : "NotSet"
            }
        },
        {
            "Description" : {
                "Id" : "StatusEffect-Artillery-GimpRunSpeed",
                "Name" : "MOVEMENT SLOWED",
                "Details" : "Thumper blasts damage opponent's Actuators, slowing their movement speed.",
                "Icon" : "uixSvgIcon_ability_gimpthem"
            },
            "effectType" : "StatisticEffect",
            "nature" : "Debuff",
            "durationData" : {
                "duration" : 2,
                "ticksOnActivations" : true,
                "useActivationsOfTarget" : true,
                "ticksOnEndOfRound" : false,
                "ticksOnMovements" : false,
                "stackLimit" : 1,
                "clearedWhenAttacked" : false
            },
            "targetingData" : {
                "effectTriggerType" : "OnHit",
                "effectTargetType" : "SingleTarget",
                "showInTargetPreview" : false,
                "showInStatusPanel" : false,
                "hideApplicationFloatie" : false
            },
            "statisticData" : {
                "statName" : "RunSpeed",
                "operation" : "Float_Multiply",
                "modValue" : "0.5",
                "modType" : "System.Single",
                "additionalRules" : "NotSet",
                "targetCollection" : "NotSet",
                "targetWeaponCategory" : "NotSet",
                "targetWeaponType" : "NotSet",
                "targetAmmoCategory" : "NotSet",
                "targetWeaponSubType" : "NotSet"
            }
        },
        {
            "Description" : {
                "Id" : "StatusEffect-Artillery-GimpGuns",
                "Name" : "WEAPONS DISABLED",
                "Details" : "Thumper blasts damage opponent's weapons for 2 turns.",
                "Icon" : "UixSvgIcon_specialAbility_BWCL"
            },
            "effectType" : "StatisticEffect",
            "nature" : "Debuff",
            "durationData" : {
                "duration" : 2,
                "ticksOnActivations" : true,
                "useActivationsOfTarget" : true,
                "ticksOnEndOfRound" : false,
                "ticksOnMovements" : false,
                "stackLimit" : 1,
                "clearedWhenAttacked" : false
            },
            "targetingData" : {
                "effectTriggerType" : "OnHit",
                "effectTargetType" : "SingleTarget",
                "specialRules" : "HalfArmorOrLess",
                "showInTargetPreview" : false,
                "showInStatusPanel" : false,
                "hideApplicationFloatie" : false
            },
            "statisticData" : {
                "statName" : "TemporarilyDisabled",
                "operation" : "Set",
                "modValue" : true,
                "modType" : "System.Boolean",
                "additionalRules" : "NotSet",
                "targetCollection" : "Weapon",
                "targetWeaponCategory" : "NotSet",
                "targetWeaponType" : "NotSet",
                "targetAmmoCategory" : "NotSet",
                "targetWeaponSubType" : "NotSet"
            }
        }
	]
```

## Pre-existing Artillery Abilities

Artillery AbilityDef files from Heavy Metal DLC and other mods **do not** have `EffectData` arrays by default. To avoid issues with JSON Merging, Skill Tree Rebuild incorporates replacement JSONs with balance changes from [BetterMortars](https://www.nexusmods.com/battletech/mods/540) by Mechfanatic.

**Mortar**

- +20% radius effect

- +1 ammo (with 1 turn cooldown for reload)

**Thumper**

- +50% radius effect

<<<<<<< HEAD
- +1 ammo (with 1 turn cooldown for reload)
=======
- +1 ammo (with 1 turn cooldown for reload)

## Pre-existing Artillery Abilities

Artillery AbilityDef files from Heavy Metal DLC and other mods **do not** have `EffectData` arrays by default. To avoid issues with JSON Merging, Skill Tree Rebuild incorporates replacement JSONs with balance changes from [BetterMortars](https://www.nexusmods.com/battletech/mods/540) by Mechfanatic.

**Mortar**

- +20% radius effect

- +1 ammo (with 1 turn cooldown for reload)

**Thumper**

- +50% radius effect

- +1 ammo (with 1 turn cooldown for reload)

## Developing New Artillery

Creating new artillery is a multi-step process involving the creation of up to three files:

- `AbilityDef_Mortar_[Name].json`

- `Gear_Mortar_[Name].json`

- `Weapon_Mortar_[Name].json`

The relationship is as follows:

- `Gear_Mortar_Name.json` is the part that shows up in the MechBay and controls tonnage/slots. This file includes a link to `AbilityDef_Mortar_[Name].json`, giving your mech the ability to use artillery in combat.

- `AbilityDef_Mortar_[Name].json` is the file that controls range, artillery reticle size, cooldown length, the pop up description, and all status effects. This file includes a link to `Weapon_Mortar_[Name].json`, which handles everything else.

- `Weapon_Mortar_[Name].json` is the file that controls the damage per shot, heat damage, stability damage, recoil, and heat generated by the artillery attack. Damage is controlled by a combining the following settings:

  - Damage per shot: the midpoint value of the damage calculation

  - Damage variance: a +/- modifier applied to damage per shot

### Damage Calculations

For example, these are the damage per shot and damage variance values for the stock Thumper cannon:

```
"Damage" : 30,
...
"DamageVariance" : 20,
```

What this results in is a a total damage range of 10-50: `30-20 = 10, 30 + 20 = 50`.

Based on the original code, **only** calculated damage value will be applied to individual sections of the target mechs. Heat and instability damage are applied **once** to the target as a **whole**.

```
if (this.Targets.Count > 0)
				{
					ICombatant combatant = this.Targets[0];
					this.Targets.Remove(combatant);
					AbstractActor abstractActor = combatant as AbstractActor;
					if (abstractActor != null && abstractActor.BehaviorTree != null && !abstractActor.BehaviorTree.IsTargetIgnored(this.owningActor))
					{
						combatant.LastTargetedPhaseNumber = base.Combat.TurnDirector.TotalElapsedPhases;
					}
					if (this.referenceWeapon.DamagePerShot > 0f)
					{
						Vector2 vector = this.referenceWeapon.DamagePerShotRange();
						DamageOrderUtility.ApplyDamageToAllLocations(this.owningActor.GUID, base.SequenceGUID, base.RootSequenceGUID, combatant, (int)vector.x, (int)vector.y, AttackDirection.FromArtillery, DamageType.Artillery);
					}
					if (this.referenceWeapon.HeatDamagePerShot > 0f)
					{
						DamageOrderUtility.ApplyHeatDamage(base.SequenceGUID, combatant, (int)this.referenceWeapon.HeatDamagePerShot);
					}
					if (this.referenceWeapon.Instability() > 0f)
					{
						DamageOrderUtility.ApplyStabilityDamage(base.SequenceGUID, combatant, this.referenceWeapon.StructureDamagePerShot);
					}
					ActorAttackedMessage actorAttackedMessage = new ActorAttackedMessage(this.OwningMech.GUID, combatant.GUID);
					base.Combat.MessageCenter.PublishMessage(actorAttackedMessage);
				}
```

### Damage Via Status Effects

Damage can be applied to targets through the use of status effects without directly boosting the damage values of an attack. This requires knowledge of the statistics controlling the armor and structure values for each mech section:

```
in program => in json
int => System.Int32
float => System.Single
bool => System.Boolean
double => System.Double
string => System.String

Head.Armor => System.Single
Head.Structure => System.Single
CenterTorso.Armor => System.Single
CenterTorso.RearArmor => System.Single
CenterTorso.Structure => System.Single
LeftTorso.Armor => System.Single
LeftTorso.RearArmor => System.Single
LeftTorso.Structure => System.Single
RightTorso.Armor => System.Single
RightTorso.RearArmor => System.Single
RightTorso.Structure => System.Single
LeftArm.Armor => System.Single
LeftArm.Structure => System.Single
RightArm.Armor => System.Single
RightArm.Structure => System.Single
LeftLeg.Armor => System.Single
LeftLeg.Structure => System.Single
RightLeg.Armor => System.Single
RightLeg.Structure => System.Single
```

A real life example would something like this:

```
{
            "durationData" : {
                "duration" : -1,
                "ticksOnActivations" : false,
                "useActivationsOfTarget" : false,
                "ticksOnEndOfRound" : true,
                "ticksOnMovements" : false,
                "stackLimit" : -1,
                "clearedWhenAttacked" : false
            },
            "targetingData" : {
                "effectTriggerType" : "OnHit",
                "triggerLimit" : 0,
                "extendDurationOnTrigger" : 0,
                "specialRules" : "NotSet",
                "effectTargetType" : "NotSet",
                "range" : 0,
                "forcePathRebuild" : false,
                "forceVisRebuild" : false,
                "showInTargetPreview" : true,
                "showInStatusPanel" : true
            },
            "effectType" : "StatisticEffect",
            "Description" : {
                "Id" : "StatusEffect-Acid-Burn1",
                "Name" : "ACID COATING - HEAD",
                "Details" : "This unit gains [AMT] armor damage on its next activation (this effect stacks).",
                "Icon" : "uixSvgIcon_ability_acid"
            },
            "nature" : "Debuff",
            "statisticData" : {
                "appliesEachTick" : false,
                "statName": "Head.Armor",
                "operation": "Float_Add",
                "modValue": "-10",
                "modType": "System.Single"
            },
            "tagData" : null,
            "floatieData" : null,
            "actorBurningData" : null,
            "vfxData" : null,
            "instantModData" : null,
            "poorlyMaintainedEffectData" : null
        },
```

**Note:** `"duration" : -1,` is necessary for damage to be permanent. Any value besides 0 (which disables the effect) or -1 (which applies permanently until the end of combat) will be the number of turns before the effect expires.

Likewise, `"stackLimit" : -1,` allows for unlimited effect stacking. Any value besides 0 (which disables the effect) or -1 (which applies permanently until the end of combat) will be the number of times the target can receive the status effect.
>>>>>>> test
