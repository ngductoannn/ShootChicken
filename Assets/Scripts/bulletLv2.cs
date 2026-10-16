using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletLv2 : MonoBehaviour
{
    public playerLv2 playerlv2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime*1*8f, 0);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deleteBullet")
        {
            Destroy(gameObject);    
            playerlv2.missBullet();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("BF_Lv3");
        }
    }
}
