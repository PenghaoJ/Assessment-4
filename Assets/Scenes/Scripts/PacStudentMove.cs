using UnityEngine;

public class PacStudentMove : MonoBehaviour
{
    // Move speed
    public float moveSpeed = 2.0f;

    public GameObject diePlane;

    public GameObject hearts;
    private Vector2 initialPositon;
    private HeartRender heartRender;
    private Rigidbody2D rb;
    public int hp = 3;
    private void Start()
    {
        initialPositon = transform.position;
        rb = GetComponent<Rigidbody2D>();

        heartRender = hearts.GetComponent<HeartRender>();
        heartRender.SetHearts(hp);
    }
    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        Vector2 moveDirection = new Vector2(moveX*Time.deltaTime, moveY * Time.deltaTime).normalized;
        rb.velocity = moveDirection * moveSpeed;
        // To Animation change the destination
        GetComponent<Animator>().SetFloat("DirX", moveDirection.x);
        GetComponent<Animator>().SetFloat("DirY", moveDirection.y);
    }
    public SpriteRenderer my;
    public SpriteRenderer mb;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="enemy")
        {
            if (GameManager.instance.gameState == GameState.INVINCIBLE)
            {
                GameManager.instance.AttackDog(collision.gameObject);
            }
            else
            {
                hp--;
                heartRender.SetHearts(hp);
                if (hp <= 0)
                {
                    my.enabled = false;
                    mb.enabled = true;
                    Time.timeScale = 0;
                    // diePlane.SetActive(true);
                    soundTools.instance.OnDie();
                }
                else
                {
                    transform.position = initialPositon;

                }

            }
        }
    }
}