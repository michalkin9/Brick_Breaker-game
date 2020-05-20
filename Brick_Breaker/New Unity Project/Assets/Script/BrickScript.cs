using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;

    public void BreakBrick()
    {
        hitsToBreak--;

        //to change the aperance :
        //GetComponent<SpriteRenderer>().sprite = hitSprite;

    }
}
