using Controllers;
using UnityEngine;

namespace Pattern
{
    public class IdleState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;
        private static readonly int Loco = Animator.StringToHash("loco");

        public IdleState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
            Debug.Log("idle enter");
        }

        public void Update()
        {
            setAnimationState(_playerContoller._anim);
            _playerContoller.Landing(_playerContoller);
            if (_playerContoller.Input != Vector3.zero)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
            if (Input.GetKeyDown(KeyCode.Space) && _playerContoller._isgrounded)
            {
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump",_playerContoller));
            }
          
        }

        public void Exit()
        {
            Debug.Log("idle exit");
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat(Loco, _playerContoller.Input.Value.magnitude);
        }
    }
}