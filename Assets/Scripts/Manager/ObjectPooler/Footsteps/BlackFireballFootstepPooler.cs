public class BlackFireballFootstepPooler : ObjectPooler<BlackFireballFootstepPooler> {

    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Footsteps/FootstepsBlackFireball";
    }
}
