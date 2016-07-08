using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private LevelRunCameraController cameraController;

    [SerializeField]
    private InputController inputController;

    private Systems systems;
    private Pool Pool { get { return Pools.pool; } }

    void Start() {
        this.StartGame();
    }

    void FixedUpdate() {
        this.systems.Execute();
    }

    private void StartGame() {
        this.InitializeSystems();
    }

    private void InitializeSystems() {
        this.systems = this.CreateSystems(this.Pool);
        this.systems.Initialize();
        this.cameraController.Initialize(this.Pool.gameBoard);
    }

    private Systems CreateSystems(Pool pool) {
        return new Feature("systems")
            //Init
            .Add(pool.CreateSystem<IncrementTickSystem>())
            .Add(pool.CreateSystem<GameBoardSystem>())

            //Update
            .Add(pool.CreateSystem<FillTileSystem>())
            .Add(pool.CreateSystem<UpdateTileSequenceSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())
            .Add(pool.CreateSystem<ProcessObjectSelectedInputSystem>())
            .Add(pool.CreateSystem<RenderTileSequenceSystem>())

            //Destroy
            .Add(pool.CreateSystem<RemoveTileSequenceSystem>())
            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<DestroySystem>())
            ;
    }
}