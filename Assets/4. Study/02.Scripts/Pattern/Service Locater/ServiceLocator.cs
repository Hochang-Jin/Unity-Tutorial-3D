using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private Dictionary<Type, object> services = new Dictionary<Type, object>();

    public T GetService<T>() where T : class
    {
        if (services.TryGetValue(typeof(T), out object service))
        {
            return service as T;
        }
        return null;
    }

    public void RegisterService<T>(T service) where T : class
    {
        services[typeof(T)] = service;
    }

    public void UnregisterService<T>() where T : class
    {
        services.Remove(typeof(T));
    }
}
