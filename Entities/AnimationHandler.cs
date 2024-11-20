using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

internal class AnimationHandler
{
    private List<Animation> CurrentAnimations = [];

    public void handleAnimation(GameTime gametime)
    {
        try{

            if(CurrentAnimations.Count() > 0) {

                foreach(Animation animation in CurrentAnimations)
                {
                    animation.Animate(gametime);
                    animation.Update(gametime);
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
        CurrentAnimations.Add(animation);
    }

    public void removeAnimation(Animation animation)
    {
        if(CurrentAnimations.Contains(animation))
        {
            CurrentAnimations.Remove(animation);
        }
    }
    public void Update()
    {
        
    }
 
}