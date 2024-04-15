using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float level = 12f;
    private Vector3 initState = new Vector3(-10f,0,0);
    private Vector3 Direction;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.1f, 0.5f);
        Vector3 Direction = new Vector3(Random.Range(0.1f, 1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * level * Time.deltaTime);
        if (transform.position.x > 20f) 
        {
            transform.position = initState;
        }
    }
}
