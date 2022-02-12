using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    private static T instance=null;
    public static T Instance {
        get{ return instance; }
    }

    private void Awake() {
        if(instance == null){
            instance = (T)this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(this);
        }
    }
}
