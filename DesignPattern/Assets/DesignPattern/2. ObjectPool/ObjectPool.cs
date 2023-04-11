using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Dictionary<string, QueueLSB<GameObject>> ActiveTrueMultiplePool = new Dictionary<string, QueueLSB<GameObject>>();
    Dictionary<string, QueueLSB<GameObject>> ActiveFalseMultiplePool = new Dictionary<string, QueueLSB<GameObject>>();

    public void NewCategory(string Name, int PoolSize)
    {
        QueueLSB<GameObject> Pool = new QueueLSB<GameObject>(PoolSize);


    }

    public void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            CreateNewObj();
        }
    }

    public void CreateNewObj()
    {

    }

    public GameObject GetObj()
    {
        return default(GameObject);
    }

    public void ReturnObj(GameObject Obj)
    {

    }
}
