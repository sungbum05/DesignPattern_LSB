using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public Slime() : base(10, 10)
    {
        Debug.Log("Spawn Slime");
    }

    public override void Attack(int Damage)
    {
        Debug.Log($"Slime AttackDamage: {AttackDamage}");
    }
}
