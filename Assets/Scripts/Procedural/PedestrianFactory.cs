﻿using System;
using UnityEngine;

public class PedestrianFactory : FactoryBase
{
    public override GameObject Instantiate()
    {
        var pedestrian = new GameObject();
        pedestrian.AddComponent<SpriteRenderer>();
        pedestrian.AddComponent<Scrollable>();
        return pedestrian;
    }
}