using UnityEngine;

public class Elevation_Entry : MonoBehaviour
{
    public Collider2D[] wallColliders;
    public Collider2D[] boundaryColliders;

    //handling disabling boudaries when increasing elevation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Collider2D wall in wallColliders)
            {
                wall.enabled = false;
            }

             foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = true;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }

}
