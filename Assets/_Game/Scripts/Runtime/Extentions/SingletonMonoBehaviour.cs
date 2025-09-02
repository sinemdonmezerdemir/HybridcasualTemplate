﻿using UnityEngine;

namespace Runtime.Extensions
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        /// <summary>
        /// The static reference to the instance
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();

                return _instance;
            }
        }
        static T _instance;

        protected virtual void Awake()
        {
            if (Instance && Instance != this)
                Destroy(this.gameObject);
        }
    }
}