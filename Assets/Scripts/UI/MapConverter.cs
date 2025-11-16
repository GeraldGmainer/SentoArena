using UnityEngine;
using System;
using System.Collections.Generic;

public class MapConverter {
    public const string MAIN_MENU = "MainMenuScene";
    public const string TEST_MAP = "Test Map";
    public const string PLANET_ARENA = "Planet Arena";
    public const string JUMPING_PUZZLE = "Jumping Puzzle";

    public string[] convert() {
        List<string> names = new List<string>();
        foreach (MapEnum mapEnum in Enum.GetValues(typeof(MapEnum))) {
            if(mapEnum == MapEnum.TEST_MAP) {
                continue;
            }
            names.Add(convert(mapEnum));
        }
        return names.ToArray();
    }

    public string convert(MapEnum mapEnum) {
        switch (mapEnum) {
            case MapEnum.TEST_MAP:
            return TEST_MAP;

            case MapEnum.PLANET_ARENA:
            return PLANET_ARENA;

            case MapEnum.JUMPING_PUZZLE:
            return JUMPING_PUZZLE;
        }

        return "undefined";
    }

    public MapEnum convert(string sceneName) {
        switch (sceneName) {
            case TEST_MAP:
            return MapEnum.TEST_MAP;

            case JUMPING_PUZZLE:
            return MapEnum.JUMPING_PUZZLE;

            case PLANET_ARENA:
            return MapEnum.PLANET_ARENA;

            default:
            Debug.LogError("WTF MapConverter Unknown Map " + sceneName);
            return 0;
        }
    }
}
