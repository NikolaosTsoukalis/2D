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

    /// <summary>
    /// Adds an entity to the Entity List.
    /// </summary>
    /// <param name="entity">
    /// This object resembles an entity.
    /// </param>
    /// <remarks>
    /// This method adds an <see cref="Entity"/> object to the <see cref="EntityList"/> List.
    /// </remarks>
    public void AddEntityToList(Entity entity)
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
    public void RemoveEntityFromList(Entity entity)
    {
        EntityList.Remove(entity);
    }  

    public List<Entity> GetEntityList()
    {
        return EntityList;
    }

    public bool HandleEntityAttacked(float damageTaken, Entity entity)
    {
        var list = GetEntityList();
        CombatEntity entityAttacked = (CombatEntity)list.FirstOrDefault(entityC => entityC.Name == entity.Name && entityC.GetType() == typeof(CombatEntity));
        if(entityAttacked != null)
        {
            entityAttacked.HP -= damageTaken;
        }
        return false;
    }  

}