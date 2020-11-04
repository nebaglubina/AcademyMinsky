using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;
using System.IO.Compression;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

[Serializable]
public class MyData
{
    public float speed;
    public int health;
    public string name;
    public int[] numbers;
}
public class Base64Tutorial : Editor
{
    [MenuItem("Tools/Convert to base64")]
    public static void ConvertToBase64()
    {
        // Debug.Log($"{Application.persistentDataPath}");
        //File.ReadAllBytes("Assets/image.png");
        
        //byte[] brickBytes = File.ReadAllBytes("MyExperiments/brick.jpg");
        //string brickBase64 = Convert.ToBase64String(brickBytes);
        //File.WriteAllText("MyExperiments/brick_base64.txt", brickBase64);
        
        //string brickBase64 = File.ReadAllText("MyExperiments/brick_base.txt");
        //byte[] image = Convert.FromBase64String(brickBase64);
        //File.WriteAllBytes("MyExperiments/out_image.jpg, image);

        //File.WriteAllBytes("Assets/MyExperiments/image2.asset", new byte []{12, 23, 121, 213});
        
        //ZipFile.CreateFromDirectory("MyExperiments", "myArchive.zip");
        //ZipFile.ExtractToDirectory("myarchive.zip", "MyExperiments");
        
            //web req
            string uri = "http://dminsky.com/rock_normal.jpg";
            UnityWebRequest uwr = UnityWebRequest.Get(uri);
            uwr.downloadHandler = new DownloadHandlerFile(uri);
            var asyncOp = uwr.SendWebRequest();
            asyncOp.completed += (ao) =>
            {
                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log("error!");
                }
                else
                {
                    string outPath = Path.Combine(Application.persistentDataPath, "rock_normal2.jpg");
                    File.WriteAllBytes(outPath, uwr.downloadHandler.data); //byte array
                    Debug.Log("Completed");
                }
            };


            //texture stream
            /*byte[] texturedata = File.ReadAllBytes("Assets/rock_normal.jpg");
            Texture2D myTexture = new Texture2D(2, 2);
            myTexture.LoadImage(texturedata);
            var myMaterial = GameObject.Find("Floor").GetComponent<MeshRenderer>().sharedMaterial;
            myMaterial.EnableKeyword("_NORMALMAP");
            myMaterial.SetTexture("_BumpMap", myTexture);*/

            // json
            /*MyData data = new MyData();
            data.speed = 1;
            data.health = 100;
            data.name = "John";
            data.numbers = new int[]{ 1, 2, 3, 4, 5};
    
            string jsonData = JsonUtility.ToJson(data);
            MyData newData = JsonUtility.FromJson<MyData>(jsonData);
            Debug.Log(jsonData);*/
    }
}
