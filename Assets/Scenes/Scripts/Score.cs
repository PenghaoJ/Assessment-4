using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Score : MonoBehaviour
{
    public int score = 1;
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.add_Score(score);
            soundTools.instance.OnChiDou();
        }
    }
}
