using Controllers;
using DG.Tweening;
using Pattern.Extension;
using UnityEngine;
using UnityEngine.Windows.Speech;

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

        Vector3 _move = Vector3.zero;
        public void Update()
        {
            setAnimationState(_playerContoller._anim);
             _move = _playerContoller.Input.Value * _playerContoller.speed * Time.deltaTime;
             _playerContoller.transform.position += _move;
             _playerContoller.transform.LookAt(_playerContoller.transform.position + _playerContoller.Input);
            if (_playerContoller.Input == Vector3.zero && _playerContoller._isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
            if (Input.GetKey(KeyCode.Space) && _playerContoller._isgrounded)
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

        #region Charach seq
        /*public void Update()
              {
                  setAnimationState(_playerContoller._anim);
                  var up = _playerContoller.playerVelocity.Value.y + (_playerContoller.Gravity *  _playerContoller.JumpHeight); 
      
                  var move = _playerContoller.Input.Value  * _playerContoller.speed;
                 var dir = _playerContoller.playerVelocity.Value + move * Time.deltaTime;
                  _playerContoller.CharacterController.Move(dir);
                  _playerContoller.transform.LookAt(_playerContoller.transform.position + _playerContoller.Input);
                  _playerContoller.Landing(_playerContoller);
                  ////Change State
                  if (_playerContoller.Input == Vector3.zero && _playerContoller._isgrounded)
                      _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
                  if (Input.GetKey(KeyCode.Space) && _playerContoller._isgrounded)
                  {
                     // _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump",_playerContoller));
                     _playerContoller.playerVelocity.Value =
                         _playerContoller.playerVelocity.Value.With(Axis.Y,up) * Time.deltaTime;
                  }
              }*/

        

        #endregion
    }
    
    
}