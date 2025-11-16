using UnityEngine;

public class MapSwitcher : SettingSwitcher {
    public override string[] getUIList() {
        return new MapConverter().convert();
    }
}
