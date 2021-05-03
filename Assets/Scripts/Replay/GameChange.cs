using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameChange
{
   // public static Transform PaddleTransform { get; set; }
   // public static Transform BallTransform { get; set; }

   private float _time;

   protected GameChange(float time)
   {
      _time = time;
   }

   public abstract void MakeChange(GameObject gameObject);
   public abstract GameChangeType ChangeType(); 

   public float Time => _time;
   
   public enum GameChangeType
   {
      Paddle,
      Ball,
      Tile
   }
}