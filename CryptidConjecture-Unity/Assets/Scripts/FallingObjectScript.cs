using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{

  private float yCurr = 0f;
  private float xCurr = 0f;

  private float xMax = 7f;
  private float yMax = 4.5f;
  private float zMax = 6.0f;

  private float xMin = -8f;
  private float yMin = -3.5f;
  private float zMin = 3.0f;

  private Quaternion rotStart = Quaternion.Euler(0, 0, 0);
  private Quaternion rotCurr = Quaternion.Euler(0, 0, 0);

  public float yeetAmounty = 0.01f;
  public float yeetAmountx = 0.01f;
  private bool returne = false;
  private bool pause = false;

  private float rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
      rotateAmount = Random.Range( 0.05f, 1f );
      yCurr = this.transform.position.y;
      xCurr = this.transform.position.x;

    }

    IEnumerator Pause()
    {
      pause = true;
      float waittime = Random.Range( 0.5f, 5.0f );
      yield return new WaitForSeconds(waittime);
      pause = false;
    }

    void Spawn(){
      this.transform.rotation = rotStart;
      rotCurr = rotStart;
      Vector3 loc = Vector3.zero;
        loc.x = Random.Range( xMin, xMax );
        loc.y = yMax;
        loc.z = Random.Range( zMin, zMax );

        this.transform.position = loc;
        yCurr = loc.y;
        xCurr = loc.x;
    }



        // Update is called once per frame
        void FixedUpdate()
        {
          if (pause == false){

          if ((yCurr <= yMin) || (xCurr <= xMin) ){
            returne = true;
          } // fin

          if (returne == false){
              this.transform.position = new Vector3(this.transform.position.x-yeetAmountx, this.transform.position.y-yeetAmounty, this.transform.position.z);
              rotCurr = rotCurr * Quaternion.Euler(0, 0, rotateAmount);
              this.transform.rotation = rotCurr;
              xCurr -= yeetAmountx;
            yCurr -= yeetAmounty;
          } // fin

          else if (returne == true){
            StartCoroutine(Pause());
            Spawn();
            returne = false;
          } // fin
        }

        } // fixed update
}
