using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLv1 : MonoBehaviour
{
    public float speed;
    public float timeSwap;
    private float tmp_timeSwap;
    private float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        tmp_timeSwap = timeSwap;   
    }

    // Update is called once per frame
    void Update()
    {
        timeSwap -= Time.deltaTime;
        if(timeSwap <= 0)
        {
            direction*=-1;
            timeSwap = tmp_timeSwap;
        }
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
    }
}
