using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Gun : MonoBehaviour
{
    [SerializeField] float velocity = 10;
    [SerializeField]GameObject projectile;
    [SerializeField]Transform firePoint;

    private void Update()
    {
        Rotate();
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("shoot");
            Shoot();
        }
    }

    private void Rotate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - pos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - pos;
        GameObject clone = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(direction.normalized * velocity, ForceMode2D.Impulse);
    }
}
