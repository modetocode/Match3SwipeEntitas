using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class TickComponent : IComponent {
    public long value;
}