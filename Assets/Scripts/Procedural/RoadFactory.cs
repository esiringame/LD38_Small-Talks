using UnityEngine;

public class RoadFactory : FactoryScenery
{
    public GameObject[] Prefabs;

    public RoadFactory()
    {
    }

    protected override GameObject LocalInstantiate()
    {
        return Instantiate(Prefabs[Prefabs.Length-1]); // TODO index random modulo length
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
    }
}

