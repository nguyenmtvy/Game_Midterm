using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject iceGround;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine (stopExploting ());
    }
    private IEnumerator stopExploting() {
         yield return new WaitForSeconds (0.20f);
         Destroy (gameObject);
        iceGround.SetActive(false);
     }
}
