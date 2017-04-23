using UnityEngine;
using Random = UnityEngine.Random;

public class RoadFactory : FactoryScenery
{
    public GameObject[] Prefabs;

    public RoadFactory()
    {
    }

    protected override GameObject LocalInstantiate()
    {
        return Instantiate(Prefabs[Random.Range(0,Prefabs.Length)]); // TODO index random modulo length
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
    }
}

