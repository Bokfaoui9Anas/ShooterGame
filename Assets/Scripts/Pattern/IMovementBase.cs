using Controllers;
using UnityEngine;

namespace Pattern
{
    public interface IMovementBase
    {
        void ExecuteMovement(PlayerContoller playerContoller, Vector3 direction);
    }
}