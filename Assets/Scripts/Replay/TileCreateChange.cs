using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: TileColorChange and TileDestroy are handled by the
// tile behaviour script.
public class TileCreateChange : TileChange
{
    private Vector3 _position;
    private int _numStrikesToDisappear;
    
    public TileCreateChange(float time, Vector3 position, int numStrikesToDisappear) : base(time)
    {
        _position = position;
        _numStrikesToDisappear = numStrikesToDisappear;
    }

    public override void MakeChange(GameObject prefab)
    {
        GameObject obj = GameObject.Instantiate(prefab, _position, Quaternion.identity);
        obj.GetComponent<TileBehaviour>().NumStrikesToDisappear = _numStrikesToDisappear;
    }
}
