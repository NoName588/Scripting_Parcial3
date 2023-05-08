using UnityEngine;

public interface IPool
{
    public GameObject RetrieveInstance();
    
    public void RecycleInstance(GameObject instance);
}