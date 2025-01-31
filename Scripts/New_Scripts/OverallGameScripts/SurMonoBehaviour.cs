using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }    

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        //ForOveride
    }
    
    protected virtual void Start()
    {
        
    }    
    protected virtual void ResetValue()
    {

    }

    protected virtual void OnEnable()
    {
        this.ResetValue();
    }

    protected virtual void OnDisable()
    {
       
    }
}

public class Singleton<T> : SurMonoBehaviour where T : SurMonoBehaviour
{
    public static T Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}