using Entitas;
using System.Collections.Generic;

public class TileViewSystem : IReactiveSystem {

    public TriggerOnEvent trigger {
        get {
            return Matcher.Tile.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            Entity currentEntity = entities[i];
            var tileView = ViewInstantiator.InstantiateTile(currentEntity);
            currentEntity.AddView(tileView.gameObject);

            if (currentEntity.hasPosition) {
                var position = currentEntity.position;
                tileView.transform.position = new UnityEngine.Vector3(position.x, position.y, 0f);
            }
        }
    }
}