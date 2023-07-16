using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate;
    [SerializeField] Transform firePoint;

    public Transform FirePointTransform => firePoint.transform;
    private bool isFiring;

    public IEnumerator Shoot()
    {
        if (isFiring)
        {
            yield break;
        }

        isFiring = true;
        PhotonNetwork.Instantiate("Fireball", firePoint.position, FirePointTransform.rotation);
        yield return new WaitForSeconds(1 / fireRate);
        isFiring = false;
    }
}
