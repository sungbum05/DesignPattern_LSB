using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolData
{
    [Header("사전 등록 필요(입력용)")]
    public string Key;
    public GameObject PoolObj;
    public int MaxSpawnCount;
    public int BasicSpawnCount;

    [Header("사전 등록 불필요(체크용)")]
    public int CurSpawnCount;
    public int CurActiveCount;
    public int CurDeactiveCount;
    public Transform TrParantObj;
    public Transform TrActiveObj;
    public Transform TrDeactiveObj;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<ObjectPoolData> PoolDataList = new List<ObjectPoolData>();

    private static Dictionary<string, ObjectPoolData> PoolSpawnData = new Dictionary<string, ObjectPoolData>();
    private static Dictionary<string, QueueLSB<GameObject>> ObjPool = new Dictionary<string, QueueLSB<GameObject>>();

    private void Start()
    {
        Initialize();

        GetObj("Circle");
        GetObj("Circle");
        GetObj("Circle");
        GetObj("Circle");
        GetObj("Circle");
        GetObj("Circle");
    }

    private void Update()
    {
        Debug.Log(ObjPool["Circle"].Lentgh());
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

        QueueLSB<GameObject> SpawnObjPool = new QueueLSB<GameObject>(PoolSize);
        ObjPool.Add(Key, SpawnObjPool);

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
            ObjPool[Key].Push(NewObj);

            PoolSpawnData[Key].CurSpawnCount++;
            PoolSpawnData[Key].CurDeactiveCount++;
        }

        ParantNameSet(Key);
    }

    public GameObject GetObj(string Key)
    {
        GameObject Obj = null;

        if (ObjPool[Key].Lentgh() <= 0 && PoolSpawnData[Key].MaxSpawnCount > PoolSpawnData[Key].CurSpawnCount)
        {
            CreateNewObj(Key, 1);
        }

        if (ObjPool[Key].Lentgh() > 0)
        {
            Obj = ObjPool[Key].Pop();

            Obj.SetActive(true);
            Obj.transform.SetParent(PoolSpawnData[Key].TrActiveObj);

            PoolSpawnData[Key].CurActiveCount++;
            PoolSpawnData[Key].CurDeactiveCount--;
        }

        return Obj;
    }

    public static void ReturnObj(string Key, GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(PoolSpawnData[Key].TrDeactiveObj);
        ObjPool[Key].Push(Obj);

        PoolSpawnData[Key].CurActiveCount--;
        PoolSpawnData[Key].CurDeactiveCount++;
    }

    public static void ClearPool()
    {
        PoolSpawnData.Clear();
        ObjPool.Clear();
    }

    public void ParantNameSet(string Key)
    {
        PoolSpawnData[Key].TrParantObj.name = $"{Key} Parant: MaxSize[{PoolSpawnData[Key].MaxSpawnCount}], CurSpawn[{PoolSpawnData[Key].CurSpawnCount}]";
    }
}
