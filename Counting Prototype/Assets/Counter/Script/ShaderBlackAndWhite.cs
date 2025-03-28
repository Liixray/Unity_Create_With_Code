using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ConvertRenderTextureToBW : MonoBehaviour
{
    public DecalProjector decalProjector;   // Référence à votre Decal Projector
    public RenderTexture renderTexture;      // La RenderTexture que vous voulez convertir
    private Texture2D bwTexture;             // La texture résultante en noir et blanc

    void Start()
    {
        // Convertir la RenderTexture en Texture2D
        bwTexture = RenderTextureToTexture2D(renderTexture);

        // Convertir la texture en noir et blanc
        Texture2D bwTex = ConvertToBW(bwTexture);

        // Appliquer la texture noir et blanc au matériau du Decal Projector
        decalProjector.material.SetTexture("_BaseMap", bwTex);
    }

    // Fonction pour convertir RenderTexture en Texture2D
    Texture2D RenderTextureToTexture2D(RenderTexture renderTex)
    {
        Texture2D texture = new Texture2D(renderTex.width, renderTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTex;
        texture.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;
        return texture;
    }

    // Fonction pour convertir une Texture2D en noir et blanc
    Texture2D ConvertToBW(Texture2D colorTex)
    {
        Texture2D bwTex = new Texture2D(colorTex.width, colorTex.height);

        // Parcours de chaque pixel et conversion en niveaux de gris
        for (int x = 0; x < colorTex.width; x++)
        {
            for (int y = 0; y < colorTex.height; y++)
            {
                Color pixelColor = colorTex.GetPixel(x, y);
                float grayscale = pixelColor.grayscale;
                bwTex.SetPixel(x, y, new Color(grayscale, grayscale, grayscale));
            }
        }

        bwTex.Apply(); // Applique les changements
        return bwTex;
    }
}
