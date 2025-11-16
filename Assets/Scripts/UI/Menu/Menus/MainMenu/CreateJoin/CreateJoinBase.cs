using UnityEngine;

public abstract class CreateJoinBase  {
    protected CreateJoinMenu createJoinMenu;

    protected CreateJoinBase(CreateJoinMenu createJoinMenu) {
        this.createJoinMenu = createJoinMenu;
    } 

    public virtual void onShow() {

    }

    public virtual void onHide() {

    }
}
