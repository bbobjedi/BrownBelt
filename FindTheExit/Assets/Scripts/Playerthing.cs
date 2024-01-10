using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerthing : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 destination = new Vector3(horizontal, 0, 1);
        transform.Translate(destination * speed * Time.deltaTime);
    }
}
