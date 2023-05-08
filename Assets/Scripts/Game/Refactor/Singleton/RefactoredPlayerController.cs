using System.Security.Cryptography;
using UnityEngine;
public class RefactoredPlayerController : PlayerControllerBase
{
    public static RefactoredPlayerController Instance;

    Rigidbody selectedBullet;

    [SerializeField]
    private PoolBase bulletLowPool;

    [SerializeField]
    private PoolBase bulletMidPool;

    [SerializeField]
    private PoolBase bulletHardPool;

    protected override bool NoSelectedBullet => selectedBullet == null;

    private int selectBullet;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private RefactoredPlayerController()
    {

    }

   

    protected override void Shoot()
    {
        ICommand storedCommand2 = new ShootCommand(shootForce, NoSelectedBullet, selectBullet, bulletLowPool, bulletMidPool, bulletHardPool, spawnPos);
        storedCommand2.Execute();
    }

    protected override void SelectBullet(int index)
    {
        selectBullet = index;
        selectedBullet = bulletPrefabs[GameUtils.GetClampedValue(index, bulletPrefabs.Length)];
        ICommand storedCommand = new SwitchToWeaponCommand(index);
        storedCommand.Execute();
    }

    public void OnScoreChangedEvent(int scoreAdd)
    {
        UpdateScore(scoreAdd);
    }

}