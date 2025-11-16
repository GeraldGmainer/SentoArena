using UnityEngine;
using Zenject;

public class ZenBoneService {
    public Transform LeftSwordBone { get; private set; }
    public Transform RightSwordBone { get; private set; }

    [Inject]
    private ZenCharController m_charController;
    [Inject]
    private ZenGameObjectService m_gameObjectService;

    [Inject]
    public void Construct() {
        LeftSwordBone = m_gameObjectService.inChildByName(m_charController.transform, "swordBone_L").transform;
        RightSwordBone = m_gameObjectService.inChildByName(m_charController.transform, "swordBone_R").transform;
    }
}
