using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        switch (Time.timeScale)
        {
            case 1:
                Time.timeScale = 0;
                break;
            case 0:
                Time.timeScale = 1;
                break;
        }
    }
}