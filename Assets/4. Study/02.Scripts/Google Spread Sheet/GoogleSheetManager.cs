using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public string URL;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL); // 요청 전달
        yield return www.SendWebRequest();

        WWWForm form = new WWWForm();
        form.AddField("value","123");
        UnityWebRequest www2 = UnityWebRequest.Post(URL, form); // 요청 전달
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text; // 요청 받은 것 : Get
        // string data2 = www2.downloadHandler.text; // 요청 받은 것 : Post
        
        Debug.Log(data);
        // Debug.Log(data2);
    }
}
