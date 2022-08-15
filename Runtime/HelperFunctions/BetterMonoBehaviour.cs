using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FlorisDeVToolsUnityExtensions.HelperFunctions
{
    /// <summary>
    /// Overwrite of monobehaviour, to ensure execution order of object initialization
    /// </summary>
    public abstract class BetterMonoBehaviour : MonoBehaviour
    {
        public bool IsPaused { get; protected set; } = false;

        protected virtual void Awake()
        {
            StartCoroutine(SetupBetterMonoBehaviour());
        }

        private IEnumerator SetupBetterMonoBehaviour()
        {
            // Wait a frame so every Awake/Start/OnEnable method is called
            yield return new WaitForEndOfFrame();
            InitReferences();

            yield return new WaitForEndOfFrame();
            InitListeners();

            yield return new WaitForEndOfFrame();
            InitInvokers();
        }

        /// <summary>
        /// Used to initialize all references
        /// </summary>
        protected virtual void InitReferences()
        {
        }

        /// <summary>
        /// Used to initialize all listeners
        /// </summary>
        protected virtual void InitListeners()
        {
        }

        /// <summary>
        /// Used to setup internal state, which impacts other classes.
        /// i.e. Invokes of events
        /// </summary>
        protected virtual void InitInvokers()
        {
        }

        protected virtual void OnDisable()
        {
            transform.DORewind();
            transform.DOKill();
        }

        protected virtual void OnGameStateChanged()
        {
        }
    }
}