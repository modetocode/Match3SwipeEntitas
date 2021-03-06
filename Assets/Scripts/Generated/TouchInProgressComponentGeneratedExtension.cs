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
        static readonly TouchInProgressComponent touchInProgressComponent = new TouchInProgressComponent();

        public bool isTouchInProgress {
            get { return HasComponent(ComponentIds.TouchInProgress); }
            set {
                if (value != isTouchInProgress) {
                    if (value) {
                        AddComponent(ComponentIds.TouchInProgress, touchInProgressComponent);
                    } else {
                        RemoveComponent(ComponentIds.TouchInProgress);
                    }
                }
            }
        }

        public Entity IsTouchInProgress(bool value) {
            isTouchInProgress = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity touchInProgressEntity { get { return GetGroup(Matcher.TouchInProgress).GetSingleEntity(); } }

        public bool isTouchInProgress {
            get { return touchInProgressEntity != null; }
            set {
                var entity = touchInProgressEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isTouchInProgress = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTouchInProgress;

        public static IMatcher TouchInProgress {
            get {
                if (_matcherTouchInProgress == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TouchInProgress);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTouchInProgress = matcher;
                }

                return _matcherTouchInProgress;
            }
        }
    }
}
