using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _explosionRAdius;
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCast();
        }
    }

    private void RayCast()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, 2000))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                cube.Destroy();
            }
            Explosion(hit.point);
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
                    cube.GetComponent<Rigidbody>().AddExplosionForce(1000f, point, _explosionRAdius);
                }
                else
                {
                    cube.Destroy();
                }
            }
        }
    }
}
