using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    public int ProbabilityWeight = 1;
    public abstract GameObject Instantiate();
}