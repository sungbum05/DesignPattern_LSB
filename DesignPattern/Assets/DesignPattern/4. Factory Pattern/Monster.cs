using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public int Hp;
    public int AttackDamage;

    public abstract void Attack(int Damage);

    public Monster(int _Hp, int _AttackDamage)
    {
        Hp = _Hp;
        AttackDamage = _AttackDamage;
    }
}
