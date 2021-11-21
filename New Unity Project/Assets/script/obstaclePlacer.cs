using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePlacer : MonoBehaviour
{
    public double queueTime = 1.5;
    private float time = 0;
    public GameObject obstacle;

    public float height;

    void Update()
    {
        if (time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            time = 0;

            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}