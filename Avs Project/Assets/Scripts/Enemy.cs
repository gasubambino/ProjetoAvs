using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public EnemyObject enemySettings;
    private int hp;
    private float spd;

    //flash when hit, variables
    public Material flashMaterial;
    private Material originalMaterial;
    private float flashDuration = 0.1f;

    private void Start()
    {
        spd = enemySettings.spd;  
        hp = enemySettings.hp;

        //material to set the flash system
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");//sets the player
        Vector2 direction = player.transform.position - transform.position;//sets the direction towards the player.
        //makes the enemy follow the player with the spd set on the scriptable object
        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, spd * Time.deltaTime);

        //facing
        Vector2 facing = (player.transform.position - transform.position);
        if (facing.x > 0f)
        {
            this.transform.localScale = new Vector2(-1, 1);//turns left
        }
        else if (facing.x < 0f)
        {
            this.transform.localScale = new Vector2(1, 1);//turns right
        }        

    }
    public void TakeDamage(int damage) //the enemy took damage:
    {
        hp -= damage; //reduces the enemy's hp by the player's damage amount
        if(hp <= 0)//if hp less or equals to zero
        {
            Destroy(gameObject);
        }
    }

    //flash when hit coroutine. changes the material to a white one, after flash duration the material resets.
    public void StartFlashCoroutine()
    {
        StartCoroutine(FlashCoroutine());
    }
    private IEnumerator FlashCoroutine()
    {
        GetComponent<Renderer>().material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        GetComponent<Renderer>().material = originalMaterial;
    }

}
