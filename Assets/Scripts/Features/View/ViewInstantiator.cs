using Entitas;
using System;
using UnityEngine;

public static class ViewInstantiator {

    private static readonly Transform viewContainer = new GameObject("Views").transform;

    public static TileView InstantiateTile(Entity tileEntity) {
        if (!tileEntity.hasTile) {
            throw new InvalidOperationException("entity should have tile component");
        }

        var tile = tileEntity.tile;
        var type = tile.tileType;
        var resourceTemplate = Resources.Load<TileView>(GetTileResourcePath(type));
        var newObject = UnityEngine.Object.Instantiate(resourceTemplate);
        newObject.Initialize(tileEntity);
        newObject.transform.SetParent(viewContainer);
        return newObject;
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
