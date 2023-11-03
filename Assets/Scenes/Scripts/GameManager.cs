using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private int id_incex = 0;
    public Text scoreText;
    public Text scareTimeText;
    private int score;
    public GameState gameState = GameState.NORMAL;
    public Transform bones;
    public List<GameObject> dogs = new List<GameObject>();
    public float dogCountdownTime = 10f; 
    private float dogRemainingTime; 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score:" + score;

    }

    // Update is called once per frame
    void Update()
    {
        if (dogRemainingTime > 0f)
        {
            dogRemainingTime -= Time.deltaTime; 
            scareTimeText.text = $"Scared: {dogRemainingTime.ToString("f2")}s";
            if (dogRemainingTime <= 0f)
            {
                dogRemainingTime = 0f;

                ChangeGameState(GameState.NORMAL);
            }
        }
    }


    public void Revive(int id)
    {
        id_incex = id;
        Invoke("fhgou", 2);
        //fhgou();
    }

    void fhgou()
    {
        dogs[id_incex].SetActive(true);
    }

    public GameObject shenglin_plane;
    public void add_Score(int score)
    {
        this.score = this.score+score;
        scoreText.text = "Score:" + this.score;
        if(bones.childCount <= 1)
        {
            shenglin_plane.SetActive(true);
            Time.timeScale = 0;
            soundTools.instance.Onwin();
        }
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;

        if (gameState == GameState.NORMAL)
        {
            foreach (GameObject dog in dogs)
            {
                SpriteRenderer spriteRenderer = dog.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.white;
            }
        }
        else if (gameState == GameState.INVINCIBLE)
        {
            foreach (GameObject dog in dogs)
            {
                SpriteRenderer spriteRenderer = dog.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.red;
            }
            dogRemainingTime = dogCountdownTime;
        }
    }

    public void AttackDog(GameObject gameObject)
    {
        for(int i = 0; i < dogs.Count; i++)
        {
            if (gameObject == dogs[i])
            {
                //Destroy(gameObject);
                Transform parent = gameObject.transform.parent;
                Animator animator = parent.GetComponent<Animator>();
                parent.gameObject.SetActive(false);
                
                StartCoroutine(Countdown(3f, () =>
                {
                    
                    parent.gameObject.SetActive(true);
                    animator.Play(0, -1, 0f);
                }));
            }
        }
    }

    IEnumerator Countdown(float duration, System.Action onComplete)
    {
        yield return new WaitForSeconds(duration);
        onComplete?.Invoke();
    }
    int CountObjectsWithLayer(int layer)
    {
        int count = 0;
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == layer)
            {
                count++;
            }
        }
        return count;
    }
}
