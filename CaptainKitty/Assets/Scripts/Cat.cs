﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Cat : MonoBehaviour
{
    private CatMovement movement;
    public GameObject firePrefab;
    public GameObject windPrefab;
    public GameObject waterPrefab;
    private bool inDesert = false;
    private bool inForest = false;
    private bool inRiver = false;
    private bool inGorge = false;
    private bool hasWater = false;
    public AudioSource musicPlayer;

    private bool inWater = false;

    public GameObject fireCylinder = null;
    public GameObject catObject = null;
    public SkinnedMeshRenderer myMesh = null;
    public Material BaseSkin = null;
    public Material WaterSkin = null;
    public Material FireSkin = null;
    public Material WindSkin = null;


    private int progress = 0;
    //public int catLevel = 0; //already captured in "progress"

    public IEnumerator BeginTheEnd()
    {
        //WaitForSeconds(3);
        FindObjectOfType<UIController>().GetDialogBox().OpenConversation();
        FindObjectOfType<UIController>().GetDialogBox().UpdateConversation("YOU DID IT! Game ending in 3 seconds.");
        Debug.Log("Starting to End in 3...");
        yield return new WaitForSeconds(1);
        Debug.Log("2...");
        yield return new WaitForSeconds(1);
        Debug.Log("1...");
        yield return new WaitForSeconds(1);
        Debug.Log("Goodbye");
        SceneManager.LoadScene("End");
    }

    public int GetLevel()
    {
        return progress;
    }
    public void LevelUp()
    {
        progress++;
        ChangeSkin(progress);

        if (progress > 0)
        {
            GameObject.Destroy(fireCylinder);
            hasWater = true;
            movement.UnlockWater();
        }
        if (progress > 1)
        {
            movement.UnlockFire();
        }
        if (progress > 2)
        {
            movement.UnlockWind();
        }
        if (progress > 3)
        {
            StartCoroutine(BeginTheEnd());
            //SceneLoader mySceneLoader = this.GetComponent<SceneLoader>();
            //mySceneLoader.LoadEndScene();
        }


    }

    public void OnParticleCollision(GameObject other)
    {
        if (!hasWater)
        {
            return;
        }

        if (other.tag.Equals("DesertFire"))
        {
            var ps = other.GetComponent<ParticleSystem>();
            GameObject.Destroy(ps);
        }
    }

    public void ChangeSkin (int newNumber)
    {
        Material[] mats = myMesh.materials;
        if (newNumber == 0)
        {
            mats[0] = BaseSkin;
        } else if (newNumber == 1)
        {
            mats[0] = WaterSkin;
        }
        else if (newNumber == 2)
        {
            mats[0] = FireSkin;
        }
        else if (newNumber == 3)
        {
            mats[0] = WindSkin;
        } else
        {
            mats[0] = WindSkin;
        }
        myMesh.materials = mats;
    }
    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab, windPrefab,waterPrefab);
        GameProgress.Progress.ChangeState(new InitialState());

        //TODO: If the catObject is null, assign it to the proper child.
        myMesh = catObject.GetComponent<SkinnedMeshRenderer>();//this.transform.FindChild("skeleton").transform.GetComponent(SkinnedMeshRenderer);
        progress = 0;
    }

    void Update()
    {
        movement.Update();
        GameProgress.Progress.RunCurrentState();
        //Renderer.
        if (Input.GetKey("escape"))
        {
            //TODO: pull up a prompt for "quit" or "restart"
            Debug.Log("Trying to escape the game...");
            //Application.Quit();
            FindObjectOfType<UIController>().OpenQuit();
        }
        
    }

    public void EnteredDesert()
    {
        inDesert = true;
        if (progress == 1)
        {
            Debug.Log("Cat entered the Desert correctly.");
            //progress = 2;
            //canFire = true;
            //Shader myShader = catObject.GetComponent<Shader>();
            //Texture myTexture = null;
            //catObject.renderer.material.SetTexture();

            //LevelUp();
            //mats[0] = headMat;
            //skeleton.materials = mats;
        }
    }

    public void LeftDesert()
    {
        inDesert = false;
    }

    public void EnteredForest()
    {
        inForest = true;
        if (progress == 2)
        {
            Debug.Log("Cat entered the Forest correctly.");
            //progress = 3;
            //canWind = true;
            //LevelUp();
            //ChangeSkin(3);
        }
    }

    public void LeftForest()
    {
        inForest = false;
    }

    public void EnteredGorge()
    {
        inGorge = true;
        if (progress == 3)
        {
            //progress = 4;
            //LevelUp();
            Debug.Log("A winner is you!");
        }
    }

    public void LeftGorge()
    {
        inGorge = false;
    }

    public void EnteredRiver()
    {
        inRiver = true;
        if (progress == 0)
        {
            Debug.Log("Cat entered the river correctly.");
            //progress = 1;
            //canWater = true;
            //LevelUp();
        }
    }

    public void LeftRiver()
    {
        inRiver = false;
    }

    public void EnteredWater()
    {
        inWater = true;
        movement.inWater = inWater;
    }

    public void LeftWater()
    {
        inWater = false;
        movement.inWater = inWater;
    }
	
	public void KillPlane()
	{
		transform.position = new Vector3(0f, 7f, 0f);
	}	
	
}
