using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller> {
    public override void InstallBindings() {
        Container.Bind<ZenGameObjectService>().AsSingle();
        Container.Bind<ZenBoneService>().AsSingle();
    }
}