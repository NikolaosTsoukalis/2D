using System.Collections.Generic;

namespace _2D_RPG;

public class EntityHandler
{
    
    private static List<Entity> entityList;
    public static List<Entity> EntityList 
    {
        get{return entityList;}
        set{entityList = value;}
    }
    public EntityHandler()
    {
        EntityList = new List<Entity>{};
    }

    /// <summary>
    /// Adds an entity to the Entity List.
    /// </summary>
    /// <param name="entity">
    /// This object resembles an entity.
    /// </param>
    /// <remarks>
    /// This method adds an <see cref="Entity"/> object to the <see cref="EntityList"/> List.
    /// </remarks>
    public static void AddEntityToList(Entity entity)
    {
        EntityList.Add(entity);
    }

    /// <summary>
    /// Removes an entity from the Entity List.
    /// </summary>
    /// <param name="entity">
    /// This object resembles an entity.
    /// </param>
    /// <remarks>
    /// This method remove an <see cref="Entity"/> object from the <see cref="EntityList"/> List.
    /// </remarks>
    public static void RevomeEntityFromList(Entity entity)
    {
            EntityList.Remove(entity);
    }    

}