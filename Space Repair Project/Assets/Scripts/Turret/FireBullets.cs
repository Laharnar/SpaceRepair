using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform bulletPrefab;
    public Transform spawnPoint;
    public Vector2 targetDirection;

    private void Start()
    {
        StartCoroutine(FiringLogic());
    }

    private IEnumerator FiringLogic()
    {
        while (true)
        {
            if (fireRate <= 0)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(fireRate);
                Transform t = Instantiate(
                    bulletPrefab,
                    spawnPoint.transform.position, 
                    Quaternion.Euler(targetDirection));
                t.up = targetDirection;
            }
        }
    }
}
