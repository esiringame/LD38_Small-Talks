using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneryEngine : MonoBehaviour
{
    private FactoryBase[] _factories;
    private ScrollingManager _scrollingManager;

    public void Start()
    {
        _factories = GetComponents<FactoryBase>();
	    _scrollingManager = GetComponentInParent<ScrollingManager>();
    }

    public void Update()
    {
	    if (!_scrollingManager.enabled)
	        return;
        float trans = _scrollingManager.Speed * deltaTime;
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

