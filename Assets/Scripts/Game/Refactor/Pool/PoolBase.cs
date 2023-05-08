using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour, IPool
{
    [SerializeField]
    private int count = 5;

    [SerializeField]
    private GameObject basePrefab;

    private Queue<GameObject> instances = new Queue<GameObject>();

    public Queue<GameObject> Instances { get => instances; set => instances = value; }

    private ObstacleBase currentObstacle;
    private void Start()
    {
        foreach (var intances in Instances)
        {
            intances.GetComponent<PoolableObject>().onObjectToRecycle += RecycleInstance;
        }
    }
    public void RecycleInstance(GameObject instance)
    {
        instances.Enqueue(instance);
        instance.SetActive(false);
        instance.GetComponent<Rigidbody>().isKinematic = true;
        instance.transform.SetParent(gameObject.transform);

        if (instance.GetComponent<RefactoredObstacle>()) 
        {
            if (instance.GetComponent<RefactoredObstacleLow>() != null)
            {
                currentObstacle = instance.GetComponent<ObstacleBase>();
                currentObstacle.RemainingHP = currentObstacle.Hp;
            }
            else if (instance.GetComponent<RefactoredObstacleMid>() != null)
            {
                currentObstacle = instance.GetComponent<ObstacleBase>();
                currentObstacle.RemainingHP = currentObstacle.Hp;
            }
            else if (instance.GetComponent<RefactoredObstacleHard>() != null)
            {
                currentObstacle = instance.GetComponent<ObstacleBase>();
                currentObstacle.RemainingHP = currentObstacle.Hp;
            }
        }
        instance.transform.position = gameObject.transform.position;
    }
    
    public GameObject RetrieveInstance()
    {
        var poolObject = instances.Dequeue();
        poolObject.SetActive(true);

        poolObject.GetComponent<Rigidbody>().isKinematic = false;
        poolObject.transform.SetParent(null);
        return poolObject;
    }

    protected void PopulatePool()
    {
        for (int i = 0; i < count; i++)
        {
            var instance = (Instantiate(basePrefab, transform.position, Quaternion.identity, gameObject.transform));
            RecycleInstance(instance);
        }
    }
}