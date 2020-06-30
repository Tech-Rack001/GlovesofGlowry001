using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadImages : MonoBehaviour
{
    public static List<Sprite> images = new List<Sprite>();
    readonly static string IMAGE_PATH = "Assets/Resources/Images/";
    readonly static string UNKNOWN_IMAGE_FILENAME = "Unknown-human-picture.png";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {
        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
        return NewSprite;
    }

    static Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    //public static void LoadAllFighterImages()
    //{
    //    for (int i = 1; i < ReadCSV.fighterData.Count; i++)
    //    {
    //        images.Add(LoadNewSprite(IMAGE_PATH + ReadCSV.fighterData[i].GetImageFileName()));
    //    }
    //    Debug.Log("All Images Loaded Successfully");
    //}

    //public static void LoadUnknownFigherImage()
    //{
    //    images.Add(LoadNewSprite(IMAGE_PATH + UNKNOWN_IMAGE_FILENAME));
    //}
}
