using UnityEditor;
using Utility.FSM;

namespace ProjectG
{
    public abstract class InGameState : IState<InGameController>
    {
        InGameController target;

        public InGameState()
        {

        }
        public virtual void Enter(InGameController target)
        {
            this.target = target;


        }      
        public virtual void Idle(InGameController target)
        {   
            
        }      
        public virtual void Exit(InGameController target)
        {

        }

    }
}