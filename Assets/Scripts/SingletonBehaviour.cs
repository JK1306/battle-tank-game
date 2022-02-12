using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    private static T instance;
    public static T Instance { 
        get{
            return instance;
        }
    }
    protected virtual void Awake() {
        if(instance == null){
            DontDestroyOnLoad(this);
            instance = (T)this;
        }else{
            Destroy(this);
        }
    }
}
