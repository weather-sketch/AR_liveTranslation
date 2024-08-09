using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class customDictationExperience : MonoBehaviour
{
    public TextMeshProUGUI Result;
    private string googleTranslateApiKey = "AIzaSyB4TMcYqLVfrHs9fmh2DVj9koldqdgL50A";

    private void Start()
    {
        Debug.Log("Translation initializing...");
    }
    public void TranslateText(string text)
    {
        text = Result.text;
        Debug.Log("Transcription Text: " + text);
        if (!string.IsNullOrEmpty(text))
        {
            StartCoroutine(Translate(text));
        }
        else
        {
            Debug.LogError("Transcription text is empty.");
        }

    }
    private IEnumerator Translate(string text)
    {
        string url = $"https://translation.googleapis.com/language/translate/v2?key={googleTranslateApiKey}";


        var jsonData = new JObject();
        jsonData["q"] = text;
        jsonData["source"] = "en";
        jsonData["target"] = "zh";
        jsonData["format"] = "text";

        string jsonString = jsonData.ToString();
        Debug.Log("Request URL: " + url);
        Debug.Log("Request JSON: " + jsonString);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            Debug.LogError(request.downloadHandler.text);
        }
        else
        {
            string result = request.downloadHandler.text;
            Debug.Log("Translation Result: " + result);

            var jsonResponse = JObject.Parse(result);
            if (jsonResponse != null && jsonResponse["data"]["translations"].HasValues)
            {
                Result.text = jsonResponse["data"]["translations"][0]["translatedText"].ToString();
            }
        }
    }
}
