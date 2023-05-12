using Utility.FSM;

namespace ProjectG
{
    public abstract class OutGameState : IState<OutGameController>
    {
        UIWindow window;
        public OutGameState(UIWindow window)
        {
            this.window = window;
        }
        public virtual void Enter(OutGameController target)
        {
            window.Show();
        }      
        public virtual void Idle(OutGameController target)
        {   

        }      
        public virtual void Exit(OutGameController target)
        {
            window.Hide();
        }
    }
}