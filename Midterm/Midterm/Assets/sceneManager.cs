using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void level1(){
        SceneManager.LoadScene("level01");
    }
    public void level001(){
        SceneManager.LoadScene("level001");
    }
    public void ReturnMenu(){
        SceneManager.LoadScene("menu");
    }
}
