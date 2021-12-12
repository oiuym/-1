using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void MoveLeft()
    {
        if (transform.position.x > -5)
        { 
            transform.Translate(-1, 0, 0);
        }
    }
    public void MoveRight()
    {
        if (transform.position.x < 5)
        {
            transform.Translate(1, 0, 0);
        }
    }
}
