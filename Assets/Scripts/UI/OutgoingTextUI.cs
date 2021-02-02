using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OutgoingTextUI : MonoBehaviour
{
    [SerializeField] private Canvas _textCanvas;
    [SerializeField] private Text _outgoingTextTemplate;
    [SerializeField] private float _animationTime;
    [SerializeField] private Animator _textAnimator;

   
    [SerializeField] private IShowingText _iShowingText;

    private void OnEnable()
    {
        _iShowingText = GetComponent<IShowingText>();
        _textCanvas.worldCamera = Camera.main;
        _iShowingText.OnShowingText += ShowText;
    }

    private void OnDisable()
    {
        _iShowingText.OnShowingText -= ShowText;
    }

    private void ShowText(string text)
    {
        _outgoingTextTemplate.text = text;
        StartCoroutine(ShowTExtAnimation());
    }

    private IEnumerator ShowTExtAnimation()
    {
        _outgoingTextTemplate.gameObject.SetActive(true);
        _textAnimator.Play("TextAnimation");
        float timeAfterStart = 0;

        while(timeAfterStart < _animationTime)
        {
            _textCanvas.transform.LookAt(_textCanvas.worldCamera.transform);
            timeAfterStart += Time.deltaTime;

            yield return null;
        }

        _outgoingTextTemplate.gameObject.SetActive(false);
    }
}

public interface IShowingText
{
    event UnityAction<string> OnShowingText;
}