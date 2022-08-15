using UnityEngine;

namespace FlorisDeVToolsUnityExtensions.Extensions
{
    public static class VectorExtensions
    {
        /// <summary>
        /// Performs a CW rotation of n degrees
        /// </summary>
        /// <param name="v"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            var sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            var cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            var tx = v.x;
            var ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}