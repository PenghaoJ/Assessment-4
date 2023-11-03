using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownLoader : MonoBehaviour
{
    public float countdownTime = 3f; // ����ʱ��ʱ��

    public Text countdownText;

    void Start()
    {
       // countdownText = GetComponent<Text>();
        countdownText.text = countdownTime.ToString();
    }

    void Update()
    {
        countdownTime -= Time.deltaTime;
        if (countdownTime <= 0)
        {
            LoadLevel1();
        }
        else
        {
            countdownText.text = Mathf.Ceil(countdownTime).ToString();
        }
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene"); // �滻Ϊʵ�ʵĹؿ�����
    }
}