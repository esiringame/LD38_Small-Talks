using UnityEngine;

public class PrefabFactory : FactoryBase
{
    public GameObject Prefab;

    protected override GameObject LocalInstantiate()
    {
        return Instantiate(Prefab);
    }
}