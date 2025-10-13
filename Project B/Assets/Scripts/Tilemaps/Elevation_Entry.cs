using UnityEngine;

public class Elevation_Entry : MonoBehaviour
{
    public Collider2D[] wallColliders;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D wall in wallColliders)
            {
                wall.enabled = false;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }

}
