using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{
    [Header("사전 등록 필요(입력용)")]
    [SerializeField]
    private GameObject BoxBulletObj;
    [SerializeField]
    private GameObject CircleBulletObj;
    [SerializeField]
    private GameObject CapsuleBulletObj;

    [Header("사전 등록 불필요(체크용)")]
    [SerializeField]
    private GameObject CurBullet;
    private IWeapon CurWeapon;

    public void ChangeBoxBullet()
    {
        CurWeapon = new BoxBullet() as IWeapon;
        CurBullet = BoxBulletObj;
    }

    public void ChangeCircleBullet()
    {
        CurWeapon = new CircleBullet() as IWeapon;
        CurBullet = CircleBulletObj;
    }

    public void ChangeCapsuleBullet()
    {
        CurWeapon = new CapsuleBullet() as IWeapon;
        CurBullet = CapsuleBulletObj;
    }

    public void Attack()
    {
        CurWeapon.Attack(CurBullet);
    }
}
