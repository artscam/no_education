using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpin : MonoBehaviour
{
    public float speed = 1f;
    public int spinDirection = -1;
    float y;
  
    void Update()
    {
        y += Time.deltaTime * speed * spinDirection;
        transform.Rotate(0, y, 0);
    }
}
