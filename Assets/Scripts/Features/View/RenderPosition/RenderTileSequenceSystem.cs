using Entitas;
using System.Collections.Generic;

public class RenderTileSequenceSystem : IReactiveSystem, ISetPool, IInitializeSystem {

    private Pool pool;
    private TileSequenceViewController tileSequenceView;
    private Entity tileSequence;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public TriggerOnEvent trigger {
        get {
            return Matcher.TileSequence.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities) {
        if (this.tileSequenceView == null) {
            this.tileSequenceView = (TileSequenceViewController)tileSequence.view.controller;
        }

        tileSequenceView.DrawSequence(entities.SingleEntity().tileSequence.sequence);
    }

    public void Initialize() {
        this.tileSequence = this.pool.GetEntities(Matcher.TileSequence).SingleEntity();
    }
}

