using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float movementSpeed, timeBetweenShoot, shootSpeed, enemyHealth;
    private float ShootTime;
    Rigidbody enemyRb;
    private void Start()
    {
        ShootTime = timeBetweenShoot;
        enemyRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ShootTime -= Time.deltaTime * shootSpeed;
        if (ShootTime <= 0)
        {
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            ShootTime = timeBetweenShoot;
        }
        if (transform.position.z <= -20)
        {
            Destroy(this.gameObject);
        }
        if (enemyHealth <= 0)
        {
            GameManager.score++;//ölünce skoru 1 arttýr
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector3(enemyRb.velocity.x, enemyRb.velocity.y, -movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet_P"))
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
