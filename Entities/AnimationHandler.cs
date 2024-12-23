using System;
using System.Collections.Generic;
using System.Linq;

namespace _2D_RPG;

internal class AnimationHandler
{
    private List<Animation> CurrentAnimations = [];
    
    public void handleAnimation(bool methodCall)
    {
        try{

            if(CurrentAnimations.Count() > 0) {

                if(methodCall)
                {
                    foreach(Animation animation in CurrentAnimations)
                    {
                        animation.Update();
                    }
                }
                else
                {
                    foreach(Animation animation in CurrentAnimations)
                    {
                        animation.Draw();
                    }
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
        if(CurrentAnimations.Count != 0){
            if(CurrentAnimations.Contains(animation))
            {
                CurrentAnimations.Remove(animation);
            }
        }
    }
   public void Update(List<Entity> entityList)
    {
        List<Animation> toBeRemoved = [];
        foreach(Entity entity in entityList)
        {
            foreach(Animation animation in CurrentAnimations)
            {
                if (animation.ActionIdentifier != entity.ActionIdentifier && animation.Entity == entity)
                {
                    toBeRemoved.Add(animation);
                }
            }
            if (CurrentAnimations.FirstOrDefault(animation => animation.ActionIdentifier == entity.ActionIdentifier) == null )
            {
                addNewAnimation(new Animation(entity,entity.ActionIdentifier));
            }
        }
        foreach(Animation animation in toBeRemoved)
        {
            removeAnimation(animation);
        }
    }
 
}