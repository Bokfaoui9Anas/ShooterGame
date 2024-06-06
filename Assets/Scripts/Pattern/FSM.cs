namespace Pattern
{
    public abstract class Fsm
    {
        public abstract void Initialisation(IState state);
        public abstract void ChangeTo(IState NewState);
        public abstract void Update();
    }
}