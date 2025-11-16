using UnityEngine;
using ParticlePlayground;

public class BlackFireballChargedEffect : BlackFireballEffect {
    public Transform _Sphere;
    public PlaygroundParticlesC _Embers;
    public PlaygroundParticlesC _FireRing;

    private Component halo;

    private BlackFireballChargedCurve chargedBlackFireballCurve;

    private float currentTime;
    private float startScale;
    private float chargeTime;

    void Awake() {
        startScale = _Sphere.localScale.x;
        halo = _Sphere.GetComponent("Halo");
        chargedBlackFireballCurve = new BlackFireballChargedCurve();
    }

    void OnEnable() {
        _Sphere.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void startCharging(float chargeTime) {
        this.chargeTime = chargeTime;
        enabled = true;
        currentTime = 0;
        EnableHalo(false);
        chargedBlackFireballCurve.generate(chargeTime);
        updateLifeTimeOffset();
    }

    void Update() {
        if (chargeTime == 0) {
            return;
        }
        IncreaseSphereSize();
        DisableWhenSphereFinished();

    }

    private void DisableWhenSphereFinished() {
        if (currentTime > chargeTime + 0.3f) {
            EnableHalo(true);
            enabled = false;
        }
    }

    private void IncreaseSphereSize() {
        currentTime += Time.deltaTime;
        float scale = chargedBlackFireballCurve.getScale(currentTime) * startScale;
        _Sphere.localScale = new Vector3(scale, scale, scale);
    }

    void OnDisable() {
        chargeTime = 0;
    }

    private void updateLifeTimeOffset() {
        _FireRing.lifetimeOffset = chargeTime - 0.1f;
        _FireRing.gameObject.SetActive(false);
        _FireRing.gameObject.SetActive(true);
        _Embers.lifetimeOffset = chargeTime - 0.4f;
        _Embers.gameObject.SetActive(false);
        _Embers.gameObject.SetActive(true);
    }

    private void EnableHalo(bool value) {
        halo.GetType().GetProperty("enabled").SetValue(halo, value, null);
    }


}
