﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController2 : MonoBehaviour
{
    public int tutorialStep = 0;

    private GameObject tutorial8;
    private GameObject tutorial9;
    private GameObject tutorial10;
    private GameObject tutorial11;
    private GameObject tutorial12;

    private GameObject skipButton;

    private GameObject personSpawner0;
    private GameObject personSpawnerButton0;
    private GameObject personSpawner1;
    private GameObject personSpawnerButton1;

    // Start is called before the first frame update
    void Start()
    {
        tutorial8 = GameObject.Find("Tutorial8");
        tutorial9 = GameObject.Find("Tutorial9");
        tutorial10 = GameObject.Find("Tutorial10");
        tutorial11 = GameObject.Find("Tutorial11");
        tutorial12 = GameObject.Find("Tutorial12");

        skipButton = GameObject.Find("SkipButton");

        tutorial8.SetActive(true);
        tutorial9.SetActive(false);
        tutorial10.SetActive(false);
        tutorial11.SetActive(false);
        tutorial12.SetActive(false);

        personSpawner0 = GameObject.Find("PersonSpawner(0)");
        personSpawner1 = GameObject.Find("PersonSpawner (1)");
        personSpawner0.SetActive(false);
        personSpawner1.SetActive(false);
        personSpawnerButton0 = GameObject.Find("LSpawnButton");
        personSpawnerButton1 = GameObject.Find("RSpawnButton");
        personSpawnerButton0.SetActive(false);
        personSpawnerButton1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStep)
        {
            case -1:
                tutorial8.SetActive(false);
                tutorial9.SetActive(false);
                tutorial10.SetActive(false);
                tutorial11.SetActive(false);
                tutorial12.SetActive(false);
                skipButton.SetActive(false);
                personSpawner0.SetActive(true);
                personSpawner1.SetActive(true);
                personSpawner0.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawner1.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawnerButton0.SetActive(true);
                personSpawnerButton1.SetActive(true);
                break;
            case 1:
                tutorial8.SetActive(false);
                tutorial9.SetActive(true);
                tutorial10.SetActive(false);
                tutorial11.SetActive(false);
                tutorial12.SetActive(false);
                break;
            case 2:
                tutorial8.SetActive(false);
                tutorial9.SetActive(false);
                tutorial10.SetActive(true);
                tutorial11.SetActive(false);
                tutorial12.SetActive(false);
                break;
            case 3:
                tutorial8.SetActive(false);
                tutorial9.SetActive(false);
                tutorial10.SetActive(false);
                tutorial11.SetActive(true);
                tutorial12.SetActive(false);
                break;
            case 4:
                tutorial8.SetActive(false);
                tutorial9.SetActive(false);
                tutorial10.SetActive(false);
                tutorial11.SetActive(false);
                tutorial12.SetActive(true);
                break;
        }
    }
}
