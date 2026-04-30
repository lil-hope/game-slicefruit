using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Animation knifeAnim;

    void Start()
    {
        knifeAnim = GetComponent<Animation>();      //Initializes the animation
    }

    public void KnifeCheck()
    {
        FindObjectOfType<KnifeMovement>().ResetPosition();      //Resets the position of the Knife to the starting position

        for (int i = 0; i < transform.GetChild(0).childCount; i++)      //Selects Knife skin
        {
            if (i != PlayerPrefs.GetInt("Skin", 0))
                transform.GetChild(0).GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
            else
                transform.GetChild(0).GetChild(i).gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))        //If player presses the screen/clicks with mouse
            knifeAnim.Play();       //Plays animation of the Knife
    }
}
