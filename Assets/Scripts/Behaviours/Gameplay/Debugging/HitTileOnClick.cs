using UnityEngine;
using UnityEngine.InputSystem;


public class HitTileOnClick : MonoBehaviour
{
    public void OnFire(InputValue input){
        if (DebugManager.DEBUG)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Vector2 xy = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(xy, new Vector2(0, 0));
            if (hit && hit.collider.gameObject.name.Contains("Tile"))
            {
                hit.collider.gameObject.GetComponent<TileBehaviour>().OnCollisionExit2D(null);
            }
        }
    }
}
