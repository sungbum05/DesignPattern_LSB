using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : EnemySpawner
{
    public override void EnemySpawn()
    {
        Monster Mon = new Slime();
        Mon.Attack(Mon.AttackDamage);
    }
}
