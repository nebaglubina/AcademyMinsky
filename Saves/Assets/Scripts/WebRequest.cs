using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    void OnGUI()
    {
        if (GUILayout.Button("Download File"))
        {
            StartCoroutine(DownloadFile());
        }
    }

    IEnumerator DownloadFile()
    {
        string uri = "http://dminsky.com/rock_normal.jpg";
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log(Application.persistentDataPath);
            string outPath = Path.Combine(Application.persistentDataPath, "rock_normal1.jpg");
            File.WriteAllBytes(outPath, uwr.downloadHandler.data); //byte array
        }
    }
}
