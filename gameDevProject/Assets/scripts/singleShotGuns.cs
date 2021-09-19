using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleShotGuns : gun
{
    [SerializeField] Camera cam;
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    public override void use()
    {
        shoot();
    }
    void shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<iDamagable>()?.takeDamage(((gunInfo)itemInfo).damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, hit.point);
        }
    }
    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if(colliders.Length!=0)
        {
            GameObject bullectImpactObj = Instantiate(bullentIMpactPrefab, hitPosition, Quaternion.identity);
            bullectImpactObj.transform.SetParent(colliders[0].transform);
            Destroy(bullectImpactObj, 10f);

        }
;
    }
}
