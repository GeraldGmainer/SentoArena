using UnityEngine;
using System.Collections.Generic;

public class BotAIController : MonoBehaviour, IAIController {
    private const float HEIGHT_OFFSET = 1f;

    public GameObject _StateCube;

    public Vector3 m_emoryPoint { get; set; }
    public CharController m_currentChar { get; set; }

    public Transform m_transform { get { return transform; } }
    public Vector3 m_botPosition { get { return transform.position + new Vector3(0, HEIGHT_OFFSET, 0); } }
    public Vector3 m_targetPosition { get { return m_currentChar.transform.position + new Vector3(0, HEIGHT_OFFSET, 0); } }
    public float m_distanceToTarget { get { return Vector3.Distance(m_botPosition, m_targetPosition); } }

	
    private IBotState m_currentState;
    private Dictionary<BotState, IBotState> m_botStates = new Dictionary<BotState, IBotState>();

    void Awake() {
        InitBotStates();
    }

    private void InitBotStates() {
        BotActorDriver botActorDriver = GetComponent<BotActorDriver>();

        BotDeadState botDeadState = new BotDeadState(this);
        BotSearchingState botSearchingState = new BotSearchingState(this);
        botDeadState.setActorDriver(botActorDriver);
        botSearchingState.setActorDriver(botActorDriver);

        m_botStates.Add(BotState.DEAD, botDeadState);
        m_botStates.Add(BotState.SEARCHING, botSearchingState);
    }

    void Start() {
        Init();
    }

    public void Init() {
        goToState(BotState.SEARCHING);
    }

    void Update() {

    }

    public void goToState(BotState botState) {
        if (m_currentState != null) {
            m_currentState.OnExit();
        }
        m_currentState = m_botStates[botState];
        m_currentState.OnEnter();
    }

    public void OnDeath() {
        enabled = false;
        goToState(BotState.DEAD);
    }

    public void OnRespawn() {
        enabled = true;
        goToState(BotState.SEARCHING);
    }

    public void OnReceiveDamage(SpellDamage spellDamage) {
        m_currentState.OnReceiveDamage(spellDamage);
    }

    public void OnBotWaypointEnter(BotWaypoint botWaypoint) {
        m_currentState.OnBotWaypointEnter(botWaypoint);
    }


    public void RefreshMemoryPoint() {
        m_emoryPoint = m_targetPosition;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(m_emoryPoint, 0.1f);
    }

    public void UpdateStateCubeColor(Color color) {
        _StateCube.GetComponent<MeshRenderer>().material.color = color;
    }




    public void SetBotStates(Dictionary<BotState, IBotState> botStates) {
        this.m_botStates = botStates;
    }
}
