
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PacStudent")
        {
            Destroy(gameObject);
        }
    }
}
