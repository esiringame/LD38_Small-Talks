using UnityEngine;

public class PedestrianFactory : FactoryBase
{
    public GameObject[] Prefabs;

    public PedestrianFactory()
    {
        SpawnDelayMin = 0.5f;
    }

    protected override GameObject LocalInstantiate()
    {
        return Instantiate(Prefabs[0]);
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
    }
}