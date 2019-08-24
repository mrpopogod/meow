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
    public bool canFire = false;
    public bool canWind = false;
    public bool canWater = false;
    public GameObject catObject = null;
    public SkinnedMeshRenderer myMesh = null;
    public Material BaseSkin = null;
    public Material WaterSkin = null;
    public Material FireSkin = null;
    public Material WindSkin = null;

    private int progress = 0;

    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab, windPrefab);
        GameProgress.Progress.ChangeState(new InitialState());

        //TODO: If the catObject is null, assign it to the proper child.
        myMesh = catObject.transform.GetComponent<SkinnedMeshRenderer>();//this.transform.FindChild("skeleton").transform.GetComponent(SkinnedMeshRenderer);

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
            canFire = true;
            //Shader myShader = catObject.GetComponent<Shader>();
            //Texture myTexture = null;
            //catObject.renderer.material.SetTexture();

            Material[] mats = myMesh.materials;//.materials;
            mats[0] = FireSkin;
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
            canWind = true;
            Material[] mats = myMesh.materials;//.materials;
            mats[0] = WindSkin;
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
            canWater = true;
            Material[] mats = myMesh.materials;//.materials;
            mats[0] = WaterSkin;
        }
    }

    public void LeftRiver()
    {
        inRiver = false;
    }
}
