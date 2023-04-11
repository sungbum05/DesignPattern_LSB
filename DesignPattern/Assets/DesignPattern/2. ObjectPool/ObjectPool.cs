using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    QueueLSB<GameObject> Pool = new QueueLSB<GameObject>(100);

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
