using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRenderer;
    void Update()
    {
        if (GameManager.instance.canMove)
            bgRenderer.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
