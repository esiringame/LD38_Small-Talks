using UnityEngine;

public class PrefabFactory : FactoryBase
{
    public GameObject Prefab;

    public override GameObject Instantiate()
    {
        return Instantiate(Prefab);
    }
}