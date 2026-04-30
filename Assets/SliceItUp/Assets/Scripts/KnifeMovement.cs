using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public float movementSpeed;

    private Vector3 nextPos, startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        //Makes the knife move further
        nextPos = transform.position;
        nextPos.z += movementSpeed * Time.deltaTime;
        transform.position = nextPos;
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}
