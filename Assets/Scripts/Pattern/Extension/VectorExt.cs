using UnityEngine;

namespace Pattern.Extension
{
    public static class VectorExt
    {
        public static Vector3 With(this Vector3 vector3, Axis axis, float value)
        {
            return new Vector3(
                axis == Axis.X ? value : vector3.x,
                axis == Axis.Y ? value : vector3.y,
                axis == Axis.Z ? value : vector3.z
            );
        }
    }
}