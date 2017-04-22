using System;
using UnityEngine;

public class PedestrianFactory : FactoryBase
{
    public PedestrianFactory()
    {
        SpawnDelayMin = 0.5f;
    }

    protected override GameObject LocalInstantiate()
    {
        var pedestrian = new GameObject();
        pedestrian.AddComponent<SpriteRenderer>();
        pedestrian.AddComponent<Scrollable>();
        return pedestrian;
    }
}