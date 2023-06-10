using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] Camera cam;
    [SerializeField] GameObject pfBullet1;
    [SerializeField] GameObject bulletStorage;
    [SerializeField] Transform shootPos;

    bool canShoot = true;

    void Start()
    {
        
    }

    void Update()
    {
        AimAndShoot();
    }

    void AimAndShoot()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - weapon.transform.position.y, mousePos.x - weapon.transform.position.x)*Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(ShootingCooldown());
            GameObject bullet = Instantiate(pfBullet1, shootPos.transform.position, weapon.transform.rotation, bulletStorage.transform);
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(5,0), ForceMode2D.Impulse);
            Destroy(bullet, 10);
        }
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(GameManager.Instance.attackSpd);
        canShoot = true;
    }
}
