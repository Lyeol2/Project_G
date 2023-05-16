using System.Collections.Generic;

namespace ProjectG
{
    // 현재 배틀 State
    public class BattleState : InGameState
    {
        bool turnPlaying = false;
        int turnCount = 1;

        UITurnPanel turnPanel;

        List<Character>[] enemyCharacters = new List<Character>[3];

        public override void Enter(InGameController target)
        {
            base.Enter(target);

            turnPanel = GameManager.GetManager<UIManager>().GetUIWindow<UITurnPanel>();
        }
        public override void Idle(InGameController target)
        {

            base.Idle(target);
            
            if (turnPlaying) return;

            var characters = target.playerCharacters;

            
        }

        public void PlayTurn()
        {

        }

        public override void Exit(InGameController target)
        {
            base.Exit(target);


        }

    }
}