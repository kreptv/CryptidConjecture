/*
 * Created by: Haley Kelly
 * Date Created: 2/16/2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 2/16/2022
 *
 * Description: Create trailing lines behind projectile. Recycled from MissionDemolition.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
  public GameObject BallShooterRotationAxis;

  static public ProjectileLine S; // singleton

  [Header("SET IN INSPECTOR")]
  public float minDist = 0.1f;

  private LineRenderer line;
  private GameObject _poi;
  private List<Vector3> points;

    private void Awake() {
      S = this;

      line = S.GetComponent<LineRenderer>();
      line.enabled = false;
      points = new List<Vector3>();

    }

    public GameObject poi {
      get {
        return(_poi);
      } // get
      set {
        _poi = value;
        if (_poi != null){
          line.enabled = false;
          points = new List<Vector3>();
          AddPoints();
        } // if
      } // set
    } // method

    public void Clear() {
      _poi = null;
      line.enabled = false;
      points = new List<Vector3>();
    }

    public void AddPoints(){
      Vector3 pt = _poi.transform.position;
      if (points.Count > 0 && (pt - lastPoint).magnitude < minDist) {
        return;
      }
      if (points.Count == 0){
        Vector3 launchPosDiff = pt - BallShooterRotationAxis.GetComponent<BallShooterScript>().launchPos;
        points.Add (pt + launchPosDiff);
        points.Add(pt);
        line.positionCount = 2;
        line.SetPosition(0, points[0]);
        line.SetPosition(1, points[1]);
        line.enabled = true;
      } else {
        points.Add(pt);
        line.positionCount = points.Count;
        line.SetPosition( points.Count - 1, lastPoint);
        line.enabled = true;
      }
    }

    public Vector3 lastPoint {
      get {
        if (points == null){
          return (Vector3.zero);
        }
        return (points[points.Count-1]);
        }
    }



}
