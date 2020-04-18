using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTextController : MonoBehaviour
{
    private TextMesh _mesh;
    private float _textOpacity;
    private float _opacityDiff;
    private bool _isTap;
    private Image _panelImage;
    
    // Start is called before the first frame update
    void Start()
    {
        _mesh = GetComponent<TextMesh>();
        _textOpacity = 1f;
        _opacityDiff = 0.02f;
        _isTap = false;
        var panel = GameObject.Find("Panel");
        _panelImage = panel.GetComponent<Image>();
        transform.localScale = new Vector3 (-1, 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform);
        _textOpacity += _opacityDiff;
        if (_textOpacity > 1)
        {
            _textOpacity = 1f;
            _opacityDiff *= -1;
        }
        else if (_textOpacity < 0)
        {
            _textOpacity = 0f;
            _opacityDiff *= -1;
        }
        
        _mesh.color = new Color(1, 1, 1, _textOpacity);

        if (Input.GetMouseButtonDown(0) && _isTap == false)
        {
            _isTap = true;
            StartCoroutine(FadeScene());
        }
    }

    IEnumerator FadeScene()
    {
        for (float i = 0; i < 200; i++)
        {
            _panelImage.color = new Color(1, 1, 1, i / 200);
            yield return null;
        }
        SceneManager.LoadScene("GameScene");
    }
}
