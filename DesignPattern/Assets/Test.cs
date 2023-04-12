using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : Singleton<Test>
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

        Debug.Log(QueueLSB.Lentgh());

        Debug.Log($"POP: {QueueLSB.Pop()}");
        Debug.Log($"POP: {QueueLSB.Pop()}");
        Debug.Log($"POP: {QueueLSB.Pop()}");

        Debug.Log(QueueLSB.Lentgh());
    }
}
