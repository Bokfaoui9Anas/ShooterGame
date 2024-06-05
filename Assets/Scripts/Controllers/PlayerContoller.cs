using Pattern;
using UnityEngine;

namespace Controllers
{
    public class PlayerContoller : MonoBehaviour
    {
        [SerializeField] private ILocomotionState _state;
        [field: SerializeField] public Fsm Machine { get; private set; }


        void Start()
        {

            Machine = new LocomotionMachine();
            Machine.Initialisation(new IdleState(this));
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
