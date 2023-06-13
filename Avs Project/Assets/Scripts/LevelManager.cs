using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.XPath;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public UIManager manager;

    public static int playerLevel = 1;
    public static int playerXp = 0;
    public static int playerXpCeiling = 10;

    void Update()
    {

    }

    public void LevelUp()
    {
        //manager.PauseGame();
        //playerLevel++;
    }

    //void Shoot2()
    //{
    //    GameObject bullet1 = Instantiate(bulletPrefab, shootPos.transform.position, transform.rotation);
    //    Rigidbody2D bulletRb1 = bullet1.GetComponent<Rigidbody2D>();

    //    GameObject bullet2 = Instantiate(bulletPrefab, shootPos.transform.position, transform.rotation);
    //    Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();

    //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2 direction = (mousePosition - transform.position).normalized;

    //    float angleOffset1 = 14f; // Ângulo de desvio desejado para o primeiro tiro em graus
    //    float angleOffset2 = -14f; // Ângulo de desvio desejado para o segundo tiro em graus

    //    // Calcular o ângulo com o desvio para o primeiro tiro
    //    float angle1 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //    // Adicionar o desvio ao ângulo para o primeiro tiro
    //    float angleWithOffset1 = angle1 + angleOffset1;

    //    // Converter o ângulo com desvio de volta para radianos para o primeiro tiro
    //    float angleRad1 = angleWithOffset1 * Mathf.Deg2Rad;

    //    // Calcular a direção com desvio para o primeiro tiro
    //    Vector2 directionWithOffset1 = new Vector2(Mathf.Cos(angleRad1), Mathf.Sin(angleRad1));

    //    // Calcular o ângulo com o desvio para o segundo tiro
    //    float angle2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //    // Adicionar o desvio ao ângulo para o segundo tiro
    //    float angleWithOffset2 = angle2 + angleOffset2;

    //    // Converter o ângulo com desvio de volta para radianos para o segundo tiro
    //    float angleRad2 = angleWithOffset2 * Mathf.Deg2Rad;

    //    // Calcular a direção com desvio para o segundo tiro
    //    Vector2 directionWithOffset2 = new Vector2(Mathf.Cos(angleRad2), Mathf.Sin(angleRad2));

    //    bulletRb1.velocity = directionWithOffset1.normalized * GameManager.Instance.bulletSpd;
    //    bulletRb2.velocity = directionWithOffset2.normalized * GameManager.Instance.bulletSpd;
    //}
}
