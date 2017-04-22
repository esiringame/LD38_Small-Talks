using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    public int ProbabilityWeight = 1;
    public float SpawnDelayMin = 1;
    public RectTransform Bounds;
    public RectTransform SpawnZone;
    private float _spawnTimer;
    private readonly List<GameObject> _spawnedObjects = new List<GameObject>();
    private readonly List<GameObject> _aliveObjects = new List<GameObject>();

    public bool IsAvailable
    {
        get { return _spawnTimer >= SpawnDelayMin; }
    }

    public void Start()
    {
        Bounds = GetComponent<RectTransform>();
    }

    public void Update()
    {
        _spawnTimer += Time.deltaTime;
        
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

    public GameObject Instantiate()
    {
        GameObject spawned = LocalInstantiate();
        _spawnedObjects.Add(spawned);
        _spawnTimer = 0;
        return spawned;
    }

    protected abstract GameObject LocalInstantiate();
}