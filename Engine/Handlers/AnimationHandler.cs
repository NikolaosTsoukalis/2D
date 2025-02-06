using System;
using System.Collections.Generic;
using System.Linq;

namespace _2D_RPG;

public class AnimationHandler
{
    #region Values

    private List<Animation> CurrentAnimations {get;set;}

    #endregion Values
    
    #region Constructors

    public AnimationHandler()
    {
        CurrentAnimations = new();
    }
    
    #endregion Constructors

    #region Functions
    
    public void UpdateAnimations()
    {
        try{

            if(CurrentAnimations.Count() > 0) 
            {
                foreach(Animation animation in CurrentAnimations)
                {
                    animation.Update();
                }
            }
        }
        catch(Exception e)
        {
           Console.WriteLine(e.ToString()); 
        }
    }

    public void DrawAnimations()
    {
        try{

            if(CurrentAnimations.Count() > 0) 
            {
                foreach(Animation animation in CurrentAnimations)
                {
                    animation.Draw();
                }
            }
        }
        catch(Exception e)
        {
           Console.WriteLine(e.ToString()); 
        }
    }

    public void addNewAnimation(Animation animation)
    {
        if(!CurrentAnimations.Contains(animation))
        {
            CurrentAnimations.Add(animation);
        }  
    }

    public void removeAnimation(Animation animation)
    {
        if(CurrentAnimations.Count != 0)
        {
            if(CurrentAnimations.Contains(animation))
            {
                CurrentAnimations.Remove(animation);
            }
        }
    }
   public void UpdateAnimationList()
    {
        List<Animation> toBeRemoved = [];
        foreach(Entity entity in Globals.entityHandler.GetEntityList())
        {
            foreach(Animation animation in CurrentAnimations)
            {
                if (animation.AnimationIdentifier != entity.AnimationIdentifier && animation.Entity.Name == entity.Name)
                {
                    toBeRemoved.Add(animation);
                }
            }
            if (CurrentAnimations.FirstOrDefault(animation => animation.AnimationIdentifier == entity.AnimationIdentifier && animation.Entity.Name == entity.Name) == null )
            {
                addNewAnimation(new Animation(entity,entity.AnimationIdentifier));
            }
        }
        foreach(Animation animation in toBeRemoved)
        {
            removeAnimation(animation);
        }
    }
    #endregion Functions
}