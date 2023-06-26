using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    Rigidbody enemyBulletRb;
    private void Start()
    {
        enemyBulletRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        enemyBulletRb.velocity = Vector3.back * bulletSpeed;
        Destroy(this.gameObject, 2);
    }
}
