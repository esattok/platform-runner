using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorMatchController : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Color targetColor;
    [SerializeField] TMP_Text percText;
    [SerializeField] TMP_Text wellDoneText;
    [SerializeField] float percentage;
    Texture2D texture;


    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    [ContextMenu(nameof(CalculateColorMatchPercentage))]
    public void CalculateColorMatchPercentage()
    {
        texture = ToTexture2D((RenderTexture)meshRenderer.sharedMaterial.mainTexture);
        var pixels = texture.GetPixels();
        int totalPixelCount = pixels.Length;

        var matchCount = 0;

        for (int i = 0; i < totalPixelCount; i++)
        {
            if (pixels[i] == targetColor)
                matchCount++;
        }

        
            //Debug.Log("width: " + texture.width);
            //Debug.Log("height: " + texture.height);
            //Debug.Log("widthxheight: " + texture.height * texture.width);

            //Debug.Log("Total count: " + totalPixelCount);
        
        

        percentage = Mathf.Ceil(100f * matchCount / totalPixelCount);
        
        percText.SetText("Painted : " + percentage + "%");

        if (percentage == 100)
        {
            wellDoneText.gameObject.SetActive(true);
        }
    }
}
