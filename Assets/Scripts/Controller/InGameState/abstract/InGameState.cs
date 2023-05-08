using Utility.FSM;

namespace ProjectG
{
    public abstract class InGameState : IState<InGameController>
    {
        public InGameState()
        {
        }
        public virtual void Enter(InGameController target)
        {
        }      
        public virtual void Idle(InGameController target)
        {      
        }      
        public virtual void Exit(InGameController target)
        {
        }

    }
}