using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBg : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] sprRenderer;
    [SerializeField]
    private Sprite[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        Sprite spr = backgrounds[Random.Range(0, backgrounds.Length)];
        for(int i = 0;  i < sprRenderer.Length; i++)
        {
            sprRenderer[i].sprite = spr;
        }
    }
}
