using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject tokenParticle;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slice"))       //If gameobject collides with an Slice
            collision.gameObject.GetComponent<Slice>().CreateSlice();       //Cuts the Slice

        else if (collision.gameObject.CompareTag("Token"))       //If gameobject collides with an Token
        {
            if (collision.gameObject.GetComponent<Renderer>().enabled)      //If the renderer of the Token is enabled
            {
                collision.gameObject.GetComponent<Renderer>().enabled = false;      //Disables the renderer of the Token
                Destroy(Instantiate(tokenParticle, collision.gameObject.transform.position, Quaternion.identity), 1.3f);        //Spawns a tokenparticle and destroys it after x seconds
                FindObjectOfType<ScoreManager>().IncrementToken();      //Increments count of token
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))       //If gameobject collides with an Obstacle
            FindObjectOfType<GameManager>().EndPanelActivation();       //Game is over
    }
}
