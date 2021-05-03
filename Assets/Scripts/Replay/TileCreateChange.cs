using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreateChange : TileChange
{
    private Vector3 _position;
    
    public TileCreateChange(float time, Vector3 position) : base(time)
    {
        _position = position;
    }

    public override void MakeChange(GameObject prefab)
    {
        GameObject.Instantiate(prefab, _position, Quaternion.identity);
    }
}
