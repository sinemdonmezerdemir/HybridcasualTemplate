using UnityEngine;

/// <summary>
/// Singleton class
/// </summary>
/// <typeparam name="T">Type of the SingletonMonoBehaviour</typeparam>
public abstract class SingletonMonoBehaviourAutoCreated<T> : MonoBehaviour
    where T : SingletonMonoBehaviourAutoCreated<T>
{
    /// <summary>
    /// The static reference to the instance
    /// </summary>
    private static T _instance;

    /// <summary>
    /// Awake method to associate singleton with instance
    /// </summary>
    private static object _lockObject = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        var go = new GameObject(typeof(T).Name + " (AutoCreated)");
                        go.AddComponent<T>();
                        
                        _instance = go.GetComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// OnDestroy method to clear singleton association
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }
}