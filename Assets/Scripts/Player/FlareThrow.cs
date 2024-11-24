using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlareThrow : MonoBehaviour
{
    public float rechargeTime;
    public float throwForce;
    [Header("Unity Set Up")]
    public GameObject flarePrefab;
    public Transform cam;
    public Transform spawnPos;

    private float rechargeTimer;
    private GameObject previousFlare;

    public float PercentCharged{
        get{ return rechargeTimer / rechargeTime; }
    }

    private void Awake() => rechargeTimer = rechargeTime;
    

    private void Update() => DoTimer();
    

    private void DoTimer(){
        rechargeTimer += Time.deltaTime;
        rechargeTimer = Mathf.Clamp(rechargeTimer, 0, rechargeTime);
    }

    public void TryThrow(){
        // don't do anything if not charged
        if(PercentCharged != 1){
            return;
        }

        // Then do the thing tuah~
        Destroy(previousFlare);
        rechargeTimer = 0;
        previousFlare = Instantiate(flarePrefab, spawnPos.position, Quaternion.identity);
        previousFlare.GetComponent<Rigidbody>().AddForce(cam.forward * throwForce, ForceMode.Impulse);
    }
}
