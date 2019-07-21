using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1 : MonoBehaviour
{
    public float reswanDelay;
    public star player;
    public int gold;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<star>();
        goldText.text = "Gold: "+ gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void respawn(){
        StartCoroutine ("respawnRoutine");
    }
    public IEnumerator respawnRoutine (){
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(reswanDelay);
        player.transform.position = player.respawnPoint.transform.position;
        player.gameObject.SetActive(true);
    }
    public void addGold(int numberOfGold){
        gold += numberOfGold;
        goldText.text = "Gold: "+ gold;
    }
}
