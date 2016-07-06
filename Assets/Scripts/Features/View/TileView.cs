using Entitas;
using UnityEngine;

public class TileView : MonoBehaviour {

    public Entity Tile { get; private set; }

    public void Initialize(Entity tile) {
        this.Tile = tile;
    }

    public void Destroy() {
        this.Tile = null;
    }
}