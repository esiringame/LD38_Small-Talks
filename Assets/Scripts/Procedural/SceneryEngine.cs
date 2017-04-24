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
        _factories = GetComponents<FactoryScenery>().Where(x => x.enabled).ToArray();
	    _scrollingManager = GetComponentInParent<ScrollingManager>();

        foreach(FactoryScenery f in _factories) 
        {
            float zone  = f.LifeZone.rect.xMin + f.LifeZone.transform.position.x;
            float spawn = f.SpawnZone.transform.position.x;
            float offset = spawn - zone;
            while (offset > 0f) 
            {
                Spawn(f, offset);
                offset -= f.LastTileSize;
            }
            f.ScrollSize = f.LastTileSize + offset;
        }
    }

    public void Update()
    {
	    if (!_scrollingManager.enabled)
	        return;

        float deltaScrollSize = _scrollingManager.Speed * Time.deltaTime;
        foreach(FactoryScenery f in _factories) 
            UpdateSF(f, deltaScrollSize);
    }

    private void UpdateSF(FactoryScenery f, float deltaScrollSize) 
    {
        f.ScrollSize += deltaScrollSize;
        if (f.ScrollSize > f.LastTileSize) {
            Spawn(f, f.ScrollSize - f.LastTileSize);
            f.ScrollSize -= f.LastTileSize;
        }
    }

    private void Spawn(FactoryScenery f, float offset = .0f)
    {
        GameObject spawned = f.Instantiate();
        if (spawned == null)
            return;
        spawned.transform.parent = gameObject.transform;

        RectTransform spawnZone = f.SpawnZone;
        Rect rect = spawnZone.rect;
        spawned.transform.position = spawnZone.localToWorldMatrix * new Vector4(Random.Range(rect.xMin, rect.xMax) - offset, Random.Range(rect.yMin, rect.yMax), 0, 1);
    }
}

