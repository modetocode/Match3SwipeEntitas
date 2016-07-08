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
        bool isValidSequence = sequence.Count > 2;
        if (isValidSequence) {
            for (int i = 0; i < sequence.Count; i++) {
                sequence[i].isDestroy = true;
            }
        }

        sequence.Clear();
        this.pool.ReplaceTileSequence(sequence);


    }
}
