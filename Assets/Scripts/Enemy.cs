using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;

    private void Start()
    {
        _speed = GetRandomSpeed();
        StartCoroutine(ChangeDirection());
    }

    private void Update() => transform.Translate(_speed * Time.deltaTime * _direction);

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            _direction = GetRandomDirection();
            yield return GetWaitForRandomSeconds();
        }
    }

    private Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1, 2);
        float y = Random.Range(-1, 2);
        return new Vector3(x, y, 0f);
    }

    private float GetRandomSpeed() => Random.Range(0.2f, 1.5f);

    private WaitForSeconds GetWaitForRandomSeconds() => new WaitForSeconds(Random.Range(0.1f, 2f));
}