using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneryEngine : MonoBehaviour
{
    private FactoryScenery[] _factories;
    private ScrollingManager _scrollingManager;

    public void Start()
    {
        _factories = GetComponents<FactoryScenery>();
	    _scrollingManager = GetComponentInParent<ScrollingManager>();

        foreach(FactoryScenery f in _factories) 
        {
            Spawn(f);
        }
    }

    public void Update()
    {
	    if (!_scrollingManager.enabled)
	        return;
        float trans = _scrollingManager.Speed * Time.deltaTime;
    }

    private void Spawn(FactoryScenery f)
    {
        GameObject spawned = f.Instantiate();
        spawned.transform.parent = gameObject.transform;

        RectTransform spawnZone = f.SpawnZone;
        Rect rect = spawnZone.rect;
        spawned.transform.position = spawnZone.localToWorldMatrix * new Vector4(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax), 0, 1);
    }
}

