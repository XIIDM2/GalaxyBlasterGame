using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : SpaceShip
{
    [SerializeField] private int addedScore = 1;
    protected override void OnSpaceShipDestroy()
    {
        base.OnSpaceShipDestroy();
        Managers.DataController.AddScore(addedScore);
    }
}
