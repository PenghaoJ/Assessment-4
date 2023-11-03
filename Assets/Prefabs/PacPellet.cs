
using UnityEngine;

public class PacPellet : MonoBehaviour
{
    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Main Character_0")
        {
            Destroy(gameObject);
        }
    }
}
