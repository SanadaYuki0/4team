using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EzySlice;


public class SwordCutter : MonoBehaviour
{
    GameObject target;
    public Material capMaterial;
    [SerializeField] float force;

    private void Awake()
    {
        enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        //測試是否有碰撞到
        Debug.Log(other.collider.gameObject.name);

        target = other.collider.gameObject;
        Vector3 swordWorldPosition = gameObject.transform.position;
        Vector3 swordWorldDirection = gameObject.transform.up;
        SlicedHull hull = target.Slice(swordWorldPosition, gameObject.transform.up, capMaterial);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateLowerHull(target, capMaterial);
            GameObject lowerHull = hull.CreateUpperHull(target, capMaterial);

            target.SetActive(false);
            upperHull.AddComponent<Rigidbody>().AddForce(transform.forward * force);
            lowerHull.AddComponent<Rigidbody>();

            //加入Collider避免穿過地板
            upperHull.AddComponent<BoxCollider>();
            lowerHull.AddComponent<BoxCollider>();


        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     target = other.gameObject;
    //     Debug.Log(other.gameObject.name);
    //     Vector3 swordWorldPosition = gameObject.transform.position;
    //     Vector3 swordWorldDirection = gameObject.transform.forward;
    //     SlicedHull hull = target.Slice(swordWorldPosition, swordWorldDirection, capMaterial);

    //     if (hull != null)
    //     {
    //         hull.CreateLowerHull(target, capMaterial);
    //         hull.CreateUpperHull(target, capMaterial);

    //         target.SetActive(false);
    //     }
    // }

}

