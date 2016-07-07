using Entitas;
using System;

public static class PoolExtensions {

    public static Entity CreateTile(this Pool pool, int positionX, int positionY, TileType type) {
        return pool.CreateEntity()
            .AddTile(type)
            .AddPosition(positionX, positionY)
            .AddResource(GetTileResourcePath(type));
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