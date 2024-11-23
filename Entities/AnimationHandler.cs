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

                if(!methodCall)
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
    public void Update()
    {
        CurrentAnimations = new List<Animation>();
    }
 
}