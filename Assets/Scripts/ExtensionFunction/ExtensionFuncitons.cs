using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionFuncitons
{
    public static ScriptableObject selectRandom(this ScriptableObject[] scriptableObjects){
        return scriptableObjects[Random.Range(0, scriptableObjects.Length)];
    }
}
