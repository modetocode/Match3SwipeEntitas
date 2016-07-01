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
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        public Entity AddInput(int newX, int newY) {
            var component = CreateComponent<InputComponent>(ComponentIds.Input);
            component.x = newX;
            component.y = newY;
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity ReplaceInput(int newX, int newY) {
            var component = CreateComponent<InputComponent>(ComponentIds.Input);
            component.x = newX;
            component.y = newY;
            ReplaceComponent(ComponentIds.Input, component);
            return this;
        }

        public Entity RemoveInput() {
            return RemoveComponent(ComponentIds.Input);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInput;

        public static IMatcher Input {
            get {
                if (_matcherInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Input);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherInput = matcher;
                }

                return _matcherInput;
            }
        }
    }
}
