using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text currentSumText;
    public Text cardText;
    public Text cardMarkText;
    public Text inputText;
    public Text remainText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(string buttonName)
    {
        string result = Calc.Input(buttonName, inputText.text);
        Debug.Log(result);
        inputText.text = result;
    }
}
