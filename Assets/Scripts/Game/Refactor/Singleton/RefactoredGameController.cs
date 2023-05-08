using UnityEngine;

public sealed class RefactoredGameController : GameControllerBase
{
    public static RefactoredGameController Instance;

    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;

    protected override UIManagerBase UiManager => RefactoredUIManager.Instance;

    protected override ObstacleSpawnerBase Spawner => RefactoredObstacleSpawner.Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private RefactoredGameController() { }
    protected override void OnScoreChanged(int hp)
    {
        PlayerController?.SendMessage("OnScoreChangedEvent", hp);
        UiManager?.SendMessage("UpdateScoreLabel");
    }

    protected override void SetGameOver()
    {
        UiManager?.SendMessage("OnGameOver");
        PlayerController?.SendMessage("OnGameOver");
        Spawner?.SendMessage("OnGameOver");
        base.SetGameOver();
    }
}