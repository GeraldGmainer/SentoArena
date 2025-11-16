public abstract class SpellPort : SpellCast, ISpellPort {
    public IPortSettings PortSettings { get { return (IPortSettings)getSpellSettings(); } }

    //effect spanwer here
}
