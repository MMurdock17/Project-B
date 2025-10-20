using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{
    //creating array variables
    public Collider2D[] wallColliders;
    public Collider2D[] boundaryColliders;

    //handles exiting elevation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Collider2D wall in wallColliders)
            {
                wall.enabled = true;
            }

             foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = false;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }

}
