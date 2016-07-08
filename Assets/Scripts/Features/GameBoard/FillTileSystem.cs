using Entitas;
using System.Collections.Generic;

public class FillTileSystem : IReactiveSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public TriggerOnEvent trigger {
        get { return Matcher.Tile.OnEntityRemoved(); }
    }

    public void Execute(List<Entity> entities) {
        var gameBoard = this.pool.gameBoard;
        for (int i = 0; i < gameBoard.rowCount; i++) {
            for (int j = 0; j < gameBoard.columnCount; j++) {
                if (gameBoard.grid[i][j] == null) {
                    this.pool.CreateRandomTile(i, j, gameBoard.possibleElements);
                }
            }
        }
    }
}
