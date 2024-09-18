using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgEffect : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public float xoffset = 0;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xoffset += speed * Time.deltaTime;
        speed += 0.0000001f;
        spriteRenderer.material.mainTextureOffset = new Vector2(xoffset, spriteRenderer.material.mainTextureOffset.y);
    }
}
