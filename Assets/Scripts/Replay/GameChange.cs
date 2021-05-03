using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GameChange
{
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