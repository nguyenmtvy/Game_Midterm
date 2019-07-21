
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    public int goldValue = 10;
    level1 manager;

    //public GameItem item;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<level1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        star player = col.GetComponent<star>();
        if (col.gameObject.tag =="character"){
            Debug.Log ("gold hit");
            manager.addGold(goldValue);
            Destroy(gameObject);
        }
    }
}
