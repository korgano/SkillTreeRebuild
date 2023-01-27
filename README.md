SkillTreeRebuild
======
A revamped skill tree for HBS BattleTech.

Based on Abifilier by gnivler & ajkroeg/tbone, abilities inspired by bloodydoves' BTA3062, and with special thanks to yimjeric (Multi-Target on all Mechs) for demonstrating a better way to do skill tree changes.

Does **NOT** include any Resolverator code. Uses only Abilifier (NO CAE), which currently lacks that feature.

How to Replace the Existing Skill Tree
======

In your mod.json file, add this to your Manifest:
  { "Type": "SimGameConstants", "Path": "simGameConstants", "ShouldMergeJSON": true },

Inside the folder, make a SimGameConstants.json file with the Progression block within {}. 

Issues to Keep in Mind
======

-Sensor Lock will **NOT** work unless the ability is named AbilityDefT5A. You must adjust the skill requirement for the ability in its JSON file before moving it to another location in the skill tree.

-Do **NOT** include any FloatieEffects with the value "null". This will cause the game to soft crash while trying to load a mission.

Skill Tree (v0.3.0)
======
## Gunnery Skills
### Level 2:
Multi-Target

ACTION: Fire weapons at up to three separate targets within this 'Mech's current firing arc.

### Level 4:
Close in Fire Support

PASSIVE: Gain a +50% boost to all support weapon range brackets, as well as -20% heat from support weapons.


Missileer

PASSIVE: Missiles gain +1 accuracy and ignore 2 evasion.


Suppression

PASSIVE: Direct Fire attacks inflict a -1 accuracy penalty on enemy units for 2 turns.

### Level 6:
Close and Personal

PASSIVE: +25% Damage and 10% Crit to all Support weapons.


Jack of All Trades

PASSIVE: +25% Damage and 10% Crit to all standard range weapons.


Longshot

PASSIVE: +25% Damage and 10% Crit to all long range weapons.

### Level 8:
Overclock

ACTION: Supercharge your mech for a turn, dealing 25% greater damage, 10% greater crit chance, and hitting with +2 accuracy for the turn. 
Generates an extra 40 heat this turn. 3 turn cooldown.


Targeted and Firing

PASSIVE: Very long and extreme range weapons bypass armor and deal structure damage to the target.

## Piloting Skills
### Level 4
Sure Footing

PASSIVE: 'Mechs piloted by this MechWarrior gain one bonus Evasion charge after moving (can exceed the unit's maximum). If the move is not a sprint, jump, or charge to melee, the 'Mech also gains ENTRENCHED (50% stability damage reduction).


Gun and Run

PASSIVE: A 'Mech piloted by this MechWarrior can move after shooting if it has not moved yet. Chance of receiving a Critical Hit is reduced by 50%.

### Level 6
Dodge Master

PASSIVE: Veteran MechWarriors receive a +10 defense bonus against melee attacks.


Jump Maven

PASSIVE: Veteran MechWarriors receive a 20% boost to jump distance.

### Level 8
Mech Meister

PASSIVE: Experienced MechWarriors recieve bonus movement speed and 25% damage reduction.


Boxer

ACTION: Use superior piloting skills to deal 50% more stability damage with melee, while taking 25% less damage this turn. 3 turn cooldown.

## Guts Skills
### Level 4
Cold Blooded

PASSIVE: 'Harden your MechWarrior's mental fortitude to earn more Resolve per action.


Hunker Down

ACTION: Activate in order to gain a flat 25% damage reduction regardless of cover or positioning for all Lance units. The DR lasts for 2 turns. 4 turn cooldown.

### Level 6
Maximum Armor

ACTION: Sacrifice 50% speed to gain 75% damage reduction from all sources.


Maximum Strength

ACTION: Increase speed by 50% and melee damage by 100 for 2 turns. +40 heat for 1 turn. 4 turn cooldown.

### Level 8
Coolant Vent

ACTION: This unit will remove 50 extra heat this round. For the next three rounds, this unit will gain an extra 8 heat. There is a 4 round cooldown.


*Placeholder space for mods that replace Coolant Vent with Juggernaut.*

## Tactics Skills
### Level 2
Sensor Lock

ACTION: Select a target within sensor range to reveal it until the end of the current round and remove two of its EVASIVE charges. The target also gains +2 SENSORS IMPAIRED effect.

### Level 4
Blindshot

PASSIVE: Support weapons receive +1 aim and inflict Sensor Impaired status on enemies.


Break Lock

ACTION: Select an allied unit within sensor range and give it +3 Hit Defense and Critical Hit immunity for 2 turns.


Anti-Missile Countermeasures

PASSIVE: All units in this MechWarrior's lance take 50% less damage from missiles.

### Level 6
One Ping Only

ACTION: Locate all enemies within your detection radius. Generates 20 heat, 4 turn cooldown.


Gimp Them

PASSIVE: Attacks target and wrench opponent's Actuators, slowing their movement speed.

### Level 8
Master Tactician

PASSIVE: 'Mechs piloted by this MechWarrior gain +1 Initiative, and remove one bar of stability damage when Reserving.


Networked Attack

ACTION: Advanced heuristics provide your lancemates with +3 accuracy, 30% increase to long & max range brackets, and 10% Called Shot bonus for the remainder of this turn. Does not affect this unit. +30 heat to this unit, 5 turn cooldown.

## Gunnery Traits

### Level 5

Breaching Shot: Attacking with a single weapon ignores COVER and GUARDED on the target.

### Level 10

Sprint + Shoot: Elite MechWarriors can fire their weapons after sprinting.

## Piloting Traits

### Level 5

Evasion Boost: +2 Hit Defense, +2 Evasion

### Level 10

Evasion Immunity: Sensor Lock No Longer Strips Evasion 


Safer DFA: When performing a 'Death from Above,' this unit takes 25% less damage to its legs.

## Guts Traits

### Level 4

Berserk: Gain +6 Hit Defense, as well as +60 Melee damage at 50% or less armor. 

### Level 6

Bulwark: COVER and GUARDED states both provide 40% damage reduction rather than 20% damage reduction. COVER and GUARDED together provide 60% damage reduction.

### Level 10

Head Shot Immunity: Pilots cannot receive Head Shots. 


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
