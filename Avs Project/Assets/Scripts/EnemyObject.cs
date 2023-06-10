using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemySettings", menuName = "Enemy/New Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public int hp;
    public float spd;
}
