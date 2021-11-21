using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public void Spawn(Enemy enemy) => Instantiate(enemy, transform.position, Quaternion.identity);
}