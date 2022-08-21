using UnityEngine;

namespace FlorisDeVToolsUnityExtensions.Extensions
{
    public static class TransformExtensions
    {
        public static void DisableRenderersRecursive(this Transform parent)
        {
            if (parent.TryGetComponent<Renderer>(out var objRenderer))
            {
                objRenderer.enabled = false;
            }

            foreach (Transform child in parent)
            {
                DisableRenderersRecursive(child);
            }
        }
    }
}