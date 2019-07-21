using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eplosion_candy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    void Start()
    {
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        star player = col.GetComponent<star>();
        if (col.gameObject.tag =="character"){
            Debug.Log ("destination hit");
            explosion.SetActive(true);
            Destroy(gameObject);
        }
    }
}
