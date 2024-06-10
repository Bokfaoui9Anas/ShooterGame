using Controllers;
using UnityEngine;

namespace Pattern
{
    public class Movement : IMovementBase
    {
        public void ExecuteMovement(PlayerContoller playerContoller, Vector3 direction)
        {
            direction = playerContoller.input.Value * playerContoller.speed * Time.deltaTime;
            playerContoller.transform.position += direction;
        }
    }
}