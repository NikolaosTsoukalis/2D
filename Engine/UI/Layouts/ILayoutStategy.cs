using System.Collections.Generic;
using System.Drawing;

namespace _2D_RPG;

public interface ILayoutStrategy
{
    void AssignComponentPositions(List<Component> Components, Rectangle Bounds);
}