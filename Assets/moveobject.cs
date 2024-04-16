using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobject : MonoBehaviour
{
    public float level = 1;
    private Vector3 Direction1;
    private float speed1;
    private Vector3 Orientation1;

    // Start is called before the first frame update
    protected void Start()
    {
        float randomFloat = Random.value;
        float speed = Random.value;
        Vector3 Direction = new Vector3(Random.Range(0.01f, 0.1f), 0, Random.Range(-0.03f, 0.03f));
        Vector3 Orientation = new Vector3(Random.value, Random.value, Random.value);
        Orientation1 = Orientation;
        Direction1 = Direction;
        speed1 = speed;
        transform.position = new Vector3(Random.Range(-19f, -1f), Random.Range(0f, 6f), Random.Range(-13f, 14f));
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Rotate(Orientation1, Space.Self);
        transform.Translate(Direction1 * speed1 * level * Time.timeScale);
        if (transform.position.x > 5 || transform.position.x < -15 || transform.position.y > 6|| transform.position.y < -2 || transform.position.z > 16 || transform.position.z < -9)
        {
            transform.position = new Vector3(Random.Range(-19f, -1f), Random.Range(0f, 4f), Random.Range(-7f, 14f));
            speed1 = Random.value;
            Direction1 = new Vector3(Random.Range(0.01f, 0.1f), 0, Random.Range(-0.03f, 0.03f));
        }
    }
}
