using UnityEngine;

public class TextureSetter : MonoBehaviour
{
    private MeshRenderer _rend; 
    private RenderTexture _mirrorTexture;
    [SerializeField] private Camera _mirrorCamera;
    void Start()
    {
        _rend = GetComponent<MeshRenderer>();
        _mirrorTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        _rend.material.SetTexture("_MainTex", _mirrorTexture);
        _mirrorCamera.targetTexture = _mirrorTexture;
    }
}
