using System.Collections.Generic;

public static class GameScenes
{
    
    public static List<string> Scenes = new List<string>
    {
      "Tut_01",
      "Tut_01b",
      "Tut_02",
      "Tut_03",
      "Tut_04",
      "Tut_05",
      "Mosstown_01",
      "Mosstown_02",
      "Mosstown_02c",
      "Mosstown_03",
      "Aspid_01",
      "Crawl_01",
      "Crawl_02",
      "Crawl_03",
      "Crawl_03b",
      "Crawl_04",
      "Crawl_05",
      "Crawl_06",
      "Crawl_07",
      "Crawl_08",
      "Crawl_09",
      "Crawl_10",
      "Belltown",
      "Belltown_04",
      "Belltown_06",
      "Belltown_07",
      "Belltown_08",
      "Belltown_Shrine",
      "Belltown_Room_pinsmith",
      "Belltown_Room_shellwood",
      "Belltown_Room_doctor",
      "Belltown_Room_Relic",
      "Belltown_basement",
      "Belltown_basement_03",
      "Bellway_01",
      "Bellway_01_boss",
      "Bellway_02",
      "Bellway_02_boss",
      "Bellway_03",
      "Bellway_03_boss",
      "Bellway_04",
      "Bellway_04_boss",
      "Bellway_08",
      "Bellway_City",
      "Bellway_Peak",
      "Bellway_Peak_02",
      "Bellway_Shadow",
      "Bellway_Aqueduct",
      "Bellway_Centipede_Arena",
      "Bellway_Centipede_additive",
      "Bellshrine",
      "Bellshrine_02",
      "Bellshrine_03",
      "Bellshrine_05",
      "Bellshrine_Enclave",
      "Bellshrine_Coral",
      "Bellshrine_Lore_Additive",
      "Bonetown",
      "Bonegrave",
      "Bone_01",
      "Bone_01b",
      "Bone_01c",
      "Bone_02",
      "Bone_03",
      "Bone_04",
      "Bone_05",
      "Bone_05_boss",
      "Bone_05_bellway",
      "Bone_05b",
      "Bone_06",
      "Bone_07",
      "Bone_08",
      "Bone_09",
      "Bone_10",
      "Bone_11",
      "Bone_11b",
      "Bone_12",
      "Bone_14",
      "Bone_15",
      "Bone_16",
      "Bone_17",
      "Bone_18",
      "Bone_19",
      "Ant_02",
      "Ant_03",
      "Ant_04",
      "Ant_04_mid",
      "Ant_04_left",
      "Ant_05b",
      "Ant_05c",
      "Ant_08",
      "Ant_09",
      "Ant_14",
      "Ant_17",
      "Ant_19",
      "Ant_20",
      "Ant_21",
      "Ant_Merchant",
      "Ant_Queen",
      "Dock_01",
      "Dock_02",
      "Dock_02b",
      "Dock_03",
      "Dock_03b",
      "Dock_03c",
      "Dock_03d",
      "Dock_04",
      "Dock_05",
      "Dock_06_Church",
      "Dock_08",
      "Dock_09",
      "Dock_10",
      "Dock_11",
      "Dock_12",
      "Dock_13",
      "Dock_14",
      "Dock_15",
      "Dock_16",
      "Room_Forge",
      "Bone_East_01",
      "Bone_East_02",
      "Bone_East_02b",
      "Bone_East_03",
      "Bone_East_04",
      "Bone_East_04c",
      "Bone_East_04b",
      "Bone_East_05",
      "Bone_East_07",
      "Bone_East_08",
      "Bone_East_09",
      "Bone_East_09b",
      "Bone_East_10",
      "Bone_East_10_Church",
      "Bone_East_10_Room",
      "Bone_East_11",
      "Bone_East_12",
      "Bone_East_13",
      "Bone_East_14",
      "Bone_East_14b",
      "Bone_East_15",
      "Bone_East_16",
      "Bone_East_17",
      "Bone_East_17b",
      "Bone_East_18",
      "Bone_East_18b",
      "Bone_East_18c",
      "Bone_East_20",
      "Bone_East_21",
      "Bone_East_22",
      "Bone_East_24",
      "Bone_East_25",
      "Bone_East_Weavehome",
      "Bone_East_Umbrella",
      "Bone_East_LavaChallenge",
      "Halfway_01",
      "Greymoor_01",
      "Greymoor_02",
      "Greymoor_03",
      "Greymoor_04",
      "Greymoor_05",
      "Greymoor_05_boss",
      "Greymoor_06",
      "Greymoor_07",
      "Greymoor_08",
      "Greymoor_08_boss",
      "Greymoor_08_caravan",
      "Greymoor_08_mapper",
      "Greymoor_10",
      "Greymoor_11",
      "Greymoor_12",
      "Greymoor_13",
      "Greymoor_15",
      "Greymoor_15b",
      "Greymoor_16",
      "Greymoor_17",
      "Greymoor_20b",
      "Greymoor_20c",
      "Greymoor_21",
      "Greymoor_22",
      "Greymoor_24",
      "Dust_01",
      "Dust_02",
      "Dust_03",
      "Dust_04",
      "Dust_05",
      "Dust_06",
      "Dust_09",
      "Dust_10",
      "Dust_11",
      "Dust_12",
      "Dust_Barb",
      "Dust_Shack",
      "Dust_Chef",
      "Dust_Maze_01",
      "Dust_Maze_02",
      "Dust_Maze_03",
      "Dust_Maze_04",
      "Dust_Maze_05",
      "Dust_Maze_06",
      "Dust_Maze_07",
      "Dust_Maze_08",
      "Dust_Maze_crossing",
      "Dust_Maze_Last_Hall",
      "Dust_Maze_08_completed",
      "Dust_Maze_09_entrance",
      "Organ_01",
      "Shadow_01",
      "Shadow_02",
      "Shadow_03",
      "Shadow_04",
      "Shadow_04b",
      "Shadow_05",
      "Shadow_09",
      "Shadow_10",
      "Shadow_11",
      "Shadow_12",
      "Shadow_13",
      "Shadow_14",
      "Shadow_15",
      "Shadow_16",
      "Shadow_18",
      "Shadow_19",
      "Shadow_20",
      "Shadow_21",
      "Shadow_22",
      "Shadow_23",
      "Shadow_24",
      "Shadow_25",
      "Shadow_26",
      "Shadow_27",
      "Shadow_28",
      "Shadow_Weavehome",
      "Aqueduct_01",
      "Aqueduct_02",
      "Aqueduct_03",
      "Aqueduct_04",
      "Aqueduct_05",
      "Aqueduct_06",
      "Aqueduct_07",
      "Wisp_02",
      "Wisp_03",
      "Wisp_04",
      "Wisp_05",
      "Wisp_06",
      "Wisp_07",
      "Wisp_08",
      "Wisp_09",
      "Shellwood_01",
      "Shellwood_01b",
      "Shellwood_02",
      "Shellwood_03",
      "Shellwood_04b",
      "Shellwood_04c",
      "Shellwood_08",
      "Shellwood_08c",
      "Shellwood_10",
      "Shellwood_11",
      "Shellwood_11b",
      "Shellwood_13",
      "Shellwood_14",
      "Shellwood_15",
      "Shellwood_16",
      "Shellwood_18",
      "Shellwood_19",
      "Shellwood_20",
      "Shellwood_22",
      "Shellwood_25",
      "Shellwood_25b",
      "Shellwood_26",
      "Shellwood_Witch",
      "Shellwood_11b_Memory",
      "Shellgrave",
      "Coral_02",
      "Coral_03",
      "Coral_10",
      "Coral_11",
      "Coral_11b",
      "Coral_12",
      "Coral_19",
      "Coral_19b",
      "Coral_23",
      "Coral_24",
      "Coral_25",
      "Coral_26",
      "Coral_27",
      "Coral_28",
      "Coral_29",
      "Coral_32",
      "Coral_33",
      "Coral_34",
      "Coral_35",
      "Coral_35b",
      "Coral_36",
      "Coral_37",
      "Coral_38",
      "Coral_39",
      "Coral_40",
      "Coral_41",
      "Coral_42",
      "Coral_43",
      "Coral_Tower_01",
      "Coral_Judge_Arena",
      "Under_01",
      "Under_01b",
      "Under_02",
      "Under_03",
      "Under_03b",
      "Under_03c",
      "Under_03d",
      "Under_04",
      "Under_05",
      "Under_06",
      "Under_07",
      "Under_07b",
      "Under_07c",
      "Under_08",
      "Under_10",
      "Under_11",
      "Under_12",
      "Under_13",
      "Under_14",
      "Under_16",
      "Under_17",
      "Under_18",
      "Under_19",
      "Under_19b",
      "Under_19c",
      "Under_20",
      "Under_21",
      "Under_22",
      "Under_23",
      "Song_01",
      "Song_01b",
      "Song_01c",
      "Song_02",
      "Song_03",
      "Song_04",
      "Song_05",
      "Song_07",
      "Song_08",
      "Song_09",
      "Song_09b",
      "Song_10",
      "Song_11",
      "Song_12",
      "Song_13",
      "Song_14",
      "Song_15",
      "Song_17",
      "Song_18",
      "Song_19_entrance",
      "Song_20",
      "Song_20b",
      "Song_24",
      "Song_25",
      "Song_26",
      "Song_27",
      "Song_Enclave",
      "Song_Enclave_Tube",
      "Tube_Hub",
      "Ward_01",
      "Ward_02",
      "Ward_02b",
      "Ward_03",
      "Ward_04",
      "Ward_05",
      "Ward_06",
      "Ward_07",
      "Library_01",
      "Library_02",
      "Library_03",
      "Library_04",
      "Library_05",
      "Library_06",
      "Library_07",
      "Library_08",
      "Library_09",
      "Library_10",
      "Library_11",
      "Library_11b",
      "Library_12",
      "Library_12b",
      "Library_13",
      "Library_13b",
      "Library_14",
      "Library_15",
      "Library_16",
      "Hang_01",
      "Hang_02",
      "Hang_03",
      "Hang_03_top",
      "Hang_04",
      "Hang_06",
      "Hang_06b",
      "Hang_06_bank",
      "Hang_07",
      "Hang_08",
      "Hang_09",
      "Hang_10",
      "Hang_12",
      "Hang_13",
      "Hang_14",
      "Hang_15",
      "Hang_16",
      "Hang_17b",
      "Arborium_01",
      "Arborium_02",
      "Arborium_03",
      "Arborium_04",
      "Arborium_05",
      "Arborium_06",
      "Arborium_07",
      "Arborium_08",
      "Arborium_09",
      "Arborium_10",
      "Arborium_11",
      "Arborium_Tube",
      "Cog_04",
      "Cog_05",
      "Cog_06",
      "Cog_07",
      "Cog_08",
      "Cog_09",
      "Cog_10",
      "Cog_Bench",
      "Cog_Pass",
      "Cog_Dancers",
      "Cog_Dancers_boss",
      "Cradle_01",
      "Cradle_02",
      "Cradle_03",
      "Song_Tower_01",
      "Song_Tower_Destroyed",
      "Cog_09_Destroyed",
      "Cog_10_Destroyed",
      "Cradle_01_Destroyed",
      "Cradle_03_Destroyed",
      "Cradle_Destroyed_Challenge_Bench",
      "Cradle_Destroyed_Challenge_01",
      "Abandoned_town",
      "Slab_01",
      "Slab_02",
      "Slab_03",
      "Slab_04",
      "Slab_05",
      "Slab_06",
      "Slab_07",
      "Slab_08",
      "Slab_10b",
      "Slab_10c",
      "Slab_12",
      "Slab_13",
      "Slab_14",
      "Slab_15",
      "Slab_16",
      "Slab_17",
      "Slab_18",
      "Slab_19b",
      "Slab_20",
      "Slab_21",
      "Slab_22",
      "Slab_23",
      "Slab_Cell",
      "Slab_Cell_Creature",
      "Slab_Cell_Quiet",
      "Peak_01",
      "Peak_02",
      "Peak_04",
      "Peak_04c",
      "Peak_04d",
      "Peak_05",
      "Peak_05c",
      "Peak_05d",
      "Peak_05e",
      "Peak_06",
      "Peak_07",
      "Peak_08",
      "Peak_08b",
      "Peak_10",
      "Peak_12",
      "Peak_Mask_Maker",
      "Weave_02",
      "Weave_03",
      "Weave_04",
      "Weave_05b",
      "Weave_07",
      "Weave_08",
      "Weave_10",
      "Weave_11",
      "Weave_12",
      "Weave_13",
      "Weave_14",
      "Clover_01",
      "Clover_01b",
      "Clover_02c",
      "Clover_03",
      "Clover_04b",
      "Clover_05c",
      "Clover_06",
      "Clover_10",
      "Clover_10_web",
      "Clover_11",
      "Clover_16",
      "Clover_18",
      "Clover_19",
      "Clover_20",
      "Abyss_01",
      "Abyss_02",
      "Abyss_02b",
      "Abyss_03",
      "Abyss_04",
      "Abyss_05",
      "Abyss_06",
      "Abyss_07",
      "Abyss_08",
      "Abyss_09",
      "Abyss_11",
      "Abyss_12",
      "Abyss_13",
      "Bonetown_boss",
      "Room_CrowCourt",
      "Room_CrowCourt_02",
      "Room_Pinstress",
      "Room_Witch",
      "Room_Caravan_Spa",
      "Room_Caravan_Interior",
      "Room_Huntress",
      "Room_Diving_Bell",
      "Room_Diving_Bell_Abyss",
      "Room_Diving_Bell_Abyss_Fixed",
      "Sprintmaster_Cave",
      "City_Lace_cutscene",
      "Chapel_Wanderer",
      "Memory_Needolin",
      "Memory_First_Sinner",
      "Memory_Silk_Heart_BellBeast",
      "Memory_Silk_Heart_WardBoss",
      "Memory_Silk_Heart_LaceTower",
      "Memory_Coral_Tower",
      "Memory_Ant_Queen",
      "Belltown_Room_Spare",
      "Shadow_08",
      "Cradle_02b",
      "Slab_16b",
      "Clover_21",
      "Pre_Menu_Loader",
      "Bone_East_08_boss_golem",
      "Bone_East_08_boss_golem_rest",
      "Bone_East_08_boss_beastfly",
      "Song_28",
      "Song_29",
      "Aqueduct_08",
      "Coral_44",
      "Hang_04_boss",
      "Shadow_Bilehaven_Room",
      "Abyss_Cocoon",
      "Peak_06b",
      "Bone_East_26",
      "Bone_East_27",
      "Memory_Red",
      "Ward_09",
      "Bone_Steel_Servant",
      "Cradle_Destroyed_Challenge_02",
      "Under_27",
      "Ward_02_boss",
    };

    
    public static Dictionary<string, List<string>> SceneEntrances = new Dictionary<string, List<string>>
    {
        ["Pre_Menu_Intro"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Menu_Title"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Tut_01"] = new List<string>
        {
            "Gate: top1",
            "Gate: right2",
            "Gate: left2",
            "Gate: left1",
            "Gate: left3",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker Init",
        },
        ["Tut_01b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Tut_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Tut_03"] = new List<string>
        {
            "Gate: door2",
            "Gate: door1",
            "Gate: top1",
            "Gate: right1",
            "Gate: door1 firstExit",
            "Respawn Point: RestBench",
        },
        ["Tut_04"] = new List<string>
        {
            "Gate: door_ritualEnd",
            "Gate: door_memoryEnd",
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Tut_05"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_memoryEnd",
            "Respawn Point: Death Respawn Marker",
        },
        ["Mosstown_01"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Mosstown_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot2",
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Mosstown_02c"] = new List<string>
        {
            "Gate: left2",
            "Respawn Point: RestBench",
        },
        ["Mosstown_03"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Aspid_01"] = new List<string>
        {
            "Gate: right2",
            "Gate: left2",
            "Gate: bot1",
            "Gate: right4",
            "Gate: bot2",
            "Gate: right3",
            "Gate: left1",
            "Gate: bot3",
            "Gate: bot4",
            "Gate: bot5",
            "Gate: bot6",
            "Gate: bot7",
            "Gate: bot8",
            "Gate: top1",
            "Gate: top2",
            "Gate: top3",
            "Gate: top4",
            "Gate: top5",
            "Gate: top6",
            "Gate: top7",
            "(no respawn points)",
        },
        ["Crawl_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Crawl_02"] = new List<string>
        {
            "Gate: left2",
            "Gate: right2",
            "Gate: left1",
            "Gate: right1",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Crawl_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Crawl_03b"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Crawl_04"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Crawl_05"] = new List<string>
        {
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Crawl_06"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Crawl_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Crawl_08"] = new List<string>
        {
            "Gate: bot1",
            "Respawn Point: RestBench",
        },
        ["Crawl_09"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Crawl_10"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Belltown"] = new List<string>
        {
            "Gate: door1",
            "Gate: door5",
            "Gate: right2",
            "Gate: door4",
            "Gate: door3",
            "Gate: left3",
            "Respawn Point: RestBench",
        },
        ["Belltown_cutscene"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Belltown_04"] = new List<string>
        {
            "Gate: left2",
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_06"] = new List<string>
        {
            "Gate: door1",
            "Gate: right1",
            "Gate: left3",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Belltown_08"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Belltown_Shrine"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Belltown_Room_pinsmith"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_Room_shellwood"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_Room_doctor"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Belltown_Room_Relic"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_basement"] = new List<string>
        {
            "Gate: bot1",
            "Gate: door_fastTravelExit",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Belltown_basement_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bellway_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_fastTravelExit",
            "(no respawn points)",
        },
        ["Bellway_01_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bellway_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: door_fastTravelExit",
            "(no respawn points)",
        },
        ["Bellway_02_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bellway_03"] = new List<string>
        {
            "Gate: door_fastTravelExit",
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellway_03_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bellway_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: door_fastTravelExit",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bellway_04_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bellway_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: door_fastTravelExit",
            "Respawn Point: RestBench",
        },
        ["Bellway_City"] = new List<string>
        {
            "Gate: door_fastTravelExit",
            "Gate: left1",
            "Gate: door_tubeEnter",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellway_Peak"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: left1",
            "Gate: left2",
            "Gate: top1",
            "Respawn Point: RestBench",
        },
        ["Bellway_Peak_02"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bellway_Shadow"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_fastTravelExit",
            "Respawn Point: RestBench",
        },
        ["Bellway_Aqueduct"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: door_fastTravelExit",
            "Respawn Point: RestBench",
        },
        ["Bellway_Centipede_Arena"] = new List<string>
        {
            "Gate: top1",
            "(no respawn points)",
        },
        ["Bellway_Centipede_additive"] = new List<string>
        {
            "Gate: door_centipedeExit",
            "(no respawn points)",
        },
        ["Bellshrine"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_03"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_05"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_Enclave"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_Coral"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Bellshrine_Lore_Additive"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bonetown"] = new List<string>
        {
            "Gate: door1",
            "Gate: top1",
            "Gate: right1",
            "Gate: right2",
            "Gate: bot2",
            "Gate: left1",
            "Gate: left2",
            "Gate: top2",
            "Gate: bot1",
            "Gate: bot1 firstEntry",
            "Gate: top3",
            "Gate: top4",
            "Gate: top5",
            "Gate: top6",
            "Respawn Point: RestBench",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: Death Respawn Marker Church",
        },
        ["Bonegrave"] = new List<string>
        {
            "Gate: left1",
            "Gate: right2",
            "Gate: top1",
            "Gate: door1",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Bone_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: left2",
            "Gate: top2",
            "Gate: top2 extra",
            "(no respawn points)",
        },
        ["Bone_01b"] = new List<string>
        {
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_01c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Bone_02"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: top2",
            "(no respawn points)",
        },
        ["Bone_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left4",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Bone_04"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot2",
            "Gate: left2",
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bone_05"] = new List<string>
        {
            "Gate: door_fastTravelExit",
            "Gate: door_cinematicEnd",
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "Respawn Point: Silk Heart Memory Respawn Marker",
        },
        ["Bone_05_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bone_05_bellway"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bone_05b"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_06"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_07"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Bone_08"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "Gate: left2",
            "Gate: left3",
            "Gate: right2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Bone_09"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Bone_10"] = new List<string>
        {
            "Gate: door2",
            "Gate: right1",
            "Gate: left1",
            "Gate: bot1",
            "Respawn Point: RestBench",
        },
        ["Bone_11"] = new List<string>
        {
            "Gate: right2",
            "Gate: right1",
            "Gate: top1",
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_11b"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_12"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
            "Respawn Point: RestBench (1)",
        },
        ["Bone_14"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_15"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Bone_16"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_17"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_18"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_19"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Ant_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Ant_03"] = new List<string>
        {
            "Gate: left2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Ant_04"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ant_04_mid"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Ant_04_left"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Ant_05b"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: bot2",
            "(no respawn points)",
        },
        ["Ant_05c"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ant_08"] = new List<string>
        {
            "Gate: top1",
            "(no respawn points)",
        },
        ["Ant_09"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ant_14"] = new List<string>
        {
            "Gate: right3",
            "Gate: left2",
            "Gate: left1",
            "Gate: right2",
            "Gate: left3",
            "Gate: left4",
            "Gate: left5",
            "(no respawn points)",
        },
        ["Ant_17"] = new List<string>
        {
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Ant_19"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_memoryEnd",
            "Respawn Point: Death Respawn Marker",
        },
        ["Ant_20"] = new List<string>
        {
            "Gate: left1",
            "Gate: door1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Ant_21"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ant_Merchant"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ant_Queen"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Dock_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: right2",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Dock_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: left2",
            "Gate: right1",
            "Gate: right2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Dock_02b"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Dock_03"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dock_03b"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dock_03c"] = new List<string>
        {
            "Gate: top2",
            "Gate: left2",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Dock_03d"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Dock_04"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Dock_05"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dock_06_Church"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Respawn Point: RestBench (1)",
        },
        ["Dock_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dock_09"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dock_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Dock_11"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dock_12"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dock_13"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dock_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dock_15"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: right3",
            "Gate: right2",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dock_16"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Room_Forge"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: top1",
            "Respawn Point: RestBench",
        },
        ["Bone_East_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: right3",
            "Gate: right1",
            "Gate: left2",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Bone_East_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_02b"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "Gate: top3",
            "(no respawn points)",
        },
        ["Bone_East_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Gate: right1",
            "Gate: top2",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Bone_East_04c"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Cage Kill Respawn Marker",
        },
        ["Bone_East_04b"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_05"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Bone_East_07"] = new List<string>
        {
            "Gate: top1",
            "Gate: right2",
            "Gate: left1",
            "Gate: left3",
            "Gate: left2",
            "Gate: right3",
            "Gate: right1",
            "Gate: left4",
            "Gate: right4",
            "Gate: right5",
            "(no respawn points)",
        },
        ["Bone_East_08"] = new List<string>
        {
            "Gate: door_cinematicEnd",
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: Silk Heart Memory Respawn Marker",
        },
        ["Bone_East_09"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left2",
            "Gate: door1",
            "Gate: right2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Bone_East_09b"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Bone_East_10_Church"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Bone_East_10_Room"] = new List<string>
        {
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Bone_East_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: bot1",
            "Gate: right2",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Bone_East_12"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_East_13"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_14"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Bone_East_14b"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Bone_East_15"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Bone_East_16"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Bone_East_17"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Bone_East_17b"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_18"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_18b"] = new List<string>
        {
            "Gate: left1",
            "Gate: door1",
            "Gate: top1",
            "Respawn Point: TrapBench",
        },
        ["Bone_East_18c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_20"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_East_21"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_22"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_24"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Bone_East_25"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_East_Weavehome"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Bone_East_Umbrella"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Bone_East_LavaChallenge"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Halfway_01"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Greymoor_01"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "Gate: right3",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Greymoor_02"] = new List<string>
        {
            "Gate: right3",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Greymoor_03"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "Gate: right3",
            "Gate: left3",
            "Gate: right4",
            "Gate: right5",
            "(no respawn points)",
        },
        ["Greymoor_04"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Greymoor_05"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: right2",
            "Gate: left1",
            "Respawn Point: Cage Kill Respawn Marker",
        },
        ["Greymoor_05_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Greymoor_06"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "Gate: left3",
            "Gate: right2",
            "Gate: right4",
            "Gate: left2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Greymoor_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right2",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Greymoor_08"] = new List<string>
        {
            "Gate: left2",
            "Gate: right1",
            "Gate: top1",
            "Respawn Point: Death Respawn Marker NonLethal",
            "Respawn Point: RestBench",
        },
        ["Greymoor_08_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Greymoor_08_caravan"] = new List<string>
        {
            "Gate: door1",
            "Gate: door2",
            "Gate: door_caravanTravelEnd",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Greymoor_08_mapper"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Greymoor_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Greymoor_11"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Greymoor_12"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Greymoor_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Greymoor_15"] = new List<string>
        {
            "Gate: left3",
            "Gate: right3",
            "Gate: right2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Greymoor_15b"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: door1",
            "Gate: left2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Greymoor_16"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Greymoor_17"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Greymoor_20b"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Greymoor_20c"] = new List<string>
        {
            "Gate: door_memoryEnd",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Greymoor_21"] = new List<string>
        {
            "Gate: top1",
            "(no respawn points)",
        },
        ["Greymoor_22"] = new List<string>
        {
            "Gate: bot1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Greymoor_24"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: top1",
            "Gate: right2",
            "Gate: right3",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dust_03"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_04"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dust_05"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dust_06"] = new List<string>
        {
            "Gate: right2",
            "Gate: left1",
            "Gate: right1",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Dust_09"] = new List<string>
        {
            "Gate: door2",
            "Gate: door1",
            "Gate: left2",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dust_10"] = new List<string>
        {
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Dust_11"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: RestBench (1)",
            "Respawn Point: RestBench",
        },
        ["Dust_12"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_Barb"] = new List<string>
        {
            "Gate: top1",
            "(no respawn points)",
        },
        ["Dust_Shack"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_Chef"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_Maze_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Dust_Maze_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: bot1",
            "Gate: top1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dust_Maze_03"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: top1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Dust_Maze_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "Gate: top1 (1)",
            "(no respawn points)",
        },
        ["Dust_Maze_05"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Dust_Maze_06"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_Maze_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Dust_Maze_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "Gate: right3",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Dust_Maze_crossing"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Dust_Maze_Last_Hall"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Dust_Maze_08_completed"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Respawn Point: Death Respawn Marker",
        },
        ["Dust_Maze_09_entrance"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Organ_01"] = new List<string>
        {
            "Gate: left2",
            "Gate: left1",
            "Gate: left3",
            "Respawn Point: RestBench",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shadow_01"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left2",
            "Gate: right2",
            "Gate: left1",
            "Gate: left3",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Shadow_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "Gate: left2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Shadow_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_04"] = new List<string>
        {
            "Gate: top1",
            "Gate: right2",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_04b"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_05"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_09"] = new List<string>
        {
            "Gate: left3",
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shadow_10"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Shadow_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shadow_12"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_13"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shadow_14"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Shadow_15"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Shadow_16"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_18"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: door1",
            "Respawn Point: RestBench",
        },
        ["Shadow_19"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Shadow_20"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Shadow_21"] = new List<string>
        {
            "Gate: bot1",
            "Respawn Point: Cage Kill Respawn Marker",
        },
        ["Shadow_22"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Gate: top2",
            "Gate: top3",
            "(no respawn points)",
        },
        ["Shadow_23"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shadow_24"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shadow_25"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shadow_26"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Shadow_27"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_28"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shadow_Weavehome"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Aqueduct_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Aqueduct_02"] = new List<string>
        {
            "Gate: left3",
            "Gate: right2",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Aqueduct_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Aqueduct_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: door1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Aqueduct_05"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Aqueduct_06"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Aqueduct_07"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Wisp_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Wisp_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: door1",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Wisp_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Wisp_05"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Wisp_06"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Wisp_07"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Wisp_08"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Wisp_09"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Shellwood_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_01b"] = new List<string>
        {
            "Gate: left2",
            "Gate: right1",
            "Gate: left1",
            "Gate: right3",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Shellwood_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: right2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Shellwood_03"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right3",
            "Gate: right2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Shellwood_04b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: top2",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Shellwood_04c"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Shellwood_08"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_08c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Shellwood_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: right3",
            "Gate: right2",
            "Gate: left2",
            "Gate: left1",
            "Gate: left3",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shellwood_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Shellwood_11b"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shellwood_13"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_15"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_16"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shellwood_18"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Shellwood_19"] = new List<string>
        {
            "Gate: door_fastTravelExit",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_20"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_22"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Shellwood_25"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shellwood_25b"] = new List<string>
        {
            "Gate: door_curseSequenceEnd",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shellwood_26"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Shellwood_Witch"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Shellwood_11b_Memory"] = new List<string>
        {
            "Gate: door_wakeInMemory",
            "Respawn Point: Death Respawn Marker",
        },
        ["Shellgrave"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Coral_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot2",
            "Respawn Point: RestBench",
        },
        ["Coral_03"] = new List<string>
        {
            "Gate: left3",
            "Gate: right2",
            "Gate: right3",
            "Gate: left2",
            "Gate: bot1",
            "Gate: bot2",
            "Gate: bot3",
            "Gate: bot4",
            "Gate: bot5",
            "Gate: bot6",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_10"] = new List<string>
        {
            "Gate: left1",
            "Gate: left_firstEntrance",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_11"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_11b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_12"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Coral_19"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: top2",
            "Gate: top3",
            "Gate: top4",
            "Gate: top5",
            "Gate: top6",
            "Gate: top7",
            "Gate: top8",
            "Gate: bot1",
            "Gate: bot2",
            "Gate: bot3",
            "Gate: bot4",
            "Gate: bot5",
            "Gate: bot6",
            "Gate: bot7",
            "(no respawn points)",
        },
        ["Coral_19b"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Coral_23"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Coral_24"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_25"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_26"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Coral_27"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_28"] = new List<string>
        {
            "Gate: door1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_29"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_32"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_33"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_34"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Coral_35"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Coral_35b"] = new List<string>
        {
            "Gate: left5",
            "Gate: left4",
            "Gate: left3",
            "Gate: right2",
            "Gate: right1",
            "Gate: bot1",
            "Gate: left2",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Coral_36"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_37"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_38"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_39"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_40"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_41"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_42"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_43"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Coral_Tower_01"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Coral_Judge_Arena"] = new List<string>
        {
            "Gate: door_caravanTravelEnd",
            "Gate: right1",
            "Gate: left1",
            "Gate: door2",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: RestBench",
        },
        ["Under_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Respawn Point: Death Respawn Marker",
        },
        ["Under_01b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Under_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "Gate: left1",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Under_03"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Under_03b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_03c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Under_03d"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Under_04"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_05"] = new List<string>
        {
            "Gate: left3",
            "Gate: right1",
            "Gate: left1",
            "Gate: right3",
            "Gate: right2",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Under_06"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_07"] = new List<string>
        {
            "Gate: top1",
            "Gate: left3",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Under_07b"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Under_07c"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Under_08"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Respawn Point: RestBench",
            "Respawn Point: RestBench (1)",
            "Respawn Point: RestBench (2)",
        },
        ["Under_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_12"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "Gate: right1",
            "Gate: right3",
            "Gate: left3",
            "Gate: left4",
            "(no respawn points)",
        },
        ["Under_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_16"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Under_17"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: bot2",
            "Respawn Point: Death Respawn Marker Architect Door",
            "Respawn Point: RestBench",
        },
        ["Under_18"] = new List<string>
        {
            "Gate: right1",
            "Gate: top2",
            "Gate: top1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Under_19"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Under_19b"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Under_19c"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Under_20"] = new List<string>
        {
            "Gate: door_memoryEnd",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Under_21"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Under_22"] = new List<string>
        {
            "Gate: door_tubeEnter",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Under_23"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Song_01"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Song_01b"] = new List<string>
        {
            "Gate: bot1",
            "Gate: door_tubeEnter",
            "Gate: right1",
            "Gate: top1",
            "Respawn Point: RestBench",
        },
        ["Song_01c"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Song_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Song_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Song_04"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: bot1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Song_05"] = new List<string>
        {
            "Gate: left3",
            "Gate: left4",
            "Gate: left5",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "(no respawn points)",
        },
        ["Song_07"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_08"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_09"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Song_09b"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Song_10"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Song_11"] = new List<string>
        {
            "Gate: right2",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: right3",
            "Gate: left4",
            "(no respawn points)",
        },
        ["Song_12"] = new List<string>
        {
            "Gate: left3",
            "Gate: left2",
            "Gate: left1",
            "Gate: left4",
            "Gate: right1",
            "Gate: right2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Song_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Song_15"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_17"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Song_18"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Song_19_entrance"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Song_20"] = new List<string>
        {
            "Gate: top1",
            "Gate: right6",
            "Gate: right_cutsceneEntry",
            "Gate: right5",
            "Gate: right4",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Song_20b"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: left4",
            "Gate: right2",
            "Gate: right3",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Song_24"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_25"] = new List<string>
        {
            "Gate: top2",
            "Gate: left1",
            "Gate: top1",
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Song_26"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_27"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Song_Enclave"] = new List<string>
        {
            "Gate: door1",
            "Gate: door_act3_wakeUp",
            "Gate: bot1",
            "Gate: top1",
            "Gate: left1",
            "Gate: left2",
            "Respawn Point: RestBench",
        },
        ["Song_Enclave_Tube"] = new List<string>
        {
            "Gate: door_tubeEnter",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Tube_Hub"] = new List<string>
        {
            "Gate: door_tubeEnter",
            "Gate: left1",
            "Gate: left3",
            "Gate: left4",
            "Respawn Point: RestBench",
        },
        ["Ward_01"] = new List<string>
        {
            "Gate: right2",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: right3",
            "Respawn Point: RestBench",
        },
        ["Ward_02"] = new List<string>
        {
            "Gate: door_cinematicEnd",
            "Gate: bot1",
            "Gate: top1",
            "Gate: right1",
            "Respawn Point: Silk Heart Memory Respawn Marker",
        },
        ["Ward_02b"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Ward_03"] = new List<string>
        {
            "Gate: door1",
            "Gate: top1",
            "Gate: left1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Ward_04"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Ward_05"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Ward_06"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Ward_07"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Library_01"] = new List<string>
        {
            "Gate: left3",
            "Gate: left1",
            "Gate: right1",
            "Gate: left2",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Library_02"] = new List<string>
        {
            "Gate: left2",
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Library_03"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Library_04"] = new List<string>
        {
            "Gate: left4",
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "Gate: right5",
            "Gate: right6",
            "(no respawn points)",
        },
        ["Library_05"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: left1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Library_06"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Library_07"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: left1",
            "Gate: left2",
            "Gate: bot2",
            "Gate: bot3",
            "(no respawn points)",
        },
        ["Library_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Library_09"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker Garmond",
        },
        ["Library_10"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Respawn Point: RestBench",
        },
        ["Library_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Gate: left3",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Library_11b"] = new List<string>
        {
            "Gate: left3",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Library_12"] = new List<string>
        {
            "Gate: door1",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Library_12b"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Library_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: right2",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Library_13b"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Library_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Library_15"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Library_16"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Hang_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_03"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Hang_03_top"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Hang_04"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Hang_06"] = new List<string>
        {
            "Gate: right1",
            "Gate: door1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Hang_06b"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_tubeEnter",
            "Respawn Point: RestBench",
        },
        ["Hang_06_bank"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Hang_07"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "Gate: top1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_08"] = new List<string>
        {
            "Gate: right2",
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: left3",
            "Gate: left2",
            "Gate: left4",
            "(no respawn points)",
        },
        ["Hang_09"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_10"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_12"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_14"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Hang_15"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_16"] = new List<string>
        {
            "Gate: door1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_17b"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_01"] = new List<string>
        {
            "Gate: right5",
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: left2",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Arborium_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_03"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: left4",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Arborium_04"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Arborium_05"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Arborium_06"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Arborium_08"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_09"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Arborium_10"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Arborium_Tube"] = new List<string>
        {
            "Gate: door_tubeEnter",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Cog_04"] = new List<string>
        {
            "Gate: door1",
            "Gate: top1",
            "Gate: left2",
            "Gate: right2",
            "Gate: right3",
            "Gate: top2",
            "Gate: door2",
            "(no respawn points)",
        },
        ["Cog_05"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Cog_06"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Cog_07"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Cog_08"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Cog_09"] = new List<string>
        {
            "Gate: bot1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Cog_10"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Cog_Bench"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Cog_Pass"] = new List<string>
        {
            "Gate: left2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Cog_Dancers"] = new List<string>
        {
            "Gate: door_arriveFromTower",
            "Gate: door1",
            "Gate: top1",
            "Gate: bot1",
            "Gate: right1",
            "Gate: left1",
            "Gate: bot2",
            "Respawn Point: Interim Respawn Marker",
        },
        ["Cog_Dancers_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cradle_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Cradle_02"] = new List<string>
        {
            "Gate: right2",
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Cradle_03"] = new List<string>
        {
            "Gate: right2",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Song_Tower_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: door_cutsceneEndLaceTower",
            "Gate: door_cinematicEnd",
            "Respawn Point: Silk Heart Memory Respawn Marker",
        },
        ["Song_Tower_Destroyed"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Respawn Point: Death Respawn Marker",
            "Respawn Point: Death Respawn Marker Init",
        },
        ["Cog_09_Destroyed"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Cog_10_Destroyed"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Cradle_01_Destroyed"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Cradle_03_Destroyed"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Cradle_Destroyed_Challenge_Bench"] = new List<string>
        {
            "Gate: door1",
            "Gate: right1",
            "Gate: bot1",
            "Respawn Point: RestBench",
        },
        ["Cradle_Destroyed_Challenge_01"] = new List<string>
        {
            "Gate: top1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Abandoned_town"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Slab_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_03"] = new List<string>
        {
            "Gate: door_slabCaged",
            "Gate: right8",
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: left4",
            "Gate: left5",
            "Gate: left6",
            "Gate: right3",
            "Gate: right5",
            "Gate: right4",
            "Gate: right2",
            "Gate: right7",
            "Gate: right9",
            "Gate: left7",
            "Gate: left8",
            "Respawn Point: Caged Respawn Marker",
            "Respawn Point: Cage Broken Respawn Marker",
        },
        ["Slab_04"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Gate: right1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Slab_05"] = new List<string>
        {
            "Gate: bot1",
            "Gate: right1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Slab_06"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "Gate: top1",
            "Gate: door_fastTravelExit",
            "Respawn Point: RestBench",
        },
        ["Slab_07"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Slab_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Slab_10b"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
        },
        ["Slab_10c"] = new List<string>
        {
            "Gate: left1",
            "Gate: door1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Slab_12"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_13"] = new List<string>
        {
            "Gate: left1",
            "Gate: bot1",
            "Gate: right1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Slab_14"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Slab_15"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Slab_16"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "Gate: left1",
            "Gate: right1",
            "Gate: top1",
            "Respawn Point: RestBench",
            "Respawn Point: RestBench (1)",
        },
        ["Slab_17"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_18"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_19b"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Slab_20"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Slab_21"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "Gate: left3",
            "(no respawn points)",
        },
        ["Slab_22"] = new List<string>
        {
            "Gate: bot1",
            "Gate: bot2",
            "(no respawn points)",
        },
        ["Slab_23"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "Gate: right1",
            "Gate: door2",
            "(no respawn points)",
        },
        ["Slab_Cell"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_Cell_Creature"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Slab_Cell_Quiet"] = new List<string>
        {
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Peak_01"] = new List<string>
        {
            "Gate: right1",
            "Gate: top1",
            "Gate: left1",
            "Gate: left2",
            "Gate: left3",
            "Gate: left4",
            "Gate: top2",
            "Gate: top3",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "Gate: top4",
            "(no respawn points)",
        },
        ["Peak_02"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "Gate: left3",
            "Gate: left2",
            "Respawn Point: RestBench",
        },
        ["Peak_04"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Peak_04c"] = new List<string>
        {
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Peak_04d"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Peak_05"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top2",
            "Gate: right3",
            "(no respawn points)",
        },
        ["Peak_05c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Peak_05d"] = new List<string>
        {
            "Gate: door1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Peak_05e"] = new List<string>
        {
            "Gate: right2",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Peak_06"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Peak_07"] = new List<string>
        {
            "Gate: top2",
            "Gate: top1",
            "Gate: bot2",
            "Gate: bot5",
            "Gate: bot4",
            "Gate: bot1",
            "Gate: bot3",
            "Respawn Point: RestBench",
            "Respawn Point: Death Respawn Marker Pinstress",
        },
        ["Peak_08"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Peak_08b"] = new List<string>
        {
            "Gate: left1",
            "Gate: left2",
            "Gate: bot4",
            "Gate: bot5",
            "Gate: bot6",
            "Respawn Point: Death Respawn Marker",
        },
        ["Peak_10"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Peak_12"] = new List<string>
        {
            "Gate: right1",
            "Respawn Point: RestBench (1)",
        },
        ["Peak_Mask_Maker"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Weave_02"] = new List<string>
        {
            "Gate: right2",
            "Gate: left3",
            "Gate: left2",
            "Gate: right3",
            "Gate: right1",
            "Gate: left4",
            "(no respawn points)",
        },
        ["Weave_03"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Weave_04"] = new List<string>
        {
            "Gate: right2",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Weave_05b"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Weave_07"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Respawn Point: RestBench",
        },
        ["Weave_08"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Weave_10"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Weave_11"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Weave_12"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Weave_13"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Weave_14"] = new List<string>
        {
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Clover_01"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Clover_01b"] = new List<string>
        {
            "Gate: door_wakeInMemory",
            "Gate: right1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Clover_02c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Clover_03"] = new List<string>
        {
            "Gate: left2",
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Clover_04b"] = new List<string>
        {
            "Gate: door1",
            "Gate: left1",
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Clover_05c"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "Gate: right2",
            "Gate: right3",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Clover_06"] = new List<string>
        {
            "Gate: bot1",
            "Gate: bot2",
            "(no respawn points)",
        },
        ["Clover_10"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Clover_10_web"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Clover_11"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Clover_16"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Clover_18"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Clover_19"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Clover_20"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Abyss_01"] = new List<string>
        {
            "Gate: left1",
            "Gate: right2",
            "Gate: right3",
            "Gate: right4",
            "(no respawn points)",
        },
        ["Abyss_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Abyss_02b"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Abyss_03"] = new List<string>
        {
            "Gate: door1",
            "Gate: door2",
            "Gate: left1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Abyss_04"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Abyss_05"] = new List<string>
        {
            "Gate: right1",
            "Gate: left2",
            "(no respawn points)",
        },
        ["Abyss_06"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Abyss_07"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Abyss_08"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Abyss_09"] = new List<string>
        {
            "Gate: bot1",
            "Gate: top1",
            "Respawn Point: RestBench",
            "Respawn Point: Death Respawn Marker",
        },
        ["Abyss_11"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "(no respawn points)",
        },
        ["Abyss_12"] = new List<string>
        {
            "Gate: left1",
            "Gate: right2",
            "Respawn Point: RestBench",
        },
        ["Abyss_13"] = new List<string>
        {
            "Gate: top1",
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Cinematic_Stag_travel"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_Ending_A"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_Ending_B"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_Ending_C"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_Ending_D"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["End_Credits"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_MrMushroom"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Menu_Credits"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["End_Game_Completion"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["PermaDeath"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Opening_Sequence"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Quit_To_Menu"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bonetown_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Room_Caravan_Interior_Travel"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Room_CrowCourt"] = new List<string>
        {
            "Gate: bot1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Room_CrowCourt_02"] = new List<string>
        {
            "Gate: top1",
            "(no respawn points)",
        },
        ["Room_Pinstress"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Room_Witch"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Room_Caravan_Spa"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Room_Caravan_Interior"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Room_Huntress"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Room_Diving_Bell"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_cinematicEnd",
            "Respawn Point: RestBench",
        },
        ["Room_Diving_Bell_Abyss"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Room_Diving_Bell_Abyss_Fixed"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_cinematicEnd",
            "Respawn Point: RestBench",
        },
        ["Sprintmaster_Cave"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["City_Lace_cutscene"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Chapel_Wanderer"] = new List<string>
        {
            "Gate: left1",
            "Gate: door_memoryEnd",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Needolin"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Gate: right1",
            "Gate: left1",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_First_Sinner"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Silk_Heart_BellBeast"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Silk_Heart_WardBoss"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Silk_Heart_LaceTower"] = new List<string>
        {
            "Gate: door_wakeOnGround",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Coral_Tower"] = new List<string>
        {
            "Gate: door_wakeInMemory",
            "Respawn Point: Death Respawn Marker",
        },
        ["Memory_Ant_Queen"] = new List<string>
        {
            "Gate: door_wakeInMemory",
            "Respawn Point: Death Respawn Marker",
        },
        ["Opening_Sequence_Act3"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Last_Dive"] = new List<string>
        {
            "Gate: door_cutscenePosition",
            "(no respawn points)",
        },
        ["Last_Dive_Return"] = new List<string>
        {
            "Gate: door_cutscenePosition",
            "(no respawn points)",
        },
        ["Belltown_Room_Spare"] = new List<string>
        {
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["End_Credits_Scroll"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Cinematic_Ending_E"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Shadow_08"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "Respawn Point: RestBench",
        },
        ["Cradle_02b"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Slab_16b"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Clover_21"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Pre_Menu_Loader"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bone_East_08_boss_golem"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bone_East_08_boss_golem_rest"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Bone_East_08_boss_beastfly"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Song_28"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Song_29"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Aqueduct_08"] = new List<string>
        {
            "Gate: right1",
            "Gate: left1",
            "(no respawn points)",
        },
        ["Coral_44"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "(no respawn points)",
        },
        ["Hang_04_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Shadow_Bilehaven_Room"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Abyss_Cocoon"] = new List<string>
        {
            "Gate: door_entry",
            "Gate: door_test",
            "(no respawn points)",
        },
        ["Peak_06b"] = new List<string>
        {
            "Gate: left1",
            "Gate: door1",
            "(no respawn points)",
        },
        ["Bone_East_26"] = new List<string>
        {
            "Gate: top1",
            "Gate: bot1",
            "Respawn Point: TrapBench",
        },
        ["Bone_East_27"] = new List<string>
        {
            "Gate: right1",
            "Gate: bot1",
            "Gate: left1",
            "Respawn Point: RestBench",
        },
        ["Memory_Red"] = new List<string>
        {
            "Gate: top1",
            "Gate: door_wakeInMemory",
            "Gate: door_enterRedMemory Weaver",
            "Gate: door_wakeInRedMemory Weaver",
            "Gate: door_enterRedMemory Beast",
            "Gate: door_wakeInRedMemory Beast",
            "Gate: door_enterRedMemory Hive",
            "Gate: door_wakeInRedMemory Hive",
            "Gate: door_wakeInRedMemory Root",
            "Respawn Point: Death Respawn Marker",
        },
        ["Ward_09"] = new List<string>
        {
            "Gate: left1",
            "(no respawn points)",
        },
        ["Bone_Steel_Servant"] = new List<string>
        {
            "Gate: right1",
            "(no respawn points)",
        },
        ["Cradle_Destroyed_Challenge_02"] = new List<string>
        {
            "Gate: left1",
            "Gate: top1",
            "(no respawn points)",
        },
        ["Under_27"] = new List<string>
        {
            "Gate: left1",
            "Gate: right1",
            "Gate: right2",
            "(no respawn points)",
        },
        ["Demo End"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Demo Start"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Ward_02_boss"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Aqueduct_05_caravan"] = new List<string>
        {
            "Gate: door2",
            "Gate: door_caravanTravelEnd",
            "Respawn Point: RestBench",
            "Respawn Point: Death Respawn Marker",
        },
        ["Aqueduct_05_pre"] = new List<string>
        {
            "(no transition gates)",
            "(no respawn points)",
        },
        ["Aqueduct_05_festival"] = new List<string>
        {
            "(no transition gates)",
            "Respawn Point: RestBench Festival",
        },
    };

}
