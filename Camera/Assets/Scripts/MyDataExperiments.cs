using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.IO.Compression;
using UnityEditor;

[Serializable]
public class MySettings
{
    public float speed;
    public int health;
    public string fullName;
    public string base64Texture;
}

public class MyDataExperiments : MonoBehaviour
{
    [MenuItem("Tools/Settings/Download")]
    public static void DownloadFile()
    {
        string uri = "https://dminsky.com/settings.zip";
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        //uwr.downloadHandler = new DownloadHandlerFile(uri);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += (ao) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log("error!");
            }
            else
            {
                string outPath = Path.Combine(Application.persistentDataPath, "settings.zip");
                Debug.Log(outPath);
                File.WriteAllBytes(outPath, uwr.downloadHandler.data); //byte array
                Debug.Log("Download complete");
            }
        };
    }

    [MenuItem("Tools/Settings/ApplySettings")]
    public static void ApplySettings()
    {
        string zipPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        ZipFile.ExtractToDirectory(zipPath, Application.persistentDataPath);
        string jsonPath = Path.Combine(Application.persistentDataPath, "settings.json");
        string json = File.ReadAllText(jsonPath);
        MySettings newSettings = JsonUtility.FromJson<MySettings>(json);
        byte[] textureBytes = Convert.FromBase64String(newSettings.base64Texture);
        string texturePath = Path.Combine(Application.persistentDataPath, "texture.jpg");
        File.WriteAllBytes(texturePath, textureBytes);
        
        byte[] texturedata = File.ReadAllBytes(texturePath);
        Texture2D myTexture = new Texture2D(2, 2);
        myTexture.LoadImage(texturedata);
        var myMaterial = GameObject.Find("Floor").GetComponent<MeshRenderer>().sharedMaterial;
        myMaterial.EnableKeyword("_NORMALMAP");
        myMaterial.SetTexture("_BumpMap", myTexture);

        var myPlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (myPlayerMovement != null)
        {
            myPlayerMovement.MoveSpeed = newSettings.speed;
            myPlayerMovement.name = newSettings.fullName;
            myPlayerMovement.Health = newSettings.health;
        }
    }
}

