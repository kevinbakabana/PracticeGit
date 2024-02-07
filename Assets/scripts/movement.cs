using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class movement : MonoBehaviour
{
    //dit is het punt van waar je objecten komen
    public Transform attackPoint;

    //dit is het object wat je schiet
    public GameObject objectToThrow;
    public GameObject lazer;

    //dit zij de variabele voor het schieten
    public float throwCooldown;
    public float throwForce;
    bool readyToThrow;

    //dit is het code key die je moet intoesten voor het schieten
    public KeyCode throwKey = KeyCode.Mouse0;
    public KeyCode lazerKey = KeyCode.Mouse1;

    //dit is het draai snelheid
    [SerializeField]public float torque;

    //dit is voor je snellheid van beweging
    [SerializeField]public float thrust;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
       rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(lazerKey))
        {
            Lazer();
        }
        

        if (Input.GetKeyDown(throwKey) && readyToThrow == true) 
        {
            Throw();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float turn = Input.GetAxisRaw("Horizontal");
        rb.AddTorque(transform.up * torque * turn);

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Debug.Log(thrust);
            rb.AddRelativeForce(Vector3.forward * thrust);
            
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.AddRelativeForce(Vector3.right * thrust);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.AddRelativeForce(Vector3.left * thrust);
        }


    }
    private void Throw()
    {
        readyToThrow = false;
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, attackPoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = attackPoint.transform.forward;

        Invoke(nameof(ResetThrow), throwCooldown);
    }
    private void ResetThrow()
    {
        readyToThrow = true;
    }
    
    private void Lazer()
    {
        Debug.Log("lazer");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
        Debug.DrawRay(transform.position, transform.forward *100);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();
            if (rend)
            {
                rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                tempColor.a = 0.3f;
                rend.material.color = tempColor;
                Destroy(rend.gameObject);
               
            }
        }
    }

}
