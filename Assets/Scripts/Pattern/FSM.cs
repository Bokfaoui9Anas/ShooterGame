using Controllers;

namespace Pattern
{
    public abstract class Fsm
    {
        protected abstract void Initialisation(PlayerContoller playerContoller);
        protected abstract void ChangeTo(PlayerContoller playerContoller);
        protected abstract void Update(PlayerContoller playerContoller);
    }
}
