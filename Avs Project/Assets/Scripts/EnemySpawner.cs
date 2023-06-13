using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform target; //reference to the object the spawner will orbitate
    public float orbitSpeed = 5.0f; 
    public float orbitRadius = 2.0f; 
    public float initialAngleOffset = 0.0f; //initial angle, 0, 90, 180

    private void Update()
    {
        float angle = (Time.time * orbitSpeed) + initialAngleOffset;
        Vector3 orbitPosition = target.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * orbitRadius;

        transform.position = orbitPosition;
    }
}
