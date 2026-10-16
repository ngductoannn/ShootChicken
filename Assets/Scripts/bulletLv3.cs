using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLv3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime*1*12f, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deleteBullet")
        {
            Destroy(gameObject);
        }
    }
}
