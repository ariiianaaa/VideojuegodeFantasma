using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public bool isunlocked = true;
    public float speed = 1f;
    public Transform opentransform; 
    public Transform closetransform;

    Vector3 targetPosition;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = closetransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isunlocked && door.position != targetPosition)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, time);
            time = Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            targetPosition = opentransform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            targetPosition = closetransform.position;
        }
    }


}
