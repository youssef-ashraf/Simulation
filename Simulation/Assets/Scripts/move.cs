using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {

            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {

            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * -speed));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, -50, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, 50, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }






        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
    }

}
