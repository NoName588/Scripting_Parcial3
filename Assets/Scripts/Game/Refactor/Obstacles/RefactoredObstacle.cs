public abstract class RefactoredObstacle : ObstacleBase
{
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    protected override void DestroyObstacle(bool notify = false)
    {
        if (notify)
        {
            GameController?.SendMessage("OnObstacleDestroyed", HP);
            GetComponent<PoolableObject>().RecycleObject();
        }
        else
        {
            GetComponent<PoolableObject>().RecycleObject();
        }
    }
}