using UnityEngine;

public class RefactoredUIManager : UIManagerBase
{
    public static RefactoredUIManager Instance;
    protected override PlayerControllerBase PlayerController => RefactoredPlayerController.Instance;
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    private RefactoredUIManager() { }
}