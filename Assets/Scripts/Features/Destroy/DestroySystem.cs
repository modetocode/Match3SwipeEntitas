using Entitas;
using System.Collections.Generic;

public class DestroySystem : IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.Destroy.OnEntityAdded(); } }

    Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            pool.DestroyEntity(entities[i]);
        }
    }
}
