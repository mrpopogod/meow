using UnityEngine;

public class Cat : MonoBehaviour
{
    private CatMovement movement;
    public GameObject firePrefab;
    public GameObject windPrefab;
    private bool inDesert = false;
    private bool inForest = false;
    private bool inRiver = false;
    private bool inGorge = false;

    private bool inWater = false;


    public GameObject catObject = null;
    public SkinnedMeshRenderer myMesh = null;
    public Material BaseSkin = null;
    public Material WaterSkin = null;
    public Material FireSkin = null;
    public Material WindSkin = null;


    private int progress = 0;
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
        }
        myMesh.materials = mats;
    }
    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab, windPrefab);
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
    }

    public void EnteredDesert()
    {
        inDesert = true;
        if (progress == 1)
        {
            Debug.Log("Cat entered the Desert correctly.");
            progress = 2;
            //canFire = true;
            //Shader myShader = catObject.GetComponent<Shader>();
            //Texture myTexture = null;
            //catObject.renderer.material.SetTexture();

            ChangeSkin(2);
            movement.UnlockFire();
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
            progress = 3;
            //canWind = true;
            movement.UnlockWind();
            ChangeSkin(3);
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
            progress = 4;
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
            progress = 1;
            movement.UnlockWater();
            //canWater = true;

            ChangeSkin(1);
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
}
