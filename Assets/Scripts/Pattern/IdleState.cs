using Controllers;
using Pattern.Extension;
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
            setAnimationState(_playerContoller._anim);
        }

        public void Update()
        {
            if (_playerContoller.Input != Vector3.zero)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
            if (Input.GetKey(KeyCode.Space) && _playerContoller._isgrounded)
            {
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump", _playerContoller));
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

        #region chara seq

        /*public void Update()
      {
          setAnimationState(_playerContoller._anim);
          _playerContoller.Landing(_playerContoller);
          var up = _playerContoller.playerVelocity.Value.y +Mathf.Sqrt(_playerContoller.JumpHeight * -2f * _playerContoller.Gravity);

          
          if (_playerContoller.Input != Vector3.zero)
              _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
          if (Input.GetKey(KeyCode.Space) && _playerContoller._isgrounded)
          {
           //   _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump",_playerContoller));
           // _playerContoller.playerVelocity.Value =
           //     _playerContoller.playerVelocity.Value.With(Axis.Y, _playerContoller.JumpHeight) ;
           _playerContoller.playerVelocity.Value = _playerContoller.playerVelocity.Value.With(Axis.Y,
               up);


          }
          var dir = _playerContoller.playerVelocity.Value ;
          _playerContoller.CharacterController.Move(dir * Time.deltaTime);
      }*/


        #endregion
    }
}