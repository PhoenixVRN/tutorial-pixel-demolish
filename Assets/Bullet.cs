using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _explosionRAdius;

    void Start()
    {
        Invoke("DestroyObj", 3f);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Cube cube))
        {
            if (!cube.Detouched)
            {
                // cube.Destroy();
            }

            Explosion(other.contacts[0].point);
        }
    }

    private void Explosion(Vector3 point)
    {
        var colliders = Physics.OverlapSphere(point, _explosionRAdius);
        foreach (var colliser in colliders)
        {
            if (colliser.TryGetComponent(out Cube cube))
            {
                if (!cube.Detouched)
                {
                    cube.Detouch();
                    cube.GetComponent<Rigidbody>().AddExplosionForce(2000f, point, _explosionRAdius);
                }
                else
                {
                    // cube.Destroy();
                }
            }
        }
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}