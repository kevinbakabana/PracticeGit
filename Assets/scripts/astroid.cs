using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    Rigidbody rb;
    public GameObject astroids;
    public Transform astroidP;
    public GameObject megumin;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(100f,-100f),0, Random.Range(100, -100)));
        rb.AddTorque(new Vector3(Random.Range(100f, -100f), 0, Random.Range(100, -100)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {   
       
        if (collision.gameObject.tag == "bullet")
        {
            if(astroids != null) { 
                for(int i = 0; i < 2; i++) {
                    Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
                }
            }
            GameObject meguMegu = Instantiate(megumin, astroidP.transform.position, Quaternion.identity);
            Destroy(meguMegu, 2f);
        }

        Destroy(gameObject);
    }
    public void Dynamite()
    {
        if (astroids != null)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(astroids, astroidP.transform.position, Quaternion.identity);
            }
        }
        GameObject meguMegu = Instantiate(megumin, astroidP.transform.position, Quaternion.identity);
        Destroy(meguMegu, 2f);
        Destroy(gameObject);
    }
}
