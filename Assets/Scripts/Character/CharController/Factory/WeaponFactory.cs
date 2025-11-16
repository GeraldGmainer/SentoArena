public static class WeaponFactory {
    public static IObjectPooler getPooler(Weapon weapon) {
        switch (weapon) {
            case Weapon.SCYTHE:
            return ScythePooler.instance;

            case Weapon.SAI:
            return SaiPooler.instance;

            case Weapon.KATANA:
            return KatanaPooler.instance;
        }
        return null;
    }
}
