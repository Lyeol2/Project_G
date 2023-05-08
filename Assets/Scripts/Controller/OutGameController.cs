using System.Collections.Generic;
using UnityEngine;

namespace ProjectG
{
    public enum OutGameStateType
    {
        Main,
        Party,
        Pickup,
        Encycolopedia,
        Option,
    }
    /// <summary>
    /// 파티구성이나 캐릭터 뽑기같은 게임 외부의 씬
    /// </summary>
    public class OutGameController : Controller
    {
        UIManager uiMgr;

        UIMenuSelector uiMenuSelector;

        Dictionary<OutGameStateType, OutGameState> cachedState = new Dictionary<OutGameStateType, OutGameState>();

        OutGameState currentState;

        public override void InitController()
        {
            base.InitController();

            uiMgr = GameManager.GetManager<UIManager>();

            cachedState.Add(OutGameStateType.Main, new MainState(uiMgr.GetUIWindow<UIMainPanel>()));
            cachedState.Add(OutGameStateType.Party, new PartyState(uiMgr.GetUIWindow<UIPartyPanel>()));
            cachedState.Add(OutGameStateType.Pickup, new PickupState(uiMgr.GetUIWindow<UIPickupPanel>()));
            cachedState.Add(OutGameStateType.Encycolopedia, new EncycolopediaState(uiMgr.GetUIWindow<UIEncycolopediaPanel>()));

            ChangeState(OutGameStateType.Main);

            uiMenuSelector = uiMgr.GetUIWindow<UIMenuSelector>();
            uiMenuSelector.BindingButton(this);

        }


        public void ChangeState(OutGameStateType type)
        {
            currentState?.Exit(this);

            currentState = cachedState[type];

            currentState?.Enter(this);
        }

        public T GetState<T>() where T : OutGameState
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