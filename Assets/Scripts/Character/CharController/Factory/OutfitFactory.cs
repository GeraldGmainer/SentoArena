public static class OutfitFactory {

    public static CharOutfit Determine(OutfitEnum outfitEnum) {
        switch (outfitEnum) {
            case OutfitEnum.KANUU:
            return CreateKanuuOutfit();

            default:
            return new CharOutfit();
        }
    }

    private static CharOutfit CreateKanuuOutfit() {
        CharOutfit outfit = new CharOutfit();
        outfit.hairEnum = HairEnum.TOUKA;
        outfit.neckEnum = NeckEnum.KANUU;
        outfit.chestEnum = ChestEnum.KANUU;
        outfit.glovesEnum = GlovesEnum.KANUU;
        outfit.legsEnum = LegsEnum.KANUU;
        outfit.bootsEnum = BootsEnum.HIGH_HEELS;
        return outfit;
    }
}
