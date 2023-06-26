using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    private Rigidbody Rb;


    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 3f);//iki saniye sonra yok et
    }


    void Update()
    {
        Rb.velocity = Vector3.forward * speed;
    }

}
