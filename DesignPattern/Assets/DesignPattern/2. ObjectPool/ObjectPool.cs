using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PoolEnum
{
    Option1,
    Option2,
    Option3
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    public PoolEnum poolEnum;

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

    //public T GetObj()
    //{

    //}

    //public void ReturnObj(T Obj)
    //{

    //}
}

[CustomEditor(typeof(ObjectPool))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ObjectPool myScript = (ObjectPool)target;

        // Enum ������ ������ �� �ִ� ��Ӵٿ� ����� �����մϴ�.
        myScript.poolEnum = (PoolEnum)EditorGUILayout.EnumPopup("My Enum Variable", myScript.poolEnum);

        serializedObject.ApplyModifiedProperties();
    }
}
