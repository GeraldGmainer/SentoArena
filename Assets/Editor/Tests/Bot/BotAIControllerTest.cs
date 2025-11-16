using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace BotTest {
    public class BotAIControllerTest {

        private GameObject go;
        private BotAIController botAIController;
        private IBotState searchingState;
        private IBotState deadState;

        [SetUp]
        public void Init() {
            go = new GameObject("BotAIControllerTest");
            botAIController = go.AddComponent<BotAIController>();
            botAIController.SetBotStates(GetBotStatesMock());
            botAIController.Init();
        }

        [Test]
        public void SearchingStateIsDefaultState() {
            searchingState.Received(1).OnEnter();
        }

        [Test]
        public void DeadStateIsEntered() {
            botAIController.OnDeath();

            botAIController.enabled = false;
            deadState.Received(1).OnEnter();
        }

        [Test]
        public void BotIsRespawnedCorrectly() {
            botAIController.OnDeath();
            botAIController.OnRespawn();

            botAIController.enabled = true;
            searchingState.Received(2).OnEnter();
        }

        [Test]
        public void DamageToCurrentStateIsReceived() {
            SpellDamage spellDamage = new SpellDamage(3, Vector3.forward);
            botAIController.OnReceiveDamage(spellDamage);

            searchingState.Received(1).OnReceiveDamage(spellDamage);
        }

        [TearDown]
        public void Cleanup() {
            Object.DestroyImmediate(go);
        }

        private Dictionary<BotState, IBotState> GetBotStatesMock() {
            Dictionary<BotState, IBotState> botStates = new Dictionary<BotState, IBotState>();
            searchingState = Substitute.For<IBotState>();
            deadState = Substitute.For<IBotState>();

            botStates.Add(BotState.SEARCHING, searchingState);
            botStates.Add(BotState.DEAD, deadState);
            return botStates;
        }
    }
}
