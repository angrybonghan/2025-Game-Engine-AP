using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float HP = 5f;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position);

        if(HP <=0 )
        {
            Destroy(gameObject);
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet1"))
        {
            HP--;
        }
        if (other.CompareTag("Bullet2"))
        {
            HP = -3;
        }

    }
}
