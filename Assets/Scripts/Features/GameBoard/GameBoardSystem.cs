using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardSystem : IInitializeSystem, IReactiveSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Initialize() {
        IList<GameBoardElementType> possibleElementTypes = new List<GameBoardElementType> {
            GameBoardElementType.Amber, GameBoardElementType.Emerald, GameBoardElementType.Prism, GameBoardElementType.Ruby, GameBoardElementType.Sapphire };
        var gameBoard = this.pool.CreateEntity().AddGameBoard(5, 5, possibleElementTypes).gameBoard;
        for (int i = 0; i < gameBoard.rowCount; i++) {
            for (int j = 0; j < gameBoard.columnCount; j++) {
                GameBoardElementType type = gameBoard.possibleElements[Random.Range(0, gameBoard.possibleElements.Count)];
                CreateGameBoardComponent(i, j, type);
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

    private Entity CreateGameBoardComponent(int positionX, int positionY, GameBoardElementType type) {
        return this.pool.CreateEntity()
            .AddGameBoardElement(type)
            .AddPosition(positionX, positionY);
    }
}