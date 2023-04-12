using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Attack(GameObject BulletPrefab);
}

public class BoxBullet : MonoBehaviour,IWeapon
{
    public void Attack(GameObject BulletPrefab)
    {
        Debug.Log("Attack BoxBullet");
        GameObject Bullet = Instantiate(BulletPrefab);

        Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 25, ForceMode2D.Impulse);
    }
}

public class CircleBullet : MonoBehaviour, IWeapon
{
    public void Attack(GameObject BulletPrefab)
    {
        Debug.Log("Attack CircleBullet");
        GameObject Bullet = Instantiate(BulletPrefab);

        Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 25, ForceMode2D.Impulse);
    }
}

public class CapsuleBullet : MonoBehaviour, IWeapon
{
    public void Attack(GameObject BulletPrefab)
    {
        Debug.Log("Attack CapsuleBullet");
        GameObject Bullet = Instantiate(BulletPrefab);

        Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 25, ForceMode2D.Impulse);
    }
}

