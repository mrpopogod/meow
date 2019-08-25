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

    private int progress = 0;

    // Use this for initialization
    void Start()
    {
        movement = new CatMovement(GetComponent<Rigidbody>(), GetComponent<Animator>(), GetComponent<Transform>(), firePrefab, windPrefab);
        GameProgress.Progress.ChangeState(new InitialState());
    }

    void Update()
    {
        movement.Update();
        GameProgress.Progress.RunCurrentState();
    }

    public void EnteredDesert()
    {
        inDesert = true;
        if (progress == 1)
        {
            progress = 2;
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
            progress = 3;
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
            progress = 1;
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
