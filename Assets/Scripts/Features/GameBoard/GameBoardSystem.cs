using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardSystem : IInitializeSystem, IReactiveSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Initialize() {
        IList<TileType> possibleElementTypes = new List<TileType> {
            TileType.Amber, TileType.Emerald, TileType.Prism, TileType.Ruby, TileType.Sapphire };
        var gameBoard = this.pool.CreateEntity().AddGameBoard(5, 5, possibleElementTypes).gameBoard;
        for (int i = 0; i < gameBoard.rowCount; i++) {
            for (int j = 0; j < gameBoard.columnCount; j++) {
                TileType type = gameBoard.possibleElements[Random.Range(0, gameBoard.possibleElements.Count)];
                this.pool.CreateTile(i, j, type);
            }
        }
    }

    public TriggerOnEvent trigger {
        get {
            return Matcher.GameBoard.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities) {
        var gameBoard = entities.SingleEntity().gameBoard;
    }
}