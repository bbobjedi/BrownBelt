using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    private bool hit;
    void Update()
    {
        hit = Physics.Raycast(transform.position, transform.forward, 3, 1 << 8);
        if (hit)
        {
            Debug.LogWarning("Be careful!");
        }
        else
        {
            Debug.Log("All clear"!);
        }
    }
}
