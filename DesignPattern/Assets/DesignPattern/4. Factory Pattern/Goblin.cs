using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    public Goblin() : base(20, 20)
    {
        Debug.Log("Spawn Goblin");
    }

    public override void Attack(int Damage)
    {
        Debug.Log($"Goblin AttackDamage: {AttackDamage}");
    }
}
