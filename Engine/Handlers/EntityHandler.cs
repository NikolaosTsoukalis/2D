using System.Collections.Generic;
using System.Linq;

namespace _2D_RPG;

public class EntityHandler
{
    private static List<Entity> EntityList {get; set;}
    public EntityHandler()
    {
        EntityList = new List<Entity>{};
    }

    public void AddEntityToList(Entity entity)
    {
        EntityList.Add(entity);
    }

    public void RemoveEntityFromList(Entity entity)
    {
        EntityList.Remove(entity);
    }  

    public List<Entity> GetEntityList()
    {
        return EntityList;
    }  
}