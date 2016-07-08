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
        var grid = gameBoard.grid;
        for (int i = gameBoard.rowCount - 1; i >= 0; i--) {
            for (int j = 0; j < gameBoard.columnCount; j++) {
                bool hasTile = grid[i][j] != null;
                if (hasTile) {
                    continue;
                }

                var assignedTile = GetFirstAvailableUpperTile(gameBoard, i, j);
                if (assignedTile == null) {
                    assignedTile = this.pool.CreateRandomTile(i, j, gameBoard.possibleElements);
                }
                else {
                    grid[assignedTile.position.x][assignedTile.position.y] = null;
                    assignedTile.ReplacePosition(i, j);
                }

                grid[i][j] = assignedTile;
            }
        }
    }

    private Entity GetFirstAvailableUpperTile(GameBoardComponent gameBoard, int rowIndex, int columnIndex) {
        for (int i = rowIndex - 1; i >= 0; i--) {
            if (gameBoard.grid[i][columnIndex] != null) {
                return gameBoard.grid[i][columnIndex];
            }
        }

        return null;
    }
}
