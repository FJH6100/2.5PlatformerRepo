using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 1f;
    private bool _movingBack;
    // Start is called before the first frame update
    void Start()
    {
        _movingBack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_movingBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
            if (transform.position == _targetA.position)
            {
                _movingBack = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
            if (transform.position == _targetB.position)
            {
                _movingBack = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = this.gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}
