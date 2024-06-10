using Controllers;

namespace Pattern
{
    public class OrientationForward : IOrientation
    {
        public void ExecuteOrientaion(PlayerContoller playerContoller)
        {
            playerContoller.transform.LookAt(playerContoller.transform.position + playerContoller.input);
        }
    }
}