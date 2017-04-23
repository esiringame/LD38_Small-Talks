using UnityEngine;

public class RoadFactory : FactoryBase
{
    public GameObject[] Prefabs;

    public RoadFactory()
    {
    }

    protected override GameObject LocalInstantiate()
    {
        return Instantiate(Prefabs[Prefabs.Length]); // TODO index random modulo length
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
    }
}

