﻿using System.Collections.Generic;

namespace ProjectG
{
    // 현재 배틀정보를 담는편.
    public class BattleState : InGameState
    {
        bool turnPlaying = false;
        int turnCount = 1;


        List<Character>[] enemyCharacters = new List<Character>[3];



        public override void Enter(InGameController target)
        {
            base.Enter(target);

            



        }
        public override void Idle(InGameController target)
        {
            base.Idle(target);

            // 턴이 작동중이라면 바로 빠꾸~
            if (turnPlaying) return;

            var characters = target.playerCharacters;


        }

        public void SkipTurn()
        {

        }

        public override void Exit(InGameController target)
        {
            base.Exit(target);


        }

    }
}