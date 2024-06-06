using System;
using Pattern;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerContoller : MonoBehaviour
    {
        [SerializeField] public Animator _anim;
        [SerializeField] public bool _isgrounded = true;
        [SerializeField] private ILocomotionState _state;
        [SerializeField] public Vector3Variable Input;
        [SerializeField] public float speed;

       [field:NonSerialized] public Vector3 velocity;
        [field: SerializeField] public Fsm Machine { get; private set; }

        public CharacterController CharacterController { get; set; }
        [SerializeField]  public float jumpHeight = 5f;
        

        private void Start()
        {
            CharacterController = GetComponent<CharacterController>();
            Machine = new LocomotionMachine();
            Machine.Initialisation(LocomotionFactory.Create("Idle", this));
        }

        private void Update()
        {
            _isgrounded = CharacterController.isGrounded;
            Machine.Update();
        }

        public float gravity = -9.81f;
        public void Landing(PlayerContoller playerContoller)
        {
            
            velocity = Vector3.zero;
            velocity.y += gravity * Time.deltaTime;
            if (playerContoller._isgrounded && velocity.y < 0.2f) velocity.y = -1;

            playerContoller.CharacterController.Move(velocity);
        }

      
    }
}