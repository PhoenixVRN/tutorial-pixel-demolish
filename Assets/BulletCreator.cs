using System;
using TMPro;
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
    [SerializeField] private TMP_Dropdown _dropdown;
    public int bulletAddVelocity;
    private int _velocity;
    public bool _isPress;
    private bool IsMobile;

    [SerializeField] private int _maxStrange;

    private void Start()
    {
        _strangeImage.fillAmount = 0;
        IsMobile = Application.isMobilePlatform;
        _dropdown.options[0].text = 10.ToString();
        _dropdown.captionText.text = 10.ToString();
        _dropdown.options[1].text = 5.ToString();
        _dropdown.options[2].text = 1.ToString();
    }

    // public void Fire(InputAction.CallbackContext context)
    // {
    //    if (IsMobile) return;
    //     Debug.Log($"Context {context.phase}");
    //     if (context.started)
    //     {
    //         _isPress = true;
    //     }
    //
    //     if (context.canceled)
    //     {
    //         GameObject newBullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
    //         newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
    //         _isPress = false;
    //         _velocity = 0;
    //         _strangeImage.fillAmount = 0;
    //     }
    // }

    public void FireMobile()
    {
        if (!IsMobile && Input.GetMouseButtonDown(0))
            _isPress = true;
    }

    public void FireMobileUp()
    {
        if (_isPress)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
            _isPress = false;
            _velocity = 0;
            _strangeImage.fillAmount = 0;
        }
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