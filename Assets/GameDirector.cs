using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text currentSumText;
    public Text cardText;
    public Text inputText;
    public Text remainText;

    private Card[] _cards;
    private int _numRemainCard = 52;
    private Dictionary<string, GameObject> _cardMarks;
    
    // Start is called before the first frame update
    void Start()
    {
        inputText.text = "0";
        currentSumText.text = "0";
        var seq = new Card[52];
        for (int i = 0; i < 52; i++)
        {
            seq[i] = new Card((i % 13) + 1, i / 13);
        }

        _cards = Card.Shuffle(seq);

        _cardMarks = new Dictionary<string, GameObject>()
        {
            ["Dia"] = GameObject.Find("DiaImage"),
            ["Clover"] = GameObject.Find("CloverImage"),
            ["Heart"] = GameObject.Find("HeartImage"),
            ["Spade"] = GameObject.Find("SpadeImage")
        };
        _cardMarks["Dia"].SetActive(false);
        _cardMarks["Spade"].SetActive(false);
        _cardMarks["Heart"].SetActive(false);
        _cardMarks["Clover"].SetActive(false);

        cardText.text = _cards[0].Number.ToString();
        var markKey = _cards[52 - _numRemainCard].Mark;
        _cardMarks[markKey].SetActive(true);
        _numRemainCard--;
        remainText.text = "残り53枚";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoButtonClick()
    {
        currentSumText.text = inputText.text;
        inputText.text = "0";

        cardText.text = _cards[52 - _numRemainCard].Number.ToString();
        _cardMarks["Dia"].SetActive(false);
        _cardMarks["Spade"].SetActive(false);
        _cardMarks["Heart"].SetActive(false);
        _cardMarks["Clover"].SetActive(false);
        var markKey = _cards[52 - _numRemainCard].Mark;
        _cardMarks[markKey].SetActive(true);
        remainText.text = "残り" + _numRemainCard + "枚";
        _numRemainCard--;
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
