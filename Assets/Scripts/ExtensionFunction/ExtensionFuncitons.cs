using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionFuncitons
{
    public static ScriptableObject selectRandom(this ScriptableObject[] scriptableObjects){
        return scriptableObjects[Random.Range(0, scriptableObjects.Length)];
    }

    public static T selectRandomArr<T>(this T[] array){
        return array[Random.Range(0, array.Length)];
    }

}
