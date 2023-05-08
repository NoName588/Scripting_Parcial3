using UnityEngine;

public class RefactoredObstacleSpawner : ObstacleSpawnerBase
{
    public static RefactoredObstacleSpawner Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField]
    private PoolBase obstacleLowPool;

    [SerializeField]
    private PoolBase obstacleMidPool;

    [SerializeField]
    private PoolBase obstacleHardPool;
    GameObject obstacleObject;
    protected int ObjectIndex
    {
        get
        {
            int result = Random.Range(0,3);
            return result;
        }
    }

    protected override void SpawnObject()
    {
        var ramdonIndex = ObjectIndex;

        if (ramdonIndex == 0)
        {
            if (obstacleLowPool.Instances.Count == 0) return;
            obstacleObject = obstacleLowPool.RetrieveInstance();
        }
        if (ramdonIndex == 1)
        {
            if (obstacleMidPool.Instances.Count == 0) return;
            obstacleObject = obstacleMidPool.RetrieveInstance();
        }
        if (ramdonIndex == 2)
        {
            if (obstacleHardPool.Instances.Count == 0) return;
            obstacleObject = obstacleHardPool.RetrieveInstance();
        }

        obstacleObject.transform.position = new Vector3(Random.Range(MinX, MaxX), YPos, 0);
    }
}