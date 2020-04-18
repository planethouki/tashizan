using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishDirector : MonoBehaviour
{
    public Text resultText;
    public GameObject goodImage;
    public GameObject normalImage;
    public GameObject badImage;
    
    // Start is called before the first frame update
    void Start()
    {
        goodImage.SetActive(false);
        normalImage.SetActive(false);
        badImage.SetActive(false);
        var result = GameDirector.FinishSumText;
        resultText.text = result;
        var num = int.Parse(result);
        if (num == 364)
        {
            goodImage.SetActive(true);
        } 
        else if (344 < num && num < 384)
        {
            normalImage.SetActive(true);
        }
        else
        {
            badImage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
