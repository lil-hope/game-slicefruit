using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Knife"))       //If KnifeBox collides with the Knife
        {
            FindObjectOfType<Knife>().enabled = false;
            FindObjectOfType<KnifeMovement>().enabled = false;
            other.GetComponent<Animation>().Play();
            GetComponent<Animator>().enabled = true;
            FindObjectOfType<GameManager>().Invoke("ClearedPanelActivation", 1.3f);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
            FindObjectOfType<AudioManager>().ClearedSound();
        }
    }
}
