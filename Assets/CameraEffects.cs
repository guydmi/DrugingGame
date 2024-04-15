using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public float shakeMagnitude = 0.00001f;
    public float shakeDuration = 0.1f;
    public float rotationFactor = 100f;

    private bool isShaking = false;

    private float trueProbability = 0.005f;
    private System.Random random = new System.Random();
    private Quaternion previousRotation;

    // Start is called before the first frame update
    void Start()
    {
        previousRotation =  transform.rotation;
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        isShaking = true;
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        isShaking=false;
    }

    public void AmplifyRotation()
    {
        if (transform.rotation != previousRotation)
        {
            Quaternion difference = Quaternion.Inverse(previousRotation) * transform.rotation;
            difference *= Quaternion.Euler(0f, 0f, rotationFactor);
            transform.rotation = previousRotation * difference;
            previousRotation = transform.rotation;
        }
    }

    private bool GenerateRandomBool()
    {
        return random.NextDouble() < trueProbability;
    }





    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerInfo.Instance.BottleBloom > 0)
        {
            AmplifyRotation();
        }
        if (!isShaking && PlayerInfo.Instance.BottleTrouble > 3)
        {
            bool randomBool = GenerateRandomBool();
            if (randomBool)
            {
                ShakeCamera();
            }
        }
    }
}
