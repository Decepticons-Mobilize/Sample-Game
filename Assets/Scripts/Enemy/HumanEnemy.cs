using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class HumanEnemy : Enemy
{
    public HumanEnemy() : base(100)
    {
    }
    public override void Shoot()
    {
        Destroy(gameObject);
    }



}
