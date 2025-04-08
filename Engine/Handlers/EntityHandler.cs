using System.Collections.Generic;
using System.Linq;

namespace _2D_RPG;

///<Summary>
/// entity handling magic  
///</Summary>
public class EntityHandler
{
    #region Fields

    private static List<Entity> EntityList {get; set;}

    #endregion Fields
    
    #region Constructor
    ///<Summary>
    /// entity handler 
    ///</Summary>
    public EntityHandler()
    {
        EntityList = new List<Entity>{};
    }

    #endregion Constructor

    #region Functions

    ///<Summary>
    /// add entity to the list
    ///</Summary>
    public void AddEntityToList(Entity entity)
    {
        EntityList.Add(entity);
    }

    ///<Summary>
    /// kill unwanted entity
    ///</Summary>
    public void RemoveEntityFromList(Entity entity)
    {
        EntityList.Remove(entity);
    }  

    ///<Summary>
    /// return an entity list
    ///</Summary>
    public List<Entity> GetEntityList()
    {
        return EntityList;
    }  

    #endregion Functions
}