using System.Collections.Generic;
using UnityEngine.Playables;

namespace ProjectG
{




    // 현재 배틀 State
    public class BattleState : InGameState
    {
        bool turnPlaying = false;
        int turnCount = 1;

        UITurnPanel turnPanel;
        


        public override void Enter(InGameController target)
        {
            base.Enter(target);

            turnPanel = GameManager.GetManager<UIManager>().GetUIWindow<UITurnPanel>();
        }
        public override void Idle(InGameController target)
        {

            base.Idle(target);


        }


        public override void Exit(InGameController target)
        {
            base.Exit(target);


        }

    }
}