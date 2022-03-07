using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{

  private float yCurr = 0f;
  private float xCurr = 0f;

  private float xMax = 14f;
  private float yMax = 4.5f;
  private float zMax = 6.0f;

  private float xMin = -8f;
  private float yMin = -3.5f;
  private float zMin = 3.0f;

  public float yeetAmounty = 0.01f;
  public float yeetAmountx = 0.01f;
  private bool returne = false;
  private bool pause = false;


    // Start is called before the first frame update
    void Start()
    {
      yCurr = this.transform.position.y;
      xCurr = this.transform.position.x;

    }

    IEnumerator Pause()
    {
      pause = true;
      float waittime = Random.Range( 0.1f, 0.3f );
      yield return new WaitForSeconds(waittime);
      pause = false;
    }

    void Spawn(){
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
