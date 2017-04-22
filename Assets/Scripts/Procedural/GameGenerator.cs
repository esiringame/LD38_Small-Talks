using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameGenerator : MonoBehaviour
{
    public float SpawnDelayMin = 0.5f;
    public float SpawnDelayMax = 3;
    public RectTransform Bounds;

    private FactoryBase[] _factories;
    private float _spawnTimer;
    private float _spawnDelay;
    private readonly List<GameObject> _spawnedObjects = new List<GameObject>();
    private readonly List<GameObject> _aliveObjects = new List<GameObject>();

    public void Start()
    {
        Bounds = GetComponent<RectTransform>();
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
                spawned.transform.parent = gameObject.transform;

                RectTransform spawnZone = factory.SpawnZone;
                Rect rect = spawnZone.rect;
                spawned.transform.position = spawnZone.localToWorldMatrix * new Vector4(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax), 0, 1);

                _spawnedObjects.Add(spawned);

                _spawnTimer -= _spawnDelay;
                _spawnDelay = Random.Range(SpawnDelayMin, SpawnDelayMax);
            }
        }

        GameObject[] toAlive = _spawnedObjects.Where(obj => GameObjectIntersectRect(obj, Bounds.rect)).ToArray();
        foreach (GameObject o in toAlive)
        {
            _spawnedObjects.Remove(o);
            _aliveObjects.Add(o);
        }

        GameObject[] toDestroy = _aliveObjects.Where(obj => !GameObjectIntersectRect(obj, Bounds.rect)).ToArray();
        foreach (GameObject o in toDestroy)
        {
            _aliveObjects.Remove(o);
            Destroy(o);
        }
    }

    static private bool GameObjectIntersectRect(GameObject gameObject, Rect rect)
    {
        Bounds bounds = gameObject.GetComponent<Renderer>().bounds;
        return bounds.size == Vector3.zero ? rect.Contains(gameObject.transform.position) : rect.Overlaps(new Rect(bounds.min, bounds.size));
    }

    private FactoryBase GetRandomFactory()
    {
        FactoryBase[] availableFactories = _factories.Where(f => f.IsAvailable).ToArray();
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
