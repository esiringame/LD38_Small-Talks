using System.Collections.Generic;
using UnityEngine;

public class PedestrianDescriptor
{
    public int CharacterId;
    public int EncounterCounter;
    public bool KnowPlayer { get { return CharacterId != 0; } }
}

public class PedestrianFactory : FactoryBase
{
    public int GenericCount = 20;
    public GameObject GenericPrefabs;
    public GameObject[] CharacterPrefabs;
    private List<PedestrianDescriptor> _inventory;

    public PedestrianFactory()
    {
        SpawnDelayMin = 0.5f;
    }

    private void Start()
    {
        _inventory = new List<PedestrianDescriptor>();
        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            _inventory.Add(new PedestrianDescriptor
            {
                CharacterId = i + 1,
                EncounterCounter = 0
            });
        }

        for (int i = 0; i < GenericCount; i++)
            _inventory.Add(new PedestrianDescriptor
            {
                CharacterId = 0
            });
    }

    protected override GameObject LocalInstantiate()
    {
        int randomId = Random.Range(0, _inventory.Count);
        PedestrianDescriptor descriptor = _inventory[randomId];
        GameObject obj = Instantiate(descriptor.CharacterId != 0 ? CharacterPrefabs[descriptor.CharacterId - 1] : GenericPrefabs);
        obj.GetComponent<NPCBehaviour>().Descriptor = descriptor;
        return obj;
    }

    protected override void OnObjectDestroy(GameObject obj)
    {
        _inventory.Add(obj.GetComponent<NPCBehaviour>().Descriptor);
    }
}
