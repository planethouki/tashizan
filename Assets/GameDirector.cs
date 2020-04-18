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

    private Card[] cards;
    private int numRemainCard;
    
    // Start is called before the first frame update
    void Start()
    {
        inputText.text = "0";
        currentSumText.text = "0";
        var seq = new Card[54];
        for (int i = 0; i < 54; i++)
        {
            seq[i] = new Card((i % 13) + 1, i / 13);
        }

        cards = Card.Shuffle(seq);
        cardText.text = cards[0].Number.ToString();
        cardMarkText.text = cards[0].Mark;
        numRemainCard = 53;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoButtonClick()
    {
        var current = int.Parse(currentSumText.text);
        var input = int.Parse(inputText.text);
        var sum = current + input;
        currentSumText.text = sum.ToString();
        inputText.text = "0";

        cardText.text = cards[54 - numRemainCard].Number.ToString();
        cardMarkText.text = cards[54 - numRemainCard].Mark;
        numRemainCard--;
    }

    public void OnBsButtonClick()
    {
        int inputNumber = int.Parse(inputText.text);
        inputNumber /= 10;
        inputText.text = inputNumber.ToString();
    }

    public void OnButtonClick(string buttonName)
    {
        string result = Calc.Input(buttonName, inputText.text);
        inputText.text = result;
    }
}
