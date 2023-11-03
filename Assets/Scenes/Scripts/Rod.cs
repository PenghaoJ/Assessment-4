using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            //通知游戏管理器对象 进入无敌状态
            GameManager.instance.ChangeGameState(GameState.INVINCIBLE);
            soundTools.instance.OnPickUp();
        }
    }
}
