using Entitas;
using System.Collections.Generic;

public class ProcessObjectSelectedInputSystem : IReactiveSystem, ISetPool {

    private Pool pool;

    public TriggerOnEvent trigger {
        get { return Matcher.ObjectSelectedInput.OnEntityAdded(); }
    }

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentEntity = entities[i];
            var selectedGameObject = currentEntity.objectSelectedInput.gameObject;

            if (!selectedGameObject.CompareTag(Constants.Tags.TileTag)) {
                continue;
            }

            var tileEntity = selectedGameObject.GetEntityLink().Entity;
            tileEntity.IsTileSelected(true);
            this.pool.DestroyEntity(currentEntity);
        }


    }
}