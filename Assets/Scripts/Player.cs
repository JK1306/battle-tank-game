using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public void display(){
        Debug.Log("Hello World");
    }
}
