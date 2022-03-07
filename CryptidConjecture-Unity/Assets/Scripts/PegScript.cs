/*
 * Created by: Haley Kelly
 * Date Created: 2/23/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 2/23/2022
 *
 * Description: Script that controls pegs for Cryptid Conjecture.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{

  public Material Barrier2;
  public Material Barrier3;

  public GameObject mainCamera;

    private int health = 1;

    private int yPosCurr = 0;
    public int yPosMax = 100;
    private float yeetAmount = 0.1f;
    private bool reverse = false;

    private Vector3 startPos;
    private float am;

    private Rigidbody rb;

    void Start()
    {

      startPos = transform.position;
       rb = GetComponent<Rigidbody>();

      if (gameObject.transform.CompareTag("barrierpeg")){
        health = 3;
        yeetAmount = 0.005f;
        yPosMax = 100;
      } // yeets a little; health == 3
      else if (gameObject.transform.CompareTag("normalpeg")){
        health = 1;
        yeetAmount = 0.005f;
        yPosMax = 100;
      } // yeets a little; health == 1
      else if (gameObject.transform.CompareTag("fireflypeg")){
        health = 1;
        yeetAmount = 0.01f;
      } // set yPosMax custom in editor; yeets a lot; health == 1
    } // start fin

    void FixedUpdate() {
      if (yPosCurr >= yPosMax){
        reverse = true;
      } // fin

      else if (yPosCurr <= 0){
        reverse = false;
      } // fin

      if (reverse == false){
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+yeetAmount, this.transform.position.z);
        yPosCurr ++;
      } // fin

      else if (reverse == true){
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-yeetAmount, this.transform.position.z);
        yPosCurr --;
      } // fin

    } // fixed update

    void OnCollisionEnter(Collision other){
      if (other.transform.CompareTag("Ball")){

      if (gameObject.transform.CompareTag("normalpeg")){
        health --;
        if (health == 0){
          mainCamera.GetComponent<RegionScript>().score ++;
          Destroy(gameObject);
        } // health is 0
      } // normal peg

      else if (gameObject.transform.CompareTag("fireflypeg")){
        health --;
        if (health == 0){
          mainCamera.GetComponent<RegionScript>().score ++;
          Destroy(gameObject);
        } // health is 0
      } // firefly peg

      else if (gameObject.transform.CompareTag("barrierpeg")){
        health --;
        if (health == 2){
          gameObject.GetComponent<MeshRenderer>().material = Barrier2;
        } // health is 2
        if (health == 1){
          gameObject.GetComponent<MeshRenderer>().material = Barrier3;
        } // health is 1
        if (health == 0){
          mainCamera.GetComponent<RegionScript>().score ++;
          Destroy(gameObject);
        } // health is 0
      } // barrier peg
    } // ball hit a peg
    } // on collision enter
}
