using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onscreenDelay = 3f;
    private Collider _playerCol;
    // Update is called once per frame
    private void Start()
    {
        _playerCol = GameObject.Find("Player").GetComponent<Collider>();
        Physics.IgnoreCollision(_playerCol, this.gameObject.GetComponent<Collider>());
    }
    void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
        }
    }
}
