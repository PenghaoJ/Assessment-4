using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRender : MonoBehaviour
{
    GameObject panelObject;
    public int hartSize = 40;
    public Sprite imageSprite; 
    private List<GameObject> heartImages = new List<GameObject>();
    
    public void SetHearts(int hp)
    {
        
        foreach(GameObject heart in heartImages)
        {
            Destroy(heart);
        }
        heartImages.Clear();
        for (int i = 0; i < hp; i++)
        {
            
            GameObject imageObject = new GameObject("Heart"+i);
            imageObject.transform.SetParent(transform);
            heartImages.Add(imageObject);
            
            Image imageComponent = imageObject.AddComponent<Image>();
            imageComponent.sprite = imageSprite;
            
            RectTransform rectTransform = imageComponent.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0+i*hartSize*2, 0); 
            rectTransform.sizeDelta = new Vector2(hartSize, hartSize); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        panelObject = transform.parent.gameObject;
        
        Image imageComponent = GetComponent<Image>();
        
        Destroy(imageComponent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
