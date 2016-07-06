using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[SingleEntity]
public class GameBoardComponent : IComponent {
    public int rowCount;
    public int columnCount;
    public IList<TileType> possibleElements;
}
