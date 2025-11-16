using System.Collections.Generic;

public class MaxPlayerSwitcher : SettingSwitcher {
    public int minPlayer = 1;
    public int maxPlayer = 31;

    public override string[] getUIList() {
        List<string> names = new List<string>();
        for (int i = minPlayer; i <= maxPlayer; i++) {
            names.Add(i.ToString());
        }
        return names.ToArray();
    }
}
