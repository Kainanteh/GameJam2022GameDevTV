using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    public float scrollX = 1f;
    public float scrollY = 1f;

    private void Update() {
        float OffsetX = Time.time * scrollX;
        float OffsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX,OffsetY);
    }

}
