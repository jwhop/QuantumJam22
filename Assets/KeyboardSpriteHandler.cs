using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardSpriteHandler : MonoBehaviour
{
    public static KeyboardSpriteHandler Instance { get; private set; }
    [SerializeField] List<Texture> ImageList;
    // Start is called before the first frame update
    void Start()
    {
        print("assigning images");
        print(ImageList.Count);
        Instance = this;
        for (int i = 0; i < ImageList.Count; i++)
        {
            print("assigning image");
            Material mat = transform.GetChild(i+1).GetComponent<SpriteRenderer>().material;
            transform.GetChild(i + 1).GetComponent<SpriteRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);

            print("mat is " + mat);
            mat.mainTexture =  ImageList[i];
        }
    }

    public void SetChildGreen(int i, bool b)
    {
        transform.GetChild(i+1).GetComponent<SpriteRenderer>().material.color = new Color(0.0f,1.0f,0.0f);
        if (b) transform.GetChild(i + 1).GetComponent<Animator>().SetInteger("Key", 1);
        else transform.GetChild(i + 1).GetComponent<Animator>().SetInteger("Key", 2);
    }
    public void SetChildGrey(int i, bool b)
    {
        transform.GetChild(i+1).GetComponent<SpriteRenderer>().material.color = new Color(0.7f, 0.7f, 0.7f);
        if(b)transform.GetChild(i + 1).GetComponent<Animator>().SetInteger("Key", 1);
        else transform.GetChild(i + 1).GetComponent<Animator>().SetInteger("Key", 2);
    }
    public void SetAllReady()
    {
        for (int i = 0; i < ImageList.Count; i++)
        {
            transform.GetChild(i + 1).GetComponent<SpriteRenderer>().material.color = new Color(1.0f,1.0f,1.0f);
        }
    }
}
