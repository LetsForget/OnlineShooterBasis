using UnityEngine;

namespace Utils
{
    public static class Vector2Extension
    {
        public static Vector3 ToVector3InHorizontal(this Vector2 vector2) => new(vector2.x, 0, vector2.y);
    }
}