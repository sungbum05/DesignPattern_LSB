using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
{
    QueueLSB<T> Pool = new QueueLSB<T>(100);

    public void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            CreateNewObj();
        }
    }

    public void CreateNewObj()
    {
        Instantiate(T)
    }

    public T GetObj()
    {

    }

    public void ReturnObj(T Obj)
    {

    }
}
