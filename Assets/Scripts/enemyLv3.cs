using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyLv3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 5 * Time.deltaTime * -1, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);   
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "home")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
