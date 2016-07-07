using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.View, Matcher.Destroy).OnEntityAdded(); }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            var currentView = currentEntity.view.controller.gameObject;
            currentView.Unlink();
            entities[i].RemoveView();
            Object.Destroy(currentView);
        }
    }
}