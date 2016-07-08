using Entitas;
using System;
using System.Collections.Generic;

public static class PoolExtensions {

    public static Entity CreateRandomTile(this Pool pool, int positionX, int positionY, IList<TileType> possibleTiles) {
        TileType type = possibleTiles[UnityEngine.Random.Range(0, possibleTiles.Count)];
        return pool.CreateEntity()
            .AddTile(type)
            .AddPosition(positionX, positionY)
            .AddResource(GetTileResourcePath(type));
    }

    public static Entity CreateTileSequence(this Pool pool) {
        return pool.CreateEntity().AddTileSequence(new List<Entity>()).AddResource(Constants.Resources.TileSequencePrefabName);
    }

    private static string GetTileResourcePath(TileType type) {
        switch (type) {
            case TileType.Amber:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.AmberTilePrefabName;
            case TileType.Emerald:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.EmeraldTilePrefabName;
            case TileType.Prism:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.PrismTilePrefabName;
            case TileType.Ruby:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.RubyTilePrefabName;
            case TileType.Sapphire:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.SapphireTilePrefabName;
        }

        throw new InvalidOperationException("type not supported");
    }
}