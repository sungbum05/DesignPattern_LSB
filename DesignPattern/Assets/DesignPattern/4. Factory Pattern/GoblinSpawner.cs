using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : EnemySpawner
{
    public override void EnemySpawn()
    {
        Monster Mon =  new Goblin();
        Mon.Attack(Mon.AttackDamage);
    }
}
