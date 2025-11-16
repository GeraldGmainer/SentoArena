using UnityEngine;

public class HUDWeaponUpdater {
    private RectTransform scythe;
    private RectTransform sai;

    public HUDWeaponUpdater(RectTransform scythe, RectTransform sai) {
        this.scythe = scythe;
        this.sai = sai;
    }

    public void change(Weapon weapon) {
        if (weapon == Weapon.SCYTHE) {
            scythe.gameObject.SetActive(true);
            sai.gameObject.SetActive(false);
        }
        else {
            scythe.gameObject.SetActive(false);
            sai.gameObject.SetActive(true);
        }
    }
}
