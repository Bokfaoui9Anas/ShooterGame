﻿using Controllers;

namespace Pattern
{
    public static class LocomotionFactory
    {
        public static IState Create(string name, PlayerContoller playerContoller)
        {
            switch (name)
            {
                case "Idle":
                    return new IdleState(playerContoller);
                case "Walk":
                    return new WalkState(playerContoller);
                case "Jump":
                    return new JumpState(playerContoller);
                case "Fall":
                default:
                    return null;
            }
        }
    }
}