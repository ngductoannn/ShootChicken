using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLv2 : MonoBehaviour
{
    public float speed_LR, speed_UD;
    public float timeSwap_LR, timeSwap_UD, timeSpawnEgg;
    private float tmp_timeSwap_LR, tmp_timeSwap_UD;
    private float direction_LR = 1;
    private float direction_UD = 1;
    public GameObject egg;
    // Start is called before the first frame update
    void Start()
    {
        tmp_timeSwap_LR = timeSwap_LR; 
        tmp_timeSwap_UD = timeSwap_UD;
    }

    // Update is called once per frame
    void Update()
    {
        timeSwap_LR -= Time.deltaTime;
        timeSwap_UD -= Time.deltaTime;
        timeSpawnEgg -= Time.deltaTime;
        if(timeSwap_LR <= 0)
        {
            direction_LR*=-1;
            timeSwap_LR = tmp_timeSwap_LR;
        }
        if(timeSwap_UD <= 0)
        {
            direction_UD *= -1;
            timeSwap_UD = tmp_timeSwap_UD;
        }
        if(timeSpawnEgg <= 0)
        {
            Instantiate(egg, transform.position, Quaternion.identity);
            timeSpawnEgg = Random.Range(1,3);
        }
        transform.position += new Vector3(speed_LR * direction_LR * Time.deltaTime, 0, 0);
        transform.position += new Vector3(0, speed_UD * direction_UD * Time.deltaTime, 0);
    }
}
