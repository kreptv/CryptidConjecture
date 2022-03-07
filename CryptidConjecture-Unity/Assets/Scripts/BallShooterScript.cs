/*
 * Created by: Haley Kelly
 * Date Created: 2/23/2022
 *
 * Last Edited by: N/A
 * Last Edited: 2/23/2022
 *
 * Description: Script that controls the ball shooter for Cryptid Conjecture.
                Adapted from Slingshot script in Mission Demolition.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooterScript : MonoBehaviour
{
    /** VARIABLES **/

    [Header("Set in Inspector")]
    public GameObject mainCamera;
    public GameObject prefabProjectile;
    public float velocityMultiplier = 100f;


    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRB;
    private Vector3 mouseDelta;


    private void Start(){
    }


    private void Awake()
    {
        Transform launchPointTrans = transform.Find("SpawnPoint");

        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }


    private void OnMouseEnter()
    {
        print("Slingshot: OnMouseEnter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        print("Slingshot: OnMouseExit");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
      if (!(GameObject.Find("BallPrefab(Clone)"))&&(mainCamera.GetComponent<RegionScript>().ballsRemaining > 0)){ // if there is no other ball on screen
        aimingMode = true; // while player is pushing down
            mainCamera.GetComponent<RegionScript>().ballsRemaining -= 1;
            projectile = Instantiate(prefabProjectile) as GameObject;
            projectile.transform.position = launchPos;
            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.isKinematic = true;
          }
    }

    private void OnMouseUp()
    {
      if (aimingMode == true){
        projectileRB.isKinematic = false;
        projectileRB.velocity = -mouseDelta * velocityMultiplier; // velocity x mousedelta
        aimingMode = false;
      }
    }

    // Update is called once per frame
    private void Update()
    {

      if (aimingMode == true){

        // get current mouse position
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = 10000;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        mouseDelta = mousePos3D - launchPos; // amount of change between current mouse + launch

        // limit mouseDelta to slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); // sets the vector to the same direction, but length is 1.0
            mouseDelta *= maxMagnitude;
        }

        // move projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

      } // aiming


    }
}
