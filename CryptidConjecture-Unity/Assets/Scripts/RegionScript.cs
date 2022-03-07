/*
 * Created by: Haley Kelly
 * Date Created: 2/23/2022
 *
 * Last Edited by: N/A
 * Last Edited: 3/6/2022
 *
 * Description: Script that controls independent regions for Cryptid Conjecture.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegionScript : MonoBehaviour
{

  public GameObject loseGamePrompt;
  public Button loseGameContinue;

  public GameObject directionalLightObject;
  private Light directionalLight;
  public AudioSource audioData;

  public GameObject cryptid;
  public GameObject cryptidbubble;
  public GameObject cryptidObtained;
  public Button cryptidCheck;

  public int score = 0;
  public int ballsRemaining = 10;
  public int requiredScore = 0;

  private int currProgression = 1;

  public GameObject level1Pegs;
  public GameObject level2Pegs;
  public GameObject level3Pegs;

  public GameObject ballsRemaininge;
  public Text ballsRemainingText;
  public GameObject ballShooter;

  public GameObject exitButtonEncapsulator;
  public GameObject exitGameEncapsulator;
  public Button exitGame;

  public GameObject exitGamePrompt;
    public Button yesexit;
    public Button noexit;

  public GameObject storyPrompt1;
  public Button storyPromptContinue1;
  public GameObject storyPrompt2;
  public Button storyPromptContinue2;
  public GameObject storyPrompt3;
  public Button storyPromptContinue3;

  private GameObject[] normalpegs;
  private GameObject[] fireflypegs;
  private GameObject[] barrierpegs;

  private bool calculateScore = true;

  private float zoominstart = 0.5f;

  Color color = new Color(1f, 0.6931f, 0f, 1f);
  Color color1 = new Color(1f, 0f, 0.6826792f, 1f);
  Color color2 = new Color(0.01534319f, 0f, 1f, 1f);

  Quaternion rot = Quaternion.Euler(-200, 0, 0);
  Quaternion rot1 = Quaternion.Euler(-215, 0, 0);
  Quaternion rot2 = Quaternion.Euler(-260, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
      directionalLight = directionalLightObject.GetComponent<Light>();
      directionalLight.color = color;
      directionalLightObject.transform.position = new Vector3(0f , 9.58f, 0f);
      directionalLightObject.transform.rotation = rot;
      audioData = GetComponent<AudioSource>();
      audioData.loop = true;
      audioData.Play(0);

      exitGame.onClick.AddListener(exitGameePrompt);
      yesexit.onClick.AddListener(exitGamee);
      noexit.onClick.AddListener(SetGamePlayActive);
      storyPromptContinue1.onClick.AddListener(storyPromptContinuee1);
      storyPromptContinue2.onClick.AddListener(storyPromptContinuee2);
      storyPromptContinue3.onClick.AddListener(storyPromptContinuee3);
      cryptidCheck.onClick.AddListener(menu);
      loseGameContinue.onClick.AddListener(menu);

      Camera.main.fieldOfView = 66f;
      ballsRemaining = 10;
      level1Pegs.SetActive(true);
      SetPegs();
      //Debug.Log("test1");
      StartCoroutine(fancyzoomin());
      //Debug.Log("test3");
      exitButtonEncapsulator.SetActive(true);
      calculateScore = true;
      score = 0;

    }

    IEnumerator fancyzoomin()
    {
      for (int i = 0; i < 25; i++){
        yield return new WaitForSeconds(0.05f);
        //Debug.Log("test2");
        Camera.main.fieldOfView -= zoominstart;
        zoominstart -= 0.02f;
      }
    }


    void SetPegs(){
      Vector3 loc = Vector3.zero;
      GameObject[] peges = GameObject.FindGameObjectsWithTag ("normalpeg");
      for(int i = 0 ; i < peges.Length ; i ++){
        loc.x = Random.Range( -3.00f, 5.00f );
        loc.y = Random.Range( -1.20f, 2.5f );
        loc.z = 2;

        peges[i].transform.position = loc;
      }
      peges = GameObject.FindGameObjectsWithTag ("fireflypeg");
      for(int i = 0 ; i < peges.Length ; i ++){
        loc.x = Random.Range( -3.00f, 5.00f );
        loc.y = Random.Range( -1.20f, 2.5f );
        loc.z = 2;

        peges[i].transform.position = loc;
      }
      peges = GameObject.FindGameObjectsWithTag ("barrierpeg");
      for(int i = 0 ; i < peges.Length ; i ++){
        loc.x = Random.Range( -3.00f, 5.00f );
        loc.y = Random.Range( -1.20f, 2.5f );
        loc.z = 2;

        peges[i].transform.position = loc;
      }
    }


    void ClearBalls(){
      GameObject[] balles = GameObject.FindGameObjectsWithTag ("Ball");
      for(int i = 0 ; i < balles.Length ; i ++)
      {
         Destroy(balles[i]);
      }
    }


    void Update(){
      if (calculateScore == true){
      normalpegs = GameObject.FindGameObjectsWithTag("normalpeg");
      fireflypegs = GameObject.FindGameObjectsWithTag("fireflypeg");
      barrierpegs = GameObject.FindGameObjectsWithTag("barrierpeg");

      requiredScore = normalpegs.Length + fireflypegs.Length + barrierpegs.Length;

      if (requiredScore == 0){
        //Debug.Log("Win condition met!");
        SetGamePlayInactive();
        exitButtonEncapsulator.SetActive(false);

        if (currProgression == 1){ // leads to level 2
          directionalLight.color = color1;
          directionalLightObject.transform.rotation = rot1;
          ClearBalls();
          pauseScreen();
          currProgression ++;
          storyPrompt1.SetActive(true);
          SetGamePlayInactive();

        } else if (currProgression == 2){ // leads to level 3
          directionalLight.color = color2;
          directionalLightObject.transform.rotation = rot2;
          ClearBalls();
          pauseScreen();
          currProgression ++;
          storyPrompt2.SetActive(true);
          SetGamePlayInactive();

        } else if (currProgression == 3){ // show cryptid
          ClearBalls();
          pauseScreen();
          storyPrompt3.SetActive(true);
          SetGamePlayInactive();
        }
            }
            else if (ballsRemaining == 0 && (!(GameObject.Find("BallPrefab(Clone)")))){ // return to menu selection
              Debug.Log("Lose condition met!");
              loseGame();
            }
      }

    }

    void loseGame(){
      loseGamePrompt.SetActive(true);
      pauseScreen();
    }

    void pauseScreen(){
      calculateScore = false;
    }


    void FixedUpdate()
    {
      ballsRemainingText.text = ballsRemaining.ToString();



    }

    void winGame(){
      Scene scene = SceneManager.GetActiveScene();
      if (scene.name == "RegionOne"){
        PlayerPrefs.SetInt("progress", 2);
      } else if (scene.name == "RegionTwo"){
        PlayerPrefs.SetInt("progress", 3);
      } else if (scene.name == "RegionThree"){
        PlayerPrefs.SetInt("progress", 4);
      } else if (scene.name == "RegionFour"){
        PlayerPrefs.SetInt("progress", 5);
      } else if (scene.name == "RegionFive"){
        PlayerPrefs.SetInt("progress", 6);
      }
    }

    IEnumerator fancyzoomout()
    {

      for (int i = 0; i < 25; i++){
        yield return new WaitForSeconds(0.05f);
        Camera.main.fieldOfView += zoominstart;
        zoominstart += 0.02f;
      }
      SceneManager.LoadScene("MenuScene");
    }

    void menu(){
      StartCoroutine(fancyzoomout());
    }


    void storyPromptContinuee1(){ // load second level
      exitButtonEncapsulator.SetActive(true);
      level2Pegs.SetActive(true);
      SetPegs();
      calculateScore = true;
      storyPrompt1.SetActive(false);
      ballsRemaining = 8;
      SetGamePlayActive();
    }

    void storyPromptContinuee2(){ // load third level
      exitButtonEncapsulator.SetActive(true);
      level3Pegs.SetActive(true);
      SetPegs();
      calculateScore = true;
      storyPrompt2.SetActive(false);
      ballsRemaining = 6;
      SetGamePlayActive();
    }

    void storyPromptContinuee3(){ // load cryptid discovery
      exitButtonEncapsulator.SetActive(true);
      storyPrompt3.SetActive(false);
      cryptidbubble.SetActive(true);
      cryptid.SetActive(true);
      StartCoroutine(cryptidmovement());
      cryptidObtained.SetActive(true);
      winGame();
    }

    IEnumerator cryptidmovement()
    {
      float xstart = 0.05f;
      float ystart = 0.01f;
      for (int i = 0; i < 25; i++){
        yield return new WaitForSeconds(0.05f);
        //Debug.Log("test2");
        cryptid.transform.position = new Vector3(cryptid.transform.position.x+xstart, cryptid.transform.position.y-ystart, cryptid.transform.position.z);
        xstart -= 0.005f;
        ystart += 0.001f;
      }
    }

    void SetGamePlayInactive(){
      ballShooter.SetActive(false);
      exitGameEncapsulator.SetActive(false);
      exitButtonEncapsulator.SetActive(true);
    }

    void SetGamePlayActive(){
      ballShooter.SetActive(true);
      exitGameEncapsulator.SetActive(false);
      exitButtonEncapsulator.SetActive(true);
    }

    void exitGameePrompt(){
      SetGamePlayInactive();
      exitGameEncapsulator.SetActive(true);
      exitButtonEncapsulator.SetActive(false);
    } // fin

    void exitGamee(){
      Application.Quit();
    }
}
