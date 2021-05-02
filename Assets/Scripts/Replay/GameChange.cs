using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameChange
{
   private Transform _transform;
   private float _time;

   protected GameChange(Transform transform, float time)
   {
      _transform = transform;
      _time = time;
   }

   public abstract void MakeChange();

   public Transform Transform => _transform;
   public float Time => _time;
}