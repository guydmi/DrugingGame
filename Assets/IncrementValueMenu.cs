using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementValueMenu : MonoBehaviour
{
    public bool isAlcool;
    public bool isWeed;
    public bool isLSD;
    public bool isWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (isAlcool)
        {
            PlayerInfo.Instance.BottleBloom += 1;        }
        if (isWeed)
        {
            PlayerInfo.Instance.BottleTrouble += 1;
        }
        if (isLSD)
        {
            PlayerInfo.Instance.BottleChroma += 1;
        }
        if (isWater)
        {
            PlayerInfo.Instance.BottleBloom = 0;
            PlayerInfo.Instance.BottleTrouble = 0;
            PlayerInfo.Instance.BottleChroma = 0;
        }
    }
}
