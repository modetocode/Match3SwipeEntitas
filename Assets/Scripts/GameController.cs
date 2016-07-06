using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private LevelRunCameraController cameraController;

    [SerializeField]
    private InputController inputController;

    private Systems systems;

    private bool TouchInProgress { get; set; }
    private bool GameInProgress { get; set; }
    private Pool Pool { get { return Pools.pool; } }

    void Start() {
        this.StartGame();
    }

    void Update() {
        this.systems.Execute();
    }

    private void StartGame() {
        this.InitializeSystems();
        this.GameInProgress = true;
        this.SubscribeForInputEvents();
    }

    private void InitializeSystems() {
        this.systems = this.CreateSystems(this.Pool);
        this.systems.Initialize();
        this.cameraController.Initialize(this.Pool.gameBoard);
    }

    private Systems CreateSystems(Pool pool) {
        return new Feature("systems")
            .Add(pool.CreateSystem<ProcessInputSystem>())
            .Add(pool.CreateSystem<GameBoardSystem>())
            .Add(pool.CreateSystem<TileViewSystem>())
            ;
    }

    private void SubscribeForInputEvents() {
        this.inputController.TouchStarted += StartTouch;
        this.inputController.TouchEnded += EndTouch;
        this.inputController.TouchHit += OnTouchHit;
    }

    private void UnsubscribeFromInputEvents() {
        this.inputController.TouchStarted -= StartTouch;
        this.inputController.TouchEnded -= EndTouch;
        this.inputController.TouchHit -= OnTouchHit;
    }

    private void StartTouch() {
        this.TouchInProgress = true;
        this.Pool.CreateEntity().IsTileSequence(true);
    }

    private void EndTouch() {
        this.TouchInProgress = false;
        //TODO finish this
        //this.LevelRunManager.FinishSelection();
    }

    private void OnTouchHit(GameObject gameObject) {
        if (!this.TouchInProgress) {
            return;
        }

        TileView tileView = gameObject.GetComponent<TileView>();
        if (tileView == null) {
            return;
        }

        Debug.Log("new element: " + tileView.Tile.position.x + tileView.Tile.position.y);
        //this.LevelRunManager.ProcessTileForSelection(tileComponent.Tile);
    }
}