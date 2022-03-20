using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingService<T> : SingletonBehaviour<PoolingService<T>> where T : class
{
    List<PooledItem<T>> pooledObjects = new List<PooledItem<T>>();
    public T GetObject(){
        PooledItem<T> pooledItem = pooledObjects.Find(i => i.inUse == false);
        if( pooledItem != null ){
            pooledItem.inUse = true;
            return pooledItem.Item;
        }
        PooledItem<T> item = new PooledItem<T>();
        item.Item = CreateItem();
        item.inUse = true;
        pooledObjects.Add(item);
        Debug.Log("Length of Pooled Objects : "+pooledObjects.Count);
        return item.Item;
    }

    protected virtual T CreateItem(){
        return (T)null;
    }
    
    public virtual void ReturnObject(T returnedObject){
        PooledItem<T> pooledItem = pooledObjects.Find(item => item.Item.Equals(returnedObject));
        pooledItem.inUse = false;
    }
}

class PooledItem<T>{
    public T Item;
    public bool inUse;
}