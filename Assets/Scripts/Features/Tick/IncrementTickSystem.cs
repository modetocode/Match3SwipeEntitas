using Entitas;

/// <summary>
/// Responsible for counting the number of ticks that has passed since the system was started.
/// </summary>
public class IncrementTickSystem : IInitializeSystem, IExecuteSystem, ISetPool {

    private Pool pool;

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Initialize() {
        this.pool.SetTick(0);
    }

    public void Execute() {
        this.pool.ReplaceTick(this.pool.tick.value + 1);
    }
}
