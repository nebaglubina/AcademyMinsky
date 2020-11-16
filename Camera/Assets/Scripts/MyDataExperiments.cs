using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.IO.Compression;
using UnityEditor;
using UnityEditor.VersionControl;

[Serializable]
public class MySettings
{
    public float speed;
    public int health;
    public string fullName;
    public string base64Texture;
}

public class MyDataExperiments
{
    [MenuItem("Tools/Settings/Download")]
    public static void DownloadFile()
    {
        string uri = "https://dminsky.com/settings.zip";
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        string outPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        uwr.SendWebRequest();
    }

    [MenuItem("Tools/Settings/ApplySettings")]
    public static void ApplySettings()
    {
        string zipPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        string jsonPath = Path.Combine(Application.persistentDataPath, "settings.json");
        try
        {
            ZipFile.ExtractToDirectory(zipPath, Application.persistentDataPath);
            Debug.Log("Trying UNZIP");
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("FileNotFound - trying to download again, message: " + e.Message);
            DownloadFile();
        }
        catch (IOException e)
        {
            Debug.Log("File from ZIP already exists, deleting. Message: " + e.Message);
            File.Delete(jsonPath);
            ZipFile.ExtractToDirectory(zipPath, Application.persistentDataPath);
        }
        catch (Exception e)
        {
            Debug.Log("Uknown error: " + e.Message);
        }

        string json = File.ReadAllText(jsonPath);
        MySettings newSettings = JsonUtility.FromJson<MySettings>(json);
        byte[] textureBytes = Convert.FromBase64String(newSettings.base64Texture);
        string texturePath = Path.Combine(Application.persistentDataPath, "texture.jpg");
        try
        {
            File.WriteAllBytes(texturePath, textureBytes);
        }
        catch (PathTooLongException e)
        {
            Debug.Log("Path too long, message: " + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("DirectoryNotFoundException: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.Log("Uknown error: " + e.Message);
        }
        
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
        Debug.Log("Applying settings");
    }
}

