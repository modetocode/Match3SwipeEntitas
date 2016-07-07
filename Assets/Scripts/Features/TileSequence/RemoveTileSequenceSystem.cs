using Entitas;
using System.Collections.Generic;

public class RemoveTileSequenceSystem : ISetPool, IReactiveSystem {

    private Pool pool;

    public TriggerOnEvent trigger {
        get { return Matcher.TouchInProgress.OnEntityRemoved(); }
    }

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Execute(List<Entity> entities) {
        var sequence = pool.tileSequence.sequence;
        for (int i = 0; i < sequence.Count; i++) {
            sequence[i].isDestroy = true;
        }

        pool.tileSequence.sequence.Clear();
    }
}
