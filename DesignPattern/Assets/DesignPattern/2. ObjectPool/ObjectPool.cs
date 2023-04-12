using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolData
{
    public string Key;
    public GameObject PoolObj;
    public int MaxSpawnCount;
    public int BasicSpawnCount;
    public int CurSpawnCount;
    public int CurActiveCount;

    public Transform TrParantObj;
    public Transform TrActiveObj;
    public Transform TrDeactiveObj;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<ObjectPoolData> PoolDataList = new List<ObjectPoolData>();

    private Dictionary<string, ObjectPoolData> PoolSpawnData = new Dictionary<string, ObjectPoolData>();
    private Dictionary<string, QueueLSB<GameObject>> ActiveMultiplePool = new Dictionary<string, QueueLSB<GameObject>>();
    private Dictionary<string, QueueLSB<GameObject>> DeactiveMultiplePool = new Dictionary<string, QueueLSB<GameObject>>();

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < PoolDataList.Count; i++)
        {
            PoolSpawnData.Add(PoolDataList[i].Key, PoolDataList[i]);

            NewCategory(PoolDataList[i].Key, PoolDataList[i].MaxSpawnCount);
            CreateNewObj(PoolDataList[i].Key, PoolDataList[i].BasicSpawnCount);
        }
    }

    public void NewCategory(string Key, int PoolSize)
    {
        // 오브젝트 풀 딕셔너리 추가
        QueueLSB<GameObject> ActivePool = new QueueLSB<GameObject>(PoolSize);
        QueueLSB<GameObject> DeactivePool = new QueueLSB<GameObject>(PoolSize);
        ActiveMultiplePool.Add(Key, ActivePool);
        DeactiveMultiplePool.Add(Key, DeactivePool);

        #region 오브젝트 스폰 장소
        //오브젝트 스폰 장소 소환
        GameObject Parant = new GameObject($"{Key} Parant: MaxSize[{PoolSize}], CurSpawn[{0}]");
        Parant.transform.SetParent(transform);
        PoolSpawnData[Key].TrParantObj = Parant.transform;

        GameObject DeactiveObj = new GameObject("Deactive");
        DeactiveObj.transform.SetParent(Parant.transform);
        PoolSpawnData[Key].TrDeactiveObj = DeactiveObj.transform;

        GameObject ActiveObj = new GameObject("Active");
        ActiveObj.transform.SetParent(Parant.transform);
        PoolSpawnData[Key].TrActiveObj = ActiveObj.transform;
        #endregion
    }

    public void CreateNewObj(string Key, int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject NewObj = Instantiate(PoolSpawnData[Key].PoolObj);

            NewObj.SetActive(false);
            NewObj.transform.SetParent(PoolSpawnData[Key].TrDeactiveObj);
            DeactiveMultiplePool[Key].Push(NewObj);

            PoolSpawnData[Key].CurSpawnCount++;
        }

        ParantNameSet(Key);
    }

    public GameObject GetObj()
    {
        return default(GameObject);
    }

    public void ReturnObj(GameObject Obj)
    {

    }

    public void ParantNameSet(string Key)
    {
        PoolSpawnData[Key].TrParantObj.name = $"{Key} Parant: MaxSize[{PoolSpawnData[Key].MaxSpawnCount}], CurSpawn[{PoolSpawnData[Key].CurSpawnCount}]";
    }
}
