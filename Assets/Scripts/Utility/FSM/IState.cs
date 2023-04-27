using System.Threading;

namespace Utility.FSM
{
    public interface IState<T>
    {
        public void Enter(T target);
        public void Idle(T target);
        public void Exit(T target);
    }
}
