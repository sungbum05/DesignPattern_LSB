using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class QueueLSB<T>
{
    const int Bottom = -1;

    public T[] Array;
    public int CurFloor = -1;

    public QueueLSB(int Size)
    {
        Array = new T[Size];
    }

    public void Push(T Value)
    {
        Array[++CurFloor] = Value;
    }

    public T Pop()
    {
        if (CurFloor == Bottom)
        {
            return default(T);
        }

        T ReturnValue = Array[Bottom + 1];
        for (int i = 0; i < CurFloor; i++)
        {
            Array[i] = Array[i + 1];
        }

        CurFloor--;
        return ReturnValue;
    }

    public void Front()
    {
        if (CurFloor == Bottom)
        {
            Debug.Log($"{-1}\n");
            return;
        }

        Debug.Log($"{Array[Bottom + 1]}\n");
    }
    public void Back()
    {
        if (CurFloor == Bottom)
        {
            Debug.Log($"{-1}\n");
            return;
        }

        Debug.Log($"{Array[CurFloor]}\n");
    }

    public void Empty()
    {
        Debug.Log($"IsEmpty: {(CurFloor < 0 ? "True" : "False")}\n");
    }

    public void Size()
    {
        Debug.Log($"{CurFloor + 1}\n");
    }
}
