using Entitas;
using System.Collections.Generic;

public class GameBoardSystem : IInitializeSystem, IReactiveSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Initialize() {
        IList<TileType> possibleElementTypes = new List<TileType> {
            TileType.Amber, TileType.Emerald, TileType.Prism, TileType.Ruby, TileType.Sapphire };
        int rowCount = 5;
        int columnCount = 5;
        var grid = new Entity[rowCount][];
        for (int i = 0; i < rowCount; i++) {
            grid[i] = new Entity[columnCount];

        }

        var gameBoard = this.pool.CreateEntity().AddGameBoard(rowCount, columnCount, possibleElementTypes, grid).gameBoard;
        this.FillGameBoard(gameBoard);
    }

    private void FillGameBoard(GameBoardComponent gameBoard) {
        for (int i = 0; i < gameBoard.rowCount; i++) {
            for (int j = 0; j < gameBoard.columnCount; j++) {
                this.pool.CreateRandomTile(i, j, gameBoard.possibleElements);
            }
        }
    }

    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.Tile, Matcher.Position).OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            int rowIndex = currentEntity.position.x;
            int columnIndex = currentEntity.position.y;
            this.pool.gameBoard.grid[rowIndex][columnIndex] = currentEntity;
            currentEntity.OnComponentRemoved += OnTileComponentRemoved;
        }
    }

    private void OnTileComponentRemoved(Entity entity, int index, IComponent component) {
        PositionComponent position = component as PositionComponent;
        if (position == null) {
            return;
        }

        int rowIndex = position.x;
        int columnIndex = position.y;
        this.pool.gameBoard.grid[rowIndex][columnIndex] = null;
        entity.OnComponentRemoved -= OnTileComponentRemoved;
    }
}