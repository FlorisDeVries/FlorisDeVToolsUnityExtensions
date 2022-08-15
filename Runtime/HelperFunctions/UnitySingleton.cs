using UnityEngine;

namespace FlorisDeVToolsUnityExtensions.HelperFunctions
{
    [ExecuteInEditMode]
    public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;
        [SerializeField] private bool _persistent = false;
        
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<T>();
                
                if (_instance != null) return _instance;
                
                var singletonObject = new GameObject(typeof(T).ToString());
                _instance = singletonObject.AddComponent<T>();
                return _instance;
            }
        }

        public static bool TryGetInstance(out T instance)
        {
            instance = _instance;
            return _instance != null;
        }

        protected void Awake()
        {
            if(!Application.isPlaying) return;
            
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = GetComponent<T>();

            if (_persistent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}