using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ProjectG
{
    public enum EInGameStateType
    {
        Move,
        Battle,
    }
    public enum ECampPos
    {
        Front,
        Middle,
        Back,
    }
    /// <summary>
    /// 전투씬
    /// </summary>
    public class InGameController : Controller
    {
        // ------------- Characters -------------------

        public Character subCharacter;


        // 전열 중열 후열
        [SerializeField]
        public List<Character>[] playerCharacters = new List<Character>[3];



        Dictionary<EInGameStateType, InGameState> cachedState = new Dictionary<EInGameStateType, InGameState>();

        EInGameStateType currentState;

        public override void InitController()
        {
            base.InitController();

            cachedState.Add(EInGameStateType.Move, new BattleState());
            cachedState.Add(EInGameStateType.Battle, new BattleState());

            // -------- TODO SAMPLE -------------

            var character = new Character();
            AddCharacter(ECampPos.Front, )

            ChangeState(EInGameStateType.Battle);
        }

        private void OnGUI()
        {

            var style = new GUIStyle(GUI.skin.button);
            style.fontSize = 70;

            if (GUILayout.Button("Skip", style))
            {
                GetState<BattleState>().PlayTurn();
            }
        }
        private void AddCharacter(ECampPos pos, Character character)
        {
            playerCharacters[(int)pos].Add(character);
        }
        public void ChangeState(EInGameStateType type)
        {

            cachedState[currentState]?.Exit(this);

            currentState = type;

            cachedState[currentState]?.Enter(this);
        }

        public T GetState<T>() where T : InGameState
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