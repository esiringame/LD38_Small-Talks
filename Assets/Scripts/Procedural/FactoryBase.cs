using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    public int ProbabilityWeight = 1;
    public float SpawnDelayMin = 1;
    public RectTransform SpawnZone;
    private float _spawnTimer;

    public bool IsAvailable
    {
        get { return _spawnTimer >= SpawnDelayMin; }
    }

    public GameObject Instantiate()
    {
        _spawnTimer = 0;
        return LocalInstantiate();
    }

    protected abstract GameObject LocalInstantiate();

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
    }
}