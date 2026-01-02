# Silksong-Rando

A randomiser for Hollow Knight: Silksong. \
This is a very alpha project, do not expect a perfect experience, and many features are lacking.

The current logic should ensure that you can get the Weaver Queen ending.

## How to use
1. Install the mod from either the releases tab or Thunderstore.
2. Launch the game and start a new game select Randomiser from the game mode options.
3. Checks will now be randomised.

## Hotkeys
`F11 + Y` Load every room and search for checks. Found checks will be saved into the save folder at `rando/locations.json` this file follows the same format as `Resources/locations.json`.

`F11 + B` Writes the name and assets within every loaded bundle to the save folder at `rando/bundles.json`.

`F11 + S` Loads every room and writes their sizes to the save folder at `rando/scenes.json`. This is used to add the icons onto the map.

`F11 + R` Re-randomises everything with a new seed, **THIS IS A DEBUG FEATURE INTENDED FOR DEVELOPERS THIS WILL BREAK THINGS**.

`F11 + C` Toggles printing scene debug information in bottom left.

`F11 + P` Toggle printing changes to player data values.

`T` Cycle map mode, see the [map modes](#map-modes) below.

## Map Modes
When in the map screen, press `T` to switch the map mode.
 - **No map**\
    Uses the vanilla map, no new icons.
 - **Checks map**\
    Shows the location and vanilla item for every randomised check.
 - **Logic Map**\
    Shows the vanilla item for all reachable checks with the currently collected items.
 - **Dev map**\
    Mainly useful when developing logic, read `RandoMap.cs` to understand the colors.
 - **Spoiler map**\
    Shows every randomised check and the item they have been replaced with.

## TODO
- [x] Basic logic
- [ ] Add more locations
  - [x] Item pickups
  - [x] Mossberries
  - [x] Pollip hearts
  - [x] Weaver spires
  - [ ] Key items
    - [x] Drifters cloak
    - [x] Faydown cloak
    - [x] Melodies
    - [ ] Silk hearts
    - [ ] Everbloom
  - [ ] Eva upgrades
  - [ ] Crests
  - [ ] Quests
  - [ ] Mask shards
  - [ ] Spool fragment
  - [ ] Fleas
  - [ ] Shops
  - [ ] Bell Stations
  - [ ] Ventrica Stations
  - [x] Bell Shrines
- [ ] Switch to [Randomizer Core](https://github.com/homothetyhk/RandomizerCore) for logic
- [ ] Add ability to toggle location types
- [ ] Menu when creating a save to configure settings
- [ ] Add a menu to replace the current debug hotkeys
- [ ] Make the map show what checks are currently accessible
- [ ] Add a menu to the map so you cant get spoiled by accident
- [ ] Switch away from [SkongGamemodes](https://thunderstore.io/c/hollow-knight-silksong/p/DerVorce/SkongGamemodes/) to a custom solution

## Known Bugs
If you run into any bugs you are welcome to create an issue in the Issues tab explaining the bug.
- [x] ~~If the player has obtained sprint, the original check is marked as already checked~~
- [x] ~~Beating widow without needolin softlocked in memory~~
- [x] ~~Beating widow always gave player needolin~~
- [ ] The game mode selector only appears if steel soul is unlocked
- [ ] Sometimes the map can break softlocking the player in the menu
- [ ] Invalid items named `!!/!!` will appear in the inventory sometimes after loading a save

## Contributing
You are welcome to fork this repo and submit PRs.\
I will try to stay up to date with them as they come in.

In order to run the project, you will need to create `SilksongPath.props` in the project root and replace `...` with the game directory.
```xml
<Project>
  <PropertyGroup>
    <SilksongFolder>...</SilksongFolder>
  </PropertyGroup>
</Project>
```

## License
MIT License © Timothy Marriott  
See `LICENSE.txt` for full license text.
