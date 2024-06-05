using Controllers;

namespace Pattern
{
    public abstract class Fsm
    {
        protected abstract void Initialisation(IState state);
        protected abstract void ChangeTo(IState NewState);
        protected abstract void Update();
    }
}
