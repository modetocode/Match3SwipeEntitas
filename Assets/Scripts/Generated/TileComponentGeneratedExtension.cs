//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public TileComponent tile { get { return (TileComponent)GetComponent(ComponentIds.Tile); } }

        public bool hasTile { get { return HasComponent(ComponentIds.Tile); } }

        public Entity AddTile(TileType newTileType) {
            var component = CreateComponent<TileComponent>(ComponentIds.Tile);
            component.tileType = newTileType;
            return AddComponent(ComponentIds.Tile, component);
        }

        public Entity ReplaceTile(TileType newTileType) {
            var component = CreateComponent<TileComponent>(ComponentIds.Tile);
            component.tileType = newTileType;
            ReplaceComponent(ComponentIds.Tile, component);
            return this;
        }

        public Entity RemoveTile() {
            return RemoveComponent(ComponentIds.Tile);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTile;

        public static IMatcher Tile {
            get {
                if (_matcherTile == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Tile);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTile = matcher;
                }

                return _matcherTile;
            }
        }
    }
}
