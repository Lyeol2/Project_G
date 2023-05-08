using System.Collections.Generic;
using UnityEngine;

namespace ProjectG
{
    public enum InGameStateType
    {
        Main,
        Party,
        Pickup,
        Encycolopedia,
        Option,
    }
    /// <summary>
    /// 전투씬
    /// </summary>
    public class InGameController : Controller
    {
        // ------------- Characters -------------------

        // 0~3 : 메인캐릭터 / 4 서브캐릭터
        [SerializeField]
        public Character[] playerCharacters = new Character[5];





        Dictionary<InGameStateType, InGameState> cachedState = new Dictionary<InGameStateType, InGameState>();

        InGameState currentState;

        public override void InitController()
        {
            base.InitController();

        }


        public void ChangeState(InGameStateType type)
        {
            currentState?.Exit(this);

            currentState = cachedState[type];

            currentState?.Enter(this);
        }

        public T GetState<T>() where T : InGameState
        {
            if (currentState is T)
            {
                return currentState as T;
            }

            Debug.LogError($"currentState is not {typeof(T).Name}");
            return null;
        }
    }
}