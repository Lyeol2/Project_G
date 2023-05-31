using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ProjectG
{

    public enum EInGameStateType
    {
        Move,
        Battle,
        Targeting,
        
    }
    /// <summary>
    /// 전투씬
    /// </summary>
    public class InGameController : Controller
    {
        // ------------- Prefabs ---------------
        [SerializeField] GameObject playerCharacterPrefab;
        // ------------- Characters -------------------

        [SerializeField]
        public CharacterPool characterPool;

        Dictionary<EInGameStateType, InGameState> cachedState = new Dictionary<EInGameStateType, InGameState>();

        EInGameStateType currentState;

        public override void InitController()
        {
            base.InitController();

            cachedState.Add(EInGameStateType.Move, new MoveState());
            cachedState.Add(EInGameStateType.Battle, new BattleState());
            cachedState.Add(EInGameStateType.Targeting, new TargetingState());

            characterPool = FindObjectOfType<CharacterPool>();

            characterPool.Initialize();


            characterPool.AddCharacter(ECampPos.PlayerFront, 1000);
            characterPool.AddCharacter(ECampPos.EnemyFront, 1000);
            characterPool.AddCharacter(ECampPos.EnemyMiddle, 1000);
            characterPool.AddCharacter(ECampPos.EnemyBack, 1000);


            ChangeState(EInGameStateType.Battle);
        }
        public override void UpdateController()
        {
            base.UpdateController();

            cachedState[currentState].Idle(this);
        }
        private void OnGUI()
        {

            var style = new GUIStyle(GUI.skin.button);
            style.fontSize = 70;

            if (GUILayout.Button("Skip", style))
            {
            }
        }
        // 스킬 타겟을 선택하는 패널 상태를 만듭니다.
        public void OnSkillTargetSelect(ECampPos pos)
        {
            characterPool.SetOnPanelCharacter(pos);
        }

        public void ChangeState(EInGameStateType type)
        {

            cachedState[currentState]?.Exit(this);

            currentState = type;

            cachedState[currentState]?.Enter(this);
        }

        public T GetState<T>(EInGameStateType type) where T : InGameState
        {
            if (cachedState[type] is T)
            {
                return cachedState[type] as T;
            }

            Debug.LogError($"state didn't find {typeof(T).Name}");
            return null;

        }
        public T GetCurrentState<T>() where T : InGameState
        {
            if (cachedState[currentState] is T)
            {
                return cachedState[currentState] as T;
            }

            Debug.LogError($"currentState is not {typeof(T).Name}");
            return null;
        }
    }
}