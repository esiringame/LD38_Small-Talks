using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public abstract class FactoryScenery : MonoBehaviour
{
    public RectTransform LifeZone;
    public RectTransform SpawnZone;

    private readonly List<GameObject> _spawnedObjects = new List<GameObject>();
    private readonly List<GameObject> _aliveObjects = new List<GameObject>();

    public ReadOnlyCollection<GameObject> AliveObjects { get; private set; }

    public float LastTileSize { get; private set;}
    public float ScrollSize { get; set;}

    protected FactoryScenery()
    {
        AliveObjects = _aliveObjects.AsReadOnly();
    }

    public void Update()
    {
        GameObject[] toAlive = _spawnedObjects.Where(obj => GameObjectIntersectRect(obj, LifeZone.rect)).ToArray();
        foreach (GameObject o in toAlive)
        {
            _spawnedObjects.Remove(o);
            _aliveObjects.Add(o);
        }

        GameObject[] toDestroy = _aliveObjects.Where(obj => !GameObjectIntersectRect(obj, LifeZone.rect)).ToArray();
        foreach (GameObject o in toDestroy)
        {
            _aliveObjects.Remove(o);
            OnObjectDestroy(o);
            Destroy(o);
        }
    }

    static private bool GameObjectIntersectRect(GameObject gameObject, Rect rect)
    {
        Bounds bounds = gameObject.GetComponent<Renderer>().bounds;
        return bounds.size == Vector3.zero ? rect.Contains(gameObject.transform.position) : rect.Overlaps(new Rect(bounds.min, bounds.size));
    }

    public GameObject Instantiate()
    {
        GameObject spawned = LocalInstantiate();
        _spawnedObjects.Add(spawned);

        LastTileSize = spawned.GetComponent<SpriteRenderer>().bounds.size.x;
        return spawned;
    }

    protected abstract GameObject LocalInstantiate();
    protected abstract void OnObjectDestroy(GameObject obj);
}

