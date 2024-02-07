using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    Rigidbody rb;
    public GameObject astroids;
    public Transform astroidP;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(100f,-100f),0, Random.Range(100, -100)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {   
       
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "lazer")
        {
            if(astroids != null) { 
                for(int i = 0; i < 2; i++) {
                    Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
                }

            }

        }
        Destroy(gameObject);
    }
}
