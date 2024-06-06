using Controllers;
using TMPro;
using UnityEngine;

namespace Pattern
{
    public class IdleState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;

        public IdleState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
            setAnimationState(_playerContoller._anim);
        }

        public void Update()
        {
            _playerContoller.Landing(_playerContoller);
            if (_playerContoller.Input!= Vector3.zero )
            {
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
            }

           
        }

        public void Exit()
        {
            Debug.Log("idle exit");
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat("loco",0);
        }
    }
}