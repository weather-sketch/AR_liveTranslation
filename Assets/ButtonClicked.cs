using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public TextMeshProUGUI transcription;
    public TextMeshProUGUI copyTranscription;
    public Button sample;
    public Button xr;
    public Button clear;
    public Button xr_clear;

    // Start is called before the first frame update
    void Start()
    {
        xr.onClick.AddListener(OnStartButtonClicked);
        xr_clear.onClick.AddListener(OnClearButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        copyTranscription.text = transcription.text;
    }



    void OnStartButtonClicked()
    {
        sample.onClick.Invoke();
    }

    void OnClearButtonClicked()
    {
        clear.onClick.Invoke();
    }
}
