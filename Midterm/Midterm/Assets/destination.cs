using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destination : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject player;
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag =="character"){
            Debug.Log("destination");
            button.SetActive(true);
            player.SetActive(false);
        }
    }
}