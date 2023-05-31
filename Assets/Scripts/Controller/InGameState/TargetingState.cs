using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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

            Highlight();
        }
        public void Highlight()
        {
            GameManager.GetController<InGameController>().characterPool.SetLocalScale();

            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
            RaycastHit2D hit = Physics2D.Raycast(dir, Vector2.zero, 10, 1 << LayerMask.NameToLayer("Character"));

            

            if (hit.collider)   
            {
                hit.collider.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            }
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