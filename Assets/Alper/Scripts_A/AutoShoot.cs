using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] private float playerHealth;
    [SerializeField] public GameObject gameover;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] guns;
    private int gunsIndex = 0;
    [SerializeField] private float timeBetweenShots;
    private float shotCounter;
    [SerializeField] private float shotSpeed;
    private void Start()
    {
        shotCounter = timeBetweenShots;
        gameover.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        shotCounter -= Time.deltaTime * shotSpeed;
        if (Input.GetMouseButton(0))
        {
            if (shotCounter <= 0)
            {
                //Instantiate(bulletPrefab, guns[gunsIndex].position, guns[gunsIndex].rotation);
                shotCounter = timeBetweenShots;
                if (gunsIndex == 0)//Tekli atış
                {
                    Instantiate(bulletPrefab, guns[0].position, guns[0].rotation);
                }
                if (gunsIndex == 1)//ikili atış
                {
                    Instantiate(bulletPrefab, guns[1].position, guns[1].rotation);
                    Instantiate(bulletPrefab, guns[2].position, guns[2].rotation);
                }
                /*
                if (gunsIndex == 2)
                {
                    Instantiate(bulletPrefab, guns[2].position, guns[2].rotation);
                    Instantiate(bulletPrefab, guns[1].position, guns[1].rotation); 
                    Instantiate(bulletPrefab, guns[0].position, guns[0].rotation);
                }
                */
            }
        }
        if (playerHealth<=0)
        {
            Debug.Log("Öldün");
            Time.timeScale = 0f;
            gameover.SetActive(true);
        }
        /*   if (gunsIndex >= 2)//Index i 3 olursa 0 a eşitle
           {
               gunsIndex = 0;
           }
   */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            StartCoroutine(PowerUpTime());
            Destroy(other.gameObject);//PowerUp ı yok et
            //gunsIndex++;
        }
        if (other.gameObject.CompareTag("Bullet_E"))
        {
            PlayerTakeDamage(20);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerTakeDamage(20);
            Destroy(other.gameObject);
        }
    }
    IEnumerator PowerUpTime()//PowerUp Süresi
    {
        gunsIndex = 1;
        yield return new WaitForSeconds(10);
        gunsIndex = 0;
    }
    public void PlayerTakeDamage(float takendamage)
    {
        playerHealth -= takendamage;
    }
    /*
    public ShootProfile shootProfile;
    public GameObject bulletPrefabs;
    public Transform firePoint;

    private float totalSpread;
    private WaitForSeconds rate, interval;

    private void OnEnable()
    {
        interval = new WaitForSeconds(shootProfile.interval);
        rate = new WaitForSeconds(shootProfile.fireRate);

        if (firePoint == null)
            firePoint = transform;

        totalSpread = shootProfile.spread * shootProfile.amount;
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }


    IEnumerator Shoot()
    {
        yield return rate;

        while (true)
        {
            float angle = 0f;

            for (int i = 0; i < shootProfile.amount; i++)
            {
                angle = totalSpread * (i / (float)shootProfile.amount);
                angle -= (totalSpread / 2f) - (shootProfile.spread / shootProfile.amount);

                Shooting(angle);

                if (shootProfile.fireRate > 0f)
                    yield return rate;
            }

            yield return interval;
        }
    }

    void Shooting(float angle)
    {
        GameObject temp = PoolMan.instance.UseObject(bulletPrefabs, firePoint.position, firePoint.rotation);
        temp.transform.Rotate(Vector3.up, angle);
    }
    */
}
