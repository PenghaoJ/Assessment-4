using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickLoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            Application.LoadLevel(0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
