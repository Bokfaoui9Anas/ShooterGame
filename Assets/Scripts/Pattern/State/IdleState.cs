using Controllers;
using UnityEngine;

namespace Pattern
{
    public class IdleState : ILocomotionState
    {
        private static readonly int Loco = Animator.StringToHash("loco");
        private readonly PlayerContoller _playerContoller;

        public IdleState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
           
            _playerContoller.State = PlayerContoller.PlayerState.Idle;
            setAnimationState(_playerContoller._anim);
        }

        public void Update()
        {
            if (_playerContoller.input != Vector3.zero)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
            if (Input.GetKey(KeyCode.Space) && _playerContoller.isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump", _playerContoller));
        }


        public void Exit()
        {
           
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat(Loco, _playerContoller.input.Value.magnitude);
        }
    }
}