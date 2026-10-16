using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLv1 : MonoBehaviour
{
    public float speed;
    public GameObject bulletLv1;
    public float timeFire;
    private float tmp_timeFire;
    private int num_bullet = 5;
    // Start is called before the first frame update
    void Start()
    {
        tmp_timeFire = timeFire;
        timeFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeFire -= Time.deltaTime;
        Vector3 potision = transform.position;
        if (Input.GetKey(KeyCode.A) && potision.x > -7.1)
        {
            transform.Translate(new Vector3(speed*-1*Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) && potision.x < 7.1)
        {
            transform.Translate(new Vector3(speed*1*Time.deltaTime, 0, 0));
        }
         if (Input.GetKey(KeyCode.W) && potision.y < -2)
        {
            transform.Translate(new Vector3(0, speed*1*Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S) && potision.y > -3.15)
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
            bulletLv1,
            transform.position,
            Quaternion.identity
        );

        bullet.GetComponent<bulletLv1>().playerlv1 = this;
    }

    public void missBullet()
    {
        num_bullet--;
        if(num_bullet <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
    
}

