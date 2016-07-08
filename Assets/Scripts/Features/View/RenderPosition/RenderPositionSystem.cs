using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.View, Matcher.Position).OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        int rowCount = this.pool.gameBoard.rowCount;
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            Vector3 endPosition = new Vector3(currentEntity.position.y, rowCount - currentEntity.position.x - 1, 0f);
            currentEntity.view.controller.position = endPosition + Vector3.up;
            currentEntity.view.controller.Move(endPosition, 0.3f);
        }
    }

}
