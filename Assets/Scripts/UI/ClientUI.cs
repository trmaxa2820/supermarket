using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientUI : MonoBehaviour
{
    [SerializeField] private Image _progressView;
    [SerializeField] private Canvas _uiCanvas;

    private void OnEnable()
    {
        _progressView.type = Image.Type.Filled;
        _progressView.fillMethod = Image.FillMethod.Radial360;
        _uiCanvas.worldCamera = Camera.main;
    }

    public void ViewProgress(float timeToView)
    {
        StartCoroutine(StartView(timeToView));    
    }

    private IEnumerator StartView(float timeToView)
    {
        _progressView.gameObject.SetActive(true);

        float _timeAfterStart = 0;
        _progressView.fillAmount = 0;

        while (timeToView > _timeAfterStart)
        {
            _timeAfterStart += Time.deltaTime;
            _progressView.fillAmount = _timeAfterStart / timeToView;
            _uiCanvas.transform.LookAt(Camera.main.transform);
            yield return null;
        }
        _progressView.gameObject.SetActive(false);
    }
}
