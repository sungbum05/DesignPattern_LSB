using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObj : MonoBehaviour
{
    public string Key;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        ObjectPool.ReturnObj(Key, this.gameObject);
    }
}
