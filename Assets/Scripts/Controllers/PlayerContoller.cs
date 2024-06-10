using System;
using Pattern;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerContoller : MonoBehaviour
    {
        [SerializeField] public Animator _anim;


        [SerializeField] public Vector3Variable input;

        [SerializeField] public bool isgrounded = true;
        [SerializeField] public Vector3Variable playerVelocity;
        [SerializeField] public float speed;

        [Header("State machine :")] [SerializeField]
        private ILocomotionState state;

        [field: NonSerialized] private Vector3 velocity;
        [field: SerializeField] public Fsm Machine { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        public Rigidbody Rb { get; set; }

        public IMovementBase MovementBase { get; set; } = new Movement();

        public IOrientation Orientation { get; set; } = new OrientationForward();

    public enum PlayerState
    {
        Idle,Jump,Walk
    }

    public PlayerState State ;
        


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
            if (other.gameObject.CompareTag("Ground")) isgrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground")) isgrounded = false;
        }
    }
}