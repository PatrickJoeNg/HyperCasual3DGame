using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Logic
    public int gamePoints;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
