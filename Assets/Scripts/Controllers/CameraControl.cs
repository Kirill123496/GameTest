using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Transform _transform;

    private void Start()
    {
        _transform = _player.GetComponent<Transform>();
    }
    private void Update()
    {
        this.gameObject.transform.position = new Vector3(_transform.position.x, _transform.position.y + 6,_transform.position.z-6);
    }
}
