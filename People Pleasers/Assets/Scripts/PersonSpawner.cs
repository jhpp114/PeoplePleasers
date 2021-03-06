﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to access btn with text

public class PersonSpawner : MonoBehaviour
{   
    public bool startPersonSpawn = true;
    private bool hasStarted = false;

    public List<WaveInterface> waveInterfaces;
    private int startingWave = 0;

    public Button[] spawnButton;
    public Text[] spawnNumberIndicator;
    
    public float timeAutomaticClick = 20.0f;
    private float maxFillAmount = 1.0f;

    private Coroutine coroutineForBtnNotClicked;
    private int buttonLength;
    // update may24
    private int buttonIndexer = 0;
    private bool turnOffSecondBtn = false;
    // Start is called before the first frame update
    public void Start()
    {
        if (GameObject.Find("Tutorial") == null)
        {
            StartPersonSpawn();
            hasStarted = true;
        }        
        else
        {
            startPersonSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startPersonSpawn && !hasStarted)
        {
            StartPersonSpawn();
            hasStarted = true;
        }
        AutomaticStartIndicator();
    }
    
    private void StartPersonSpawn()
    {
        coroutineForBtnNotClicked = StartCoroutine(AutomaticClick());
        buttonLength = spawnButton.Length;
        if (buttonLength > 1)
        {
            spawnButton[1].gameObject.SetActive(false);
            spawnButton[1].enabled = false;
        }
        else
        {
            spawnButton[buttonIndexer].GetComponent<Image>().fillAmount = maxFillAmount;
        }
        // update may24
        //spawnButton.GetComponent<Image>().fillAmount = maxFillAmount;
        // update may24
        SpawnButtonIndicator();
        // today update may  24
        if (spawnNumberIndicator.Length > 1)
        {
            spawnNumberIndicator[0].text = "X" + waveInterfaces[0].GetNumberOfPerson();
            spawnNumberIndicator[1].text = "X" + waveInterfaces[1].GetNumberOfPerson();
        }
        else
        {
            spawnNumberIndicator[0].text = "X" + waveInterfaces[0].GetNumberOfPerson();
        }
    }

    // create a method that if the btn is not click
    // in certain amount of time it will get click automatically
    private IEnumerator AutomaticClick()
    {
        yield return new WaitForSeconds(timeAutomaticClick);
        if (turnOffSecondBtn == true)
        {
            yield break;
        }
        //Debug.Log("Before Invoke: " + buttonIndexer);
        spawnButton[buttonIndexer].onClick.Invoke();
        //Debug.Log("After Invoke: " + buttonIndexer);
        // added && turnOffSecondBtn
        if (buttonIndexer == 1 && turnOffSecondBtn != true)
        {
            //Debug.Log("I am calling coroutine automaticClick");
            spawnButton[0].gameObject.SetActive(false);
            StartCoroutine(AutomaticClick());
        } else if (buttonIndexer == 1 && turnOffSecondBtn == true)
        {
            //Debug.Log("I am stopping automaticClick routine");
            // StopCoroutine(AutomaticClick());
            // StopAllCoroutines();
        }
        //spawnButton[buttonIndexer].gameObject.SetActive(false);
        //Debug.Log("AutomaticClick: " + buttonIndexer);
    }

    private void AutomaticStartIndicator()
    {
        // fill amout is one
        var decreaseAmount = maxFillAmount / timeAutomaticClick;   
        
        spawnButton[buttonIndexer].GetComponent<Image>().fillAmount -= decreaseAmount * Time.deltaTime;
        if (spawnButton[buttonIndexer].GetComponent<Image>().fillAmount == 0)
        {
            spawnButton[buttonIndexer].gameObject.SetActive(false);  
        }
    }

    public void StartCoroutine()
    {
        StartCoroutine(SpawnAllWaves());
        // I have to enable the button after the method above is called
        ButtonClicked();
        //Debug.Log("At start coroutine: " + buttonIndexer);
        spawnButton[buttonIndexer].enabled = false;
        // added && buttonIndexer == 0
        //Debug.Log("At startcoroutine: " + turnOffSecondBtn);
        if (buttonLength > 1 && buttonIndexer == 0)
        {
            buttonIndexer = 1;
            
            spawnButton[buttonIndexer].enabled = true;
            spawnButton[buttonIndexer].gameObject.SetActive(true);

            SpawnButtonIndicator();
            //Debug.Log(" Got in Condition state: " + buttonIndexer);
        }
        
        if (turnOffSecondBtn == true)
        {
            spawnButton[buttonIndexer].enabled = false;
            spawnButton[buttonIndexer].gameObject.SetActive(false);
            
            //Debug.Log("I am insdie turnoffSecond True statement");
           
            
        }
        //Debug.Log("Reach here?");
        if (turnOffSecondBtn == false && buttonIndexer == 1)
        {
            //Debug.Log("Got in here!");
            StartCoroutine(AutomaticClick());
        }
        StopCoroutine(coroutineForBtnNotClicked);
    }

    private void ButtonClicked()
    {
        //Debug.Log("I am Button Clicked " + buttonIndexer);
        Color c = spawnButton[buttonIndexer].gameObject.GetComponent<Image>().color;
        c.a = 0f;
        spawnButton[buttonIndexer].gameObject.GetComponent<Image>().color = c;
        spawnNumberIndicator[buttonIndexer].text = "";
        spawnButton[buttonIndexer].gameObject.SetActive(false);
        spawnButton[buttonIndexer].enabled = false;
        //Debug.Log("I am the Button Clicked: " + buttonIndexer + "clicked!");

        if (buttonIndexer == 1)
        {
            turnOffSecondBtn = true;
        }
    }
    
    private void SpawnButtonIndicator()
    {
        //Debug.Log(waveInterfaces[0].GetPerson()[0]);
        if (spawnNumberIndicator.Length > 1 && buttonLength == 1)
        {

        }
        //else if (buttonLength > 1)
        //{
        //    if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Hungry"))
        //    {
        //        spawnButton[buttonIndexer].GetComponent<Image>().color = Color.red;
        //    }
        //    else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Thirsty"))
        //    {
        //        spawnButton[buttonIndexer].GetComponent<Image>().color = Color.blue;
        //    }
        //    else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Hot"))
        //    {
        //        spawnButton[buttonIndexer].GetComponent<Image>().color = new Color(255f, 174f, 0);
        //    }
        //    else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Bored"))
        //    {
        //        spawnButton[buttonIndexer].GetComponent<Image>().color = new Color(206f, 0, 255f);
        //    }
        //    else
        //    {
        //        //Debug.Log("humm");
        //    }
        //}
        else
        {


            if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Hungry"))
            {
                spawnButton[buttonIndexer].GetComponent<Image>().color = Color.red;
            }
            else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Thirsty"))
            {
                spawnButton[buttonIndexer].GetComponent<Image>().color = Color.blue;
            }
            else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Hot"))
            {
                spawnButton[buttonIndexer].GetComponent<Image>().color = new Color(255f, 174f, 0);
            }
            else if (waveInterfaces[buttonIndexer].GetPerson()[0].name.Contains("Bored"))
            {
                spawnButton[buttonIndexer].GetComponent<Image>().color = new Color(206f, 0, 255f);
            }
            else
            {
                //Debug.Log("humm");
            }

        }
    }

    private IEnumerator SpawnAllWaves()
    {
        if (buttonLength > 1)
        {
            var current = waveInterfaces[buttonIndexer];
            yield return StartCoroutine(SpawnAllEnemiesByWave(current));
        }
        else
        {
            for (var curWave = startingWave; curWave < waveInterfaces.Count; curWave++)
            {
                var current = waveInterfaces[curWave];
                yield return StartCoroutine(SpawnAllEnemiesByWave(current));
            }
        }
        
    }

    private IEnumerator SpawnAllEnemiesByWave(WaveInterface _waveInterface)
    {
        for (int i = 0; i < _waveInterface.GetNumberOfPerson(); i++)
        {
            GeneratePerson(_waveInterface);
            yield return new WaitForSeconds(_waveInterface.GetTimeBetweenSpawns());
        }
    }

    private void GeneratePerson(WaveInterface _waveInterface)
    {
        int generateRandomPerson = 0;
        if (buttonLength > 1)
        {
            generateRandomPerson = buttonIndexer;
        }
        
        if (_waveInterface.GetPerson().Count > 1)
        {
            generateRandomPerson = Random.Range(0, 4);
        }
        else
        {
            generateRandomPerson = 0;
        }
        int generateRandomTargetPos = Random.Range(0, 2);
        GameObject personObj = Instantiate(_waveInterface.GetPerson()[generateRandomPerson],
            _waveInterface.GetWaypoint()[0].transform.position,
            Quaternion.identity);
        personObj.GetComponent<PersonPathing>().SetWave(_waveInterface);
    }
}
