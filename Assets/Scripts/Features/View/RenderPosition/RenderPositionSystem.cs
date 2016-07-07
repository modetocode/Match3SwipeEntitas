using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem {

    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.View, Matcher.Position).OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            currentEntity.view.controller.position = new Vector3(currentEntity.position.x, currentEntity.position.y, 0f);
        }
    }
}
