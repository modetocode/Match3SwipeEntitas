using Entitas;
using System.Collections.Generic;

public class GameBoardElementViewSystem : IReactiveSystem {

    public TriggerOnEvent trigger {
        get {
            return Matcher.GameBoardElement.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            Entity currentEntity = entities[i];
            var newGameObject = ViewInstantiator.InstantiateGameBoardElement(currentEntity.gameBoardElement.gameBoardElementType);
            currentEntity.AddView(newGameObject);

            if (currentEntity.hasPosition) {
                var position = currentEntity.position;
                newGameObject.transform.position = new UnityEngine.Vector3(position.x, position.y, 0f);
            }
        }
    }
}