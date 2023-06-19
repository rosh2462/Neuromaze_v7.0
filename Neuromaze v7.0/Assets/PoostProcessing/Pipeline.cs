using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPipeline : MonoBehaviour
{
    public Material mat;
    
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }

}
