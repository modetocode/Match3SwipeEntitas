using Entitas;
using System;
using System.Collections.Generic;

public class UpdateTileSequenceSystem : ISetPool, IInitializeSystem, IReactiveSystem {

    private Pool pool;

    public TriggerOnEvent trigger {
        get { return Matcher.AllOf(Matcher.TileSelected, Matcher.Position).OnEntityAdded(); }
    }

    public void SetPool(Pool pool) {
        this.pool = pool;
    }

    public void Initialize() {
        this.pool.CreateTileSequence();
    }

    public void Execute(List<Entity> entities) {
        for (int i = 0; i < entities.Count; i++) {
            var currentTile = entities[i];
            var tileSequence = this.pool.tileSequence.sequence;
            this.ProcessNextTileForSelection(currentTile, tileSequence);
            currentTile.IsTileSelected(false);
            this.pool.ReplaceTileSequence(tileSequence);
        }
    }

    private void ProcessNextTileForSelection(Entity newTile, IList<Entity> tileSequence) {
        if (tileSequence.Count == 0) {
            this.AddTileToSequence(newTile, tileSequence);
            return;
        }

        if (tileSequence.Contains(newTile)) {
            this.ShortenSequence(newTile, tileSequence);
            return;
        }

        if (this.CanBeAddedToTheSequence(newTile, tileSequence)) {
            this.AddTileToSequence(newTile, tileSequence);
        }
    }

    private void AddTileToSequence(Entity newTile, IList<Entity> tileSequence) {
        tileSequence.Add(newTile);
    }

    private bool CanBeAddedToTheSequence(Entity newTile, IList<Entity> tileSequence) {
        var lastAddedTile = tileSequence[tileSequence.Count - 1];
        if (lastAddedTile.tile.tileType != newTile.tile.tileType) {
            return false;
        }

        var lastAddedTilePosition = lastAddedTile.position;
        var newTilePosition = newTile.position;
        int rowDifference = Math.Abs(lastAddedTilePosition.y - newTilePosition.y);
        int columnDifference = Math.Abs(lastAddedTilePosition.x - newTilePosition.x);
        return !(rowDifference > 1 || columnDifference > 1);
    }

    private void ShortenSequence(Entity newTile, IList<Entity> tileSequence) {
        int index = tileSequence.IndexOf(newTile);
        for (int i = tileSequence.Count - 1; i > index; i--) {
            tileSequence.RemoveAt(i);
        }
    }
}