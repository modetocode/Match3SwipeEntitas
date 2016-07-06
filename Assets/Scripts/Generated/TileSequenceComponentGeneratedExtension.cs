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
        static readonly TileSequenceComponent tileSequenceComponent = new TileSequenceComponent();

        public bool isTileSequence {
            get { return HasComponent(ComponentIds.TileSequence); }
            set {
                if (value != isTileSequence) {
                    if (value) {
                        AddComponent(ComponentIds.TileSequence, tileSequenceComponent);
                    } else {
                        RemoveComponent(ComponentIds.TileSequence);
                    }
                }
            }
        }

        public Entity IsTileSequence(bool value) {
            isTileSequence = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTileSequence;

        public static IMatcher TileSequence {
            get {
                if (_matcherTileSequence == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TileSequence);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTileSequence = matcher;
                }

                return _matcherTileSequence;
            }
        }
    }
}