using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.5f; // speed of the ball moving..
    private Rigidbody playerRb; // Rigidbody of player..
    private GameObject focalPoint; // a variable for our focalpoint gameobject..

    public bool hasPowerup = false; // bool variable for powerup confirmation

    private float powerupStrength = 15; // Strength of the powerup
    private float cooldownTime = 7.5f; // Cooldown time for powerup

    public GameObject powerupIndicator; // Powerup Indicator's gameobject..

    private Vector3 offset = new Vector3(0, -0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Initialize Rigidbody variable..
        focalPoint= GameObject.Find("Focal Point"); // then we initialize focal point GO here..
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // gets vertical input to move forward..

        // adds force to move forward at a certain speed.. // * we replace Vector3.forward w/ focalpoint's forward coordinates..
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed); 

        powerupIndicator.transform.position = transform.position + offset; // sets indicator's position to player's position w/ little offset.
    }

    private void OnTriggerEnter(Collider other) // When ball collides with the Powerup.. 
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true); // Turn on when we collide w/ powerup.
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        hasPowerup = false;
        powerupIndicator.SetActive(false); // Turn off when timer hits zero.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>(); // RigidBody for Enemy
            
            // enemy moving opposite the player's pos.
            Vector3 awayfromthePlayer = (collision.gameObject.transform.position - transform.position); 

            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            // When player acquires the powerup this line will send the enemy opposite of player's direction..
            enemyRigidBody.AddForce(awayfromthePlayer * powerupStrength, ForceMode.Impulse); 
        }
    }
}
