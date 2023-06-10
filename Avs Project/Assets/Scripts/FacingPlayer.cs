using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FacingPlayer : MonoBehaviour
{
    private float horizontal;
    private float facing = 0f;

    void Update()
    {
        Facing();
    }
    void Facing()
    {
        horizontal = Input.GetAxisRaw("Horizontal");     
        facing = horizontal;
        if (facing > 0f)
        {
            transform.localScale = new Vector2(1, 1);//turns right
        }
        else if (facing < 0f)
        {
            transform.localScale = new Vector2(-1, 1);//turns left
        }
    }
}
