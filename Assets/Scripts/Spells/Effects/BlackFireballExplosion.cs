using UnityEngine;
using ParticlePlayground;

public class BlackFireballExplosion : MonoBehaviour {

    public PlaygroundParticlesC Explosion;

    void OnEnable() {
        Explosion.loop = false;
    }
}
