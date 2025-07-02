using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class FrameText : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _timeBetweenLetters = 0.05f;
    [SerializeField]
    private float _timeToDisappear = 1f;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _showTextAnimationName = "ShowText";
    [SerializeField]
    private string _hideTextAnimationName = "HideText";
    private string _fullText;
    private Coroutine _showTextCoroutine;
    public static FrameText Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void StopText(bool stopAnimation = false)
    {
        if (_showTextCoroutine != null)
        {
            StopCoroutine(_showTextCoroutine);
            _showTextCoroutine = null;
        }
        _text.text = "";
        if (stopAnimation)
        {
            _animator.Play(_hideTextAnimationName, 0, 0f);
        }
    }
    public void ShowText(string text)
    {
        StopText();
        _animator.Play(_showTextAnimationName, 0, 0f);
        _showTextCoroutine = StartCoroutine(ShowTextCoroutine(text));
    }
    private IEnumerator ShowTextCoroutine(string text)
    {
        _fullText = text;
        _text.text = "";
        foreach (char letter in _fullText)
        {
            _text.text += letter;
            yield return new WaitForSeconds(_timeBetweenLetters);
        }
        yield return new WaitForSeconds(_timeToDisappear);
        _showTextCoroutine = null;
        _animator.Play(_hideTextAnimationName, 0 , 0f);
    }
}
