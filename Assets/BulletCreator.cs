using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _gun;
    [SerializeField] private Transform _bulletspawn;
    public int bulletAddVelocity;
    private int _velocity;
    private bool _isPress;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPress = true;
        }

        if (_isPress)
        {
            _velocity += bulletAddVelocity;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject newBullet = Instantiate(_bulletPrefab,transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * _velocity;
            _isPress = false;
            _velocity = 0;
        }
    }
}