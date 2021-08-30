using UnityEngine;
using TMPro;

public class InGameCanvasUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        score.text = GameManager.instance.gamePoints.ToString();
    }
}
