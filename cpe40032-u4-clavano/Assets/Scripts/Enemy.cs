using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f; // Speed the enemy ball is moving..
    private Rigidbody enemyRb; // In reference to the enemy's rigidbody..
    private GameObject player; // the player gameobject..

    private float yBoundary = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Then we initialize enemyRb & player here..
        enemyRb = GetComponent<Rigidbody>(); 
        player = GameObject.Find("Player");



    }

    // Update is called once per frame
    void Update()
    {
        // Here is where we declare a new Vector 3--lookDirection variable
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;


        enemyRb.AddForce(lookDirection * speed);

        // When enemy passes boundary destroy object..
        if (transform.position.y < -yBoundary)
        {
            Destroy(gameObject);
        }
    }
}
