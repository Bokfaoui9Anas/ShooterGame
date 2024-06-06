using UnityEngine;

namespace Pattern
{
    public interface ILocomotionState : IState
    {
        void setAnimationState(Animator anime);
    }
}