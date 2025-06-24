using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : SpaceShip
{
    protected override void OnSpaceShipDestroy()
    {
        base.OnSpaceShipDestroy();

        SceneController.Instance.SetGameToDefeatState();
    }
}
