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
    }

    public void LeftDesert()
    {
        inDesert = false;
    }

    public void EnteredForest()
    {
        inForest = true;
    }

    public void LeftForest()
    {
        inForest = false;
    }

    public void EnteredGorge()
    {
        inGorge = true;
    }

    public void LeftGorge()
    {
        inGorge = false;
    }

    public void EnteredRiver()
    {
        inRiver = true;
    }

    public void LeftRiver()
    {
        inRiver = false;
    }
}
