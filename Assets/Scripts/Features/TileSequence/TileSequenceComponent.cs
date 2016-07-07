using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[SingleEntity]
public class TileSequenceComponent : IComponent {
    public IList<Entity> sequence;
}