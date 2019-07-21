using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public float speed;
    public float jump;
    float movementSpeed;
    public bool onGround = false;
    Animator playerAnimation;
    public GameObject respawnPoint;
    public GameObject teleDestination;
    public level1 manager;
    Vector3 scaleTmp;
    // Update is called once per frame

    private void Start() {
        playerAnimation = GetComponent<Animator>();
        manager = FindObjectOfType<level1>();
        scaleTmp = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround){
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        movementSpeed = 0;
        if (Input.GetKeyDown(KeyCode.A)){
            movementSpeed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 
                                                GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector2(-0.3488778f, 0.334306f);
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            movementSpeed = speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 
                                                GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector2(0.3488778f, 0.334306f);

        }
        playerAnimation.SetFloat("speed", Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x));
        //transform.localScale = transform.localScale;
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag =="static_ground" || col.gameObject.tag == "moving_ground" || col.gameObject.tag.Equals("ice_ground")){
            Debug.Log("Hit Ground");
            onGround = true;
        }
        if (col.gameObject.tag.Equals("ice_ground")){
            movementSpeed = movementSpeed*2;
        }
        if (col.gameObject.tag == "moving_ground"){
            
            transform.SetParent(col.transform);
            //transform.localScale = new Vector3 (scaleTmp.x, scaleTmp.y, scaleTmp.z);
            //transform.localScale = new Vector3 (1/col.transform.localScale.x, 1/col.transform.localScale.y, 1/col.transform.localScale.z);
            transform.localScale = new Vector3 (scaleTmp.x/transform.parent.transform.localScale.x, 
                                                scaleTmp.y/transform.parent.transform.localScale.y, 
                                                scaleTmp.z/transform.parent.transform.localScale.z);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag.Equals("static_ground") || col.gameObject.tag.Equals("moving_ground") || col.gameObject.tag.Equals("ice_ground")){
            onGround = false;
        }
        if (col.gameObject.tag.Equals("ice_ground")){
            movementSpeed = movementSpeed/2;
        }
        if (col.gameObject.tag == "moving_ground"){
            transform.SetParent(null);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag.Equals("enemy")){
            Debug.Log("enemy hit");
            //transform.position = new Vector2 (respawnPoint.transform.position.x,
            //                                    respawnPoint.transform.position.y);
            manager.respawn();
        }
        if (col.gameObject.tag.Equals("moving_ground"))
        {
            //transform.position = new Vector2 (col.transform.position.x, col.transform.position.y);
        }
        if (col.gameObject.tag.Equals("teleport_gate"))
        {
            Debug.Log ("hit gate");
            transform.position = new Vector2 (teleDestination.transform.position.x,
                                                teleDestination.transform.position.y);
        }
        if (col.gameObject.tag.Equals("explosion_candy"))
        {
            //kill all monster
        }
        
    }

}
