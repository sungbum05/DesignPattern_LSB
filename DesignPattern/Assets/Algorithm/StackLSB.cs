using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackLSB<T> : MonoBehaviour
{
    public int Count = 0;
    public T[] Array;

    // 배열 사이즈 확립
    public StackLSB(int Size)
    {
        Array = new T[Size];
    }

    public void Push (T Value)
    {
        Array[Count++] = Value;
    }

    public T Pop()
    {
        if(Count > 0)
        {
            return Array[--Count];
        }

        else
        {
            return default(T);
        }
    }

    public int Lentgh()
    {
        return Count;
    }

    public void Empty()
    {
        Debug.Log($"IsEmpty: {(Count > 0 ? "False" : "True")}");
    }

    public void PrintStack()
    {
        for (int i = 0; i < Count; i++)
        {
            Debug.Log(Array[i]);
        }
    }
}
