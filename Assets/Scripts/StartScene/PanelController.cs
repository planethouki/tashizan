using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    private bool _isTap;
    private Image _panelImage;
    
    // Start is called before the first frame update
    void Start()
    {
        _panelImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isTap == false)
        {
            _isTap = true;
            StartCoroutine("FadeScene");
        }
    }

    IEnumerator FadeScene()
    {
        float ms = 1f;
        while (ms > 0)
        {
            ms -= Time.deltaTime;
            _panelImage.color = new Color(1, 1, 1, 1 - ms);
            yield return null;
        }
        SceneManager.LoadScene("GameScene");
    }
}
