using UnityEngine;

public class ShootCommand : ICommand
{
    float shootForce;
    bool NoSelectedBullet;
    int selectBullet;
     
    PoolBase bulletLowPool;
    PoolBase bulletMidPool;
    PoolBase bulletHardPool;

    GameObject currentBulletPrefab;
    Transform spawnPos;

    public ShootCommand(float shootForce, bool noSelectedBullet, int selectBullet, PoolBase bulletLowPool, PoolBase bulletMidPool, PoolBase bulletHardPool, Transform spawnPos)
    {
        NoSelectedBullet = noSelectedBullet;
        this.shootForce = shootForce;
        this.selectBullet = selectBullet;
        this.bulletLowPool = bulletLowPool;
        this.bulletMidPool = bulletMidPool;
        this.bulletHardPool = bulletHardPool;
        this.spawnPos = spawnPos;
    }

    public void Execute()
    {
        if (NoSelectedBullet) return;

        if (selectBullet == 0)
        {
            if (bulletLowPool.Instances.Count == 0) return;
            currentBulletPrefab = bulletLowPool.RetrieveInstance();
        }

        if (selectBullet == 1)
        {
            if (bulletMidPool.Instances.Count == 0) return;
            currentBulletPrefab = bulletMidPool.RetrieveInstance();
        }

        if (selectBullet == 2)
        {
            if (bulletHardPool.Instances.Count == 0) return;
            currentBulletPrefab = bulletHardPool.RetrieveInstance();
        }

        currentBulletPrefab.transform.position = spawnPos.position;

        currentBulletPrefab.GetComponent<Rigidbody>().AddForce(currentBulletPrefab.transform.up * shootForce, ForceMode.Force);
    }
}