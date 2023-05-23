using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

namespace ProjectG
{
    
    // 현재 배틀정보를 담는편.
    public class TargetingState : InGameState
    {
        public UITurnSlot usableSlot { get; set; }

        public List<Effector> effectors = new List<Effector>();

        public Effector curEffector;

        public override void Enter(InGameController target)
        {
            base.Enter(target);

            Skill skill = usableSlot.skill;

            effectors = skill.effector;
            SetEffectTarget();

            target.OnSkillTargetSelect((ECampPos)curEffector.sdEffector.targetPosition);
        }

        public override void Idle(InGameController target)
        {
            base.Idle(target);

        }

        public override void Exit(InGameController target)
        {
            base.Exit(target);


        }
        private void SetEffectTarget()
        {
            curEffector = effectors[0];
            //target.charater    
        }
    }
}