using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private LevelRunCameraController cameraController;

    private Systems systems;

    void Start() {
        this.systems = this.CreateSystems(Pools.pool);
        this.systems.Initialize();
        this.cameraController.Initialize(Pools.pool.gameBoard);
    }

    void Update() {
        this.systems.Execute();
    }

    private Systems CreateSystems(Pool pool) {
        return new Feature("systems")
            .Add(pool.CreateSystem<ProcessInputSystem>())
            .Add(pool.CreateSystem<GameBoardSystem>())
            .Add(pool.CreateSystem<GameBoardElementViewSystem>())
            ;
    }
}