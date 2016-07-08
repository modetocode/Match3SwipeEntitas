using Entitas;
using System.Collections.Generic;

public class RemoveViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.View, Matcher.Destroy).OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            currentEntity.view.controller.Despawn();
        }
    }
}