public abstract class ValidatorBase  {

    public bool isValid { get; protected set; }

    protected CreateJoinMenu createJoinMenu;

    protected ValidatorBase(CreateJoinMenu createJoinMenu) {
        this.createJoinMenu = createJoinMenu;
    }

    public abstract void validate();
}
