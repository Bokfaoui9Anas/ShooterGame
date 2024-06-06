using Controllers;
using UnityEngine;

namespace Pattern
{
    public class WalkState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;

        public WalkState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
           setAnimationState(_playerContoller._anim);
        }

        public void Update()
        {

            var move = _playerContoller.Input.Value * Time.deltaTime * _playerContoller.speed;
            _playerContoller.CharacterController.Move(move);
            _playerContoller.transform.LookAt(_playerContoller.transform.position + _playerContoller.Input);
            _playerContoller.Landing(_playerContoller);
            if(_playerContoller.Input == Vector3.zero && _playerContoller._isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
        }

        public void Exit()
        {
            Debug.Log("Walk exit");
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat("loco",1);
        }
    }
}