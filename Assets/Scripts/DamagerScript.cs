using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    [SerializeField] float delta = 1.5f;  // Amount to move left and right from the start point
    [SerializeField] float speed = 0;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            gameManager.StartCoroutine("Wait");
        }
    }
}
