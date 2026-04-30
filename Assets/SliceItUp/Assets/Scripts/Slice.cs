using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public GameObject sliceParticle;

    private bool sliced = false;

    public void CreateSlice()
    {
        if (!sliced)
        {
            sliced = true;
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().AddForce(new Vector3(1f, 1f, 1f) * Random.Range(-1f, 1f));
            Destroy(Instantiate(sliceParticle, transform.position, Quaternion.identity), 1.2f);
            FindObjectOfType<ScoreManager>().IncrementScore();
            FindObjectOfType<LevelManager>().UpdateGoalFillAmout();
        }
    }
}
