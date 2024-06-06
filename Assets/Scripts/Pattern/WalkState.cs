using Controllers;
using UnityEngine;

namespace Pattern
{
    public class WalkState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;
        private static readonly int Loco = Animator.StringToHash("loco");

        public WalkState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        { Debug.Log("Walk enter");
        }

        public void Update()
        {
            setAnimationState(_playerContoller._anim);

            var move = _playerContoller.Input.Value * Time.deltaTime * _playerContoller.speed;
            _playerContoller.CharacterController.Move(move);
            _playerContoller.transform.LookAt(_playerContoller.transform.position + _playerContoller.Input);
            _playerContoller.Landing(_playerContoller);
            ////Change State
            if (_playerContoller.Input == Vector3.zero && _playerContoller._isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
            if (Input.GetKeyDown(KeyCode.Space) && _playerContoller._isgrounded)
            {
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump",_playerContoller));
            }
        }

        public void Exit()
        {
            Debug.Log("Walk exit");
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat(Loco, _playerContoller.Input.Value.magnitude);
        }
    }
}