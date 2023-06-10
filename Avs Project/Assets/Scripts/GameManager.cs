using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int bulletDamage = 2;
    public int criticalDamage = 200;
    public float criticalChance = 50;
    public int bulletPierce = 1;
    public float playerMoveSpd = 3;
    public float attackSpd = 1f;
    public float bulletSpd = 30f;
    public int playerHealth = 4;
    public Transform pfDamagePopup;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
