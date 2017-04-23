using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralEngine : MonoBehaviour
{
    public PlayerBehaviour PlayerBehaviour;
    public float SpawnDelayMin = 0.5f;
    public float SpawnDelayMax = 3;

    private FactoryBase[] _factories;
    private float _spawnTimer;
    private float _spawnDelay;

    public void Start()
    {
        _factories = GetComponents<FactoryBase>();
        _spawnDelay = Random.Range(SpawnDelayMin, SpawnDelayMax);
    }

    public void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > _spawnDelay)
        {
            FactoryBase factory = GetRandomFactory();
            if (factory != null)
            {
                GameObject spawned = factory.Instantiate();
                spawned.transform.parent = factory.Root != null ? factory.Root.transform : gameObject.transform;

                RectTransform spawnZone = factory.SpawnZone;
                Rect rect = spawnZone.rect;
                spawned.transform.position = spawnZone.localToWorldMatrix * new Vector4(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax), 0, 1);

                _spawnTimer -= _spawnDelay;
                _spawnDelay = Random.Range(SpawnDelayMin, SpawnDelayMax);
            }
        }
    }

    private FactoryBase GetRandomFactory()
    {
        FactoryBase[] availableFactories = _factories.Where(f => f.IsAvailable && (PlayerBehaviour.GetState() != PlayerBehaviour.State.Talking || f is PedestrianFactory)).ToArray();
        if (availableFactories.Length == 0)
            return null;

        float probMax = availableFactories.Sum(x => x.ProbabilityWeight);
        float random = Random.Range(0, probMax);

        float probCumulate = probMax;
        foreach (FactoryBase factory in availableFactories)
        {
            probCumulate -= factory.ProbabilityWeight;

            if (probCumulate < random)
                return factory;
        }

        throw new InvalidOperationException();
    }
}
