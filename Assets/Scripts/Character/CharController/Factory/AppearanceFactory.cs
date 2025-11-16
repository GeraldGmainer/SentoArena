
public static class AppearanceFactory {
    private const string ROOT_PATH = "Appearance/";

    public static string getPath(HairEnum hairEnum) {
        switch (hairEnum) {
            case HairEnum.TENRYUU:
            return ROOT_PATH + "Hair/TenryuuHair";

            case HairEnum.TOUKA:
            return ROOT_PATH + "Hair/ToukaHair";

            case HairEnum.KAWAKAMI:
            return ROOT_PATH + "Hair/KawakamiHair";
        }
        return null;
    }

    public static string getPath(NeckEnum neckEnum) {
        switch (neckEnum) {
            case NeckEnum.KANUU:
            return ROOT_PATH + "Neck/KanuuChoker";
        }
        return null;
    }

    public static string getPath(GlovesEnum glovesEnum) {
        switch (glovesEnum) {
            case GlovesEnum.FINGERLESS:
            return ROOT_PATH + "Gloves/FingerlessGloves";

            case GlovesEnum.KANUU:
            return ROOT_PATH + "Gloves/KanuuGloves";
        }
        return null;
    }

    public static string getPath(ChestEnum chestEnum) {
        switch (chestEnum) {
            case ChestEnum.CASUAL:
            return ROOT_PATH + "Chest/CasualShirt";

            case ChestEnum.SCHOOL:
            return ROOT_PATH + "Chest/SchoolShirt";

            case ChestEnum.KANUU:
            return ROOT_PATH + "Chest/KanuuChest";

            case ChestEnum.TEST:
            return ROOT_PATH + "Chest/Test";

        }
        return null;
    }

    public static string getPath(LegsEnum legsEnum) {
        switch (legsEnum) {
            case LegsEnum.CASUAL:
            return ROOT_PATH + "Legs/CasualPants";

            case LegsEnum.SCHOOL:
            return ROOT_PATH + "Legs/SchoolSkirt";

            case LegsEnum.KANUU:
            return ROOT_PATH + "Legs/KanuuLegs";

            case LegsEnum.TEST:
            return ROOT_PATH + "Legs/TestLegs";

        }
        return null;
    }

    public static string getPath(BootsEnum bootsEnum) {
        switch (bootsEnum) {
            case BootsEnum.CASUAL:
            return ROOT_PATH + "Boots/CasualBoots";

            case BootsEnum.HIGH_HEELS:
            return ROOT_PATH + "Boots/HighHeels";

            case BootsEnum.TEST:
            return ROOT_PATH + "Boots/TestBoots";

        }
        return null;
    }

}
