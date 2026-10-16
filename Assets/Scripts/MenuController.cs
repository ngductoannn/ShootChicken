using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("Bf_Lv1");
    }
    public void toIntroduce()
    {
        SceneManager.LoadScene("Introduce");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
