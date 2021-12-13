using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1scaler : MonoBehaviour
{
    int key = 1;
    float a = 0;

    void Update()
    {
        this.a += Time.deltaTime;
        if (this.a > 0.3f)
        {
            this.key *= -1;
            transform.localScale = new Vector3(this.key, 1, 1);
            this.a = 0;
        }
    }
}
