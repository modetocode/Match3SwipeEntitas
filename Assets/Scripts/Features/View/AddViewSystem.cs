using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class AddViewSystem : IReactiveSystem, ISetPool {

    private Pool pool;
    private readonly Transform viewContainer = new GameObject("Views").transform;

    public TriggerOnEvent trigger {
        get { return Matcher.Resource.OnEntityAdded(); }
    }

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            Entity currentEntity = entities[i];

            var resourceTemplate = Resources.Load<GameObject>(currentEntity.resource.name);
            var newObject = UnityEngine.Object.Instantiate(resourceTemplate);
            newObject.transform.SetParent(viewContainer);
            newObject.Link(currentEntity, this.pool);
            currentEntity.AddView(newObject.GetComponent<ViewController>());
        }
    }
}