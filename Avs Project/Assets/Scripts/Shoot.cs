using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class Shoot : MonoBehaviour
{
    //bullet life time
    public float lifeTime = 5f;
    //bullet penetration
    public int penetration;
    
    //camera shake properties
    private float magnitude = .5f;
    private float roughness = .4f;
    private float fadeInTime = .1f;
    private float fadeOutTime = .1f;
    
    void Start()
    {
        StartCoroutine(SelfDestruct());
        penetration = GameManager.Instance.bulletPierce;
    }
    IEnumerator SelfDestruct()//self destructs after life time
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int critDamage = 100;
        bool isCrit = false;
        if (GameManager.Instance.criticalChance >= Random.Range(0, 101))//if Critical damage
        {
            critDamage = GameManager.Instance.criticalDamage;
            isCrit = true;
        }
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(GameManager.Instance.bulletDamage*critDamage/100);
            DamagePopup.Create(new Vector3(transform.position.x,transform.position.y,0), GameManager.Instance.bulletDamage * critDamage / 100, isCrit);
            enemy.StartFlashCoroutine();
            
            //reduces the bullet penetration/hp
            penetration -= 1;
            if (penetration <= 0 ) //if bullet hp == 0
            {
                //camera shake
                //CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                Destroy(gameObject);
            }
        }
    }
}
