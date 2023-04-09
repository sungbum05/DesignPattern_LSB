using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    StackLSB<int> Stack = new StackLSB<int>(10);
    QueueLSB<int> QueueLSB = new QueueLSB<int>(10);

    // Start is called before the first frame update
    void Start()
    {
        TestQueue();
    }

    public void TestStack()
    {

    }

    public void TestQueue()
    {
        QueueLSB.Push(0);
        QueueLSB.Push(1);
        QueueLSB.Push(2);

        QueueLSB.Size();

        Debug.Log($"POP: {QueueLSB.Pop()}");
        Debug.Log($"POP: {QueueLSB.Pop()}");
        Debug.Log($"POP: {QueueLSB.Pop()}");

        QueueLSB.Size();
    }
}
