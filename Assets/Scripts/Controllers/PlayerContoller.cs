using System;
using Pattern;
using Pattern.Extension;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerContoller : MonoBehaviour
    {
        [Header("State machine :")]
        [SerializeField] private ILocomotionState _state;
        [field: SerializeField] public Fsm Machine { get; private set; }
        
        
        
        
        [SerializeField] public Animator _anim;
        [SerializeField] public bool _isgrounded = true;
        [SerializeField] public Vector3Variable Input;
        [SerializeField] public float speed;
        [SerializeField] public Vector3Variable  playerVelocity;
        [field:NonSerialized] public Vector3 velocity;
        [field:SerializeField]  public float JumpHeight { get; private set; }

       private Rigidbody _rb;

        public Rigidbody Rb { get => _rb; set => _rb = value;}


        private void Start()
        {
            Rb = GetComponent<Rigidbody>();
            Machine = new LocomotionMachine();
            Machine.Initialisation(LocomotionFactory.Create("Idle", this));
        }

        private void Update()
        {
            Machine.Update();
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isgrounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isgrounded = false;
            }
        }
        


        // public void Landing(PlayerContoller playerContoller)
        // {
        //
        //     velocity = Vector3.zero;
        //     velocity.y += gravity * Time.deltaTime;
        //     if (playerContoller._isgrounded && velocity.y < 0.2f) velocity.y = -1;
        //     playerVelocity.Value = velocity;
        //
        //     playerContoller.CharacterController.Move(playerVelocity.Value);
        // }

      
    }
    
}