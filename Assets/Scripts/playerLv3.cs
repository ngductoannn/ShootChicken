using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLv3 : MonoBehaviour
{
    public float speed;
    public GameObject bulletLv3;
    public float timeFire;
    private float tmp_timeFire;
    public float timeSpawnEnemy;
    public GameObject enemylv3;
    // Start is called before the first frame update
    void Start()
    {
        tmp_timeFire = timeFire;
        timeFire = 0;
        timeSpawnEnemy = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeFire -= Time.deltaTime;
        Vector3 potision = transform.position;
        timeSpawnEnemy -= Time.deltaTime;
        if(timeSpawnEnemy <= 0)
        {
            Instantiate(enemylv3, new Vector3(Random.Range(-7.5f, 7.5f), 6.15f, 0), Quaternion.identity);
            timeSpawnEnemy = Random.Range(1,3);
        }
        if (Input.GetKey(KeyCode.A) && potision.x > -7.88)
        {
            transform.Translate(new Vector3(speed*-1*Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) && potision.x < 7.85)
        {
            transform.Translate(new Vector3(speed*1*Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.W) && potision.y < -2.98)
        {
            transform.Translate(new Vector3(0, speed*1*Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S) && potision.y > -4)
        {
            transform.Translate(new Vector3(0, speed*-1*Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && timeFire <= 0)
        {
            Fire();
            timeFire = tmp_timeFire;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(
            bulletLv3,
            transform.position,
            Quaternion.identity
        );

        // bullet.GetComponent<bulletLv1>().playerlv3 = this;
    }
}
