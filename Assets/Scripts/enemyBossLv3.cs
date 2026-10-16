using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyBossLv3 : MonoBehaviour
{
    public Slider healBarBoss;
    public GameObject eggLv3;
    public float speed_LR, speed_UD;
    public float timeSwap_LR, timeSwap_UD, timeSpawnEgg;
    private int numEgg;
    private bool spawningEgg = false;
    private float tmp_timeSwap_LR, tmp_timeSwap_UD;
    private float direction_LR = 1;
    private float direction_UD = 1;
    // Start is called before the first frame update
    void Start()
    {
        tmp_timeSwap_LR = timeSwap_LR; 
        tmp_timeSwap_UD = timeSwap_UD;
        healBarBoss.value = 50;
        timeSpawnEgg = 5;
        numEgg = Random.Range(5,10);
    }

    // Update is called once per frame
    void Update()
    {
        timeSwap_LR -= Time.deltaTime;
        timeSwap_UD -= Time.deltaTime;
        timeSpawnEgg -= Time.deltaTime;
        if (timeSpawnEgg <= 0 && !spawningEgg)
        {
            StartCoroutine(SpawnEgg());
        }
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

        transform.position += new Vector3(speed_LR * direction_LR * Time.deltaTime, 0, 0);
        transform.position += new Vector3(0, speed_UD * direction_UD * Time.deltaTime, 0);

    }

    IEnumerator SpawnEgg()
    {
        spawningEgg = true;

        numEgg = Random.Range(5, 10);

        for (int i = 0; i < numEgg; i++)
        {
            Instantiate(
                eggLv3,
                transform.position,
                Quaternion.identity
            );

            yield return new WaitForSeconds(0.2f);
        }

        timeSpawnEgg = 5;

        spawningEgg = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            healBarBoss.value--;
            Destroy(collision.gameObject);
            if(healBarBoss.value == 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
