using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: TileColorChange and TileDestroy are handled by the
// tile behaviour script.
[System.Serializable]
public class TileCreateChange : TileChange
{
    private float _posX;
    private float _posY;
    private int _numStrikesToDisappear;
    
    public TileCreateChange(float time, float posX, float posY, int numStrikesToDisappear) : base(time)
    {
        _posX = posX;
        _posY = posY;
        _numStrikesToDisappear = numStrikesToDisappear;
    }

    public override void MakeChange(GameObject prefab)
    {
        GameObject obj = GameObject.Instantiate(prefab, new Vector3(_posX,_posY, 0), Quaternion.identity);
        obj.GetComponent<TileBehaviour>().NumStrikesToDisappear = _numStrikesToDisappear;
    }
}
