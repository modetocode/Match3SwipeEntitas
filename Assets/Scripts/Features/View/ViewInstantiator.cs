using System;
using UnityEngine;

public static class ViewInstantiator {

    private static readonly Transform viewContainer = new GameObject("Views").transform;

    public static GameObject InstantiateGameBoardElement(GameBoardElementType type) {
        var resourceTemplate = Resources.Load<GameObject>(GetGameBoardElementResourcePath(type));
        var newObject = UnityEngine.Object.Instantiate(resourceTemplate);
        newObject.transform.SetParent(viewContainer);
        return newObject;
    }

    private static string GetGameBoardElementResourcePath(GameBoardElementType type) {
        switch (type) {
            case GameBoardElementType.Amber:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.AmberGameBoardPrefabName;
            case GameBoardElementType.Emerald:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.EmeraldGameBoardPrefabName;
            case GameBoardElementType.Prism:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.PrismGameBoardPrefabName;
            case GameBoardElementType.Ruby:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.RubyGameBoardPrefabName;
            case GameBoardElementType.Sapphire:
                return Constants.Resources.GameBoardElementsPathInResources + Constants.Resources.SapphireGameBoardPrefabName;
        }

        throw new InvalidOperationException("type not supported");
    }
}
