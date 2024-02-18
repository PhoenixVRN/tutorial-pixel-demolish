using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _gun;
    [SerializeField] private Transform _bulletspawn;
    [SerializeField] private Image _strangeImage;
    public int bulletAddVelocity;
    private int _velocity;
    public bool _isPress;
    private bool IsMobile;

    [SerializeField] private int _maxStrange;

    private void Start()
    {
        _strangeImage.fillAmount = 0;
        IsMobile = Application.isMobilePlatform;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        return; //TODO
        Debug.Log($"Context {context.phase}");
        if (context.started)
        {
            _isPress = true;
        }

        if (context.canceled)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
            _isPress = false;
            _velocity = 0;
            _strangeImage.fillAmount = 0;
        }
    }

    public void FireMobile()
    {
        _isPress = true;
    }

    public void FireMobileUp()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
        _isPress = false;
        _velocity = 0;
        _strangeImage.fillAmount = 0;
    }
    
    private void Update()
    {
        if (_isPress)
        {
            _velocity += bulletAddVelocity;
            _strangeImage.fillAmount = (float) _velocity / _maxStrange;
        }
    }
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         _isPress = true;
    //     }
    //
    //     if (_isPress)
    //     {
    //         _velocity += bulletAddVelocity;
    //         _strangeImage.fillAmount = (float) _velocity / _maxStrange;
    //     }
    //
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         GameObject newBullet = Instantiate(_bulletPrefab,transform.position, transform.rotation);
    //         newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
    //         _isPress = false;
    //         _velocity = 0;
    //         _strangeImage.fillAmount = 0;
    //     }
    // }
}