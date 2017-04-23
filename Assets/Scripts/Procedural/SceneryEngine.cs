using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneryEngine : MonoBehaviour
{
    private FactoryScenery[] _factories;
    private ScrollingManager _scrollingManager;

    private float trans = 0f;

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
        trans += _scrollingManager.Speed * Time.deltaTime;
        if (trans > .24f) {
            Spawn(_factories[0], trans - .24f);
            trans -= .24f;
        }
    }

    private void Spawn(FactoryScenery f, float offset = .0f)
    {
        GameObject spawned = f.Instantiate();
        spawned.transform.parent = gameObject.transform;

        RectTransform spawnZone = f.SpawnZone;
        Rect rect = spawnZone.rect;
        spawned.transform.position = spawnZone.localToWorldMatrix * new Vector4(Random.Range(rect.xMin, rect.xMax) - offset, Random.Range(rect.yMin, rect.yMax), 0, 1);

        Debug.Log("Size: " + spawned.GetComponent<SpriteRenderer>().bounds.size.x);
    }
}

