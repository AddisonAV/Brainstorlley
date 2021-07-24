using TMPro;
using UnityEngine;


public class timePlayed : MonoBehaviour
{
    public TextMeshProUGUI timePlayedText;
    // Start is called before the first frame update

    public void setTimePlayed(double timePlay)
    {
        double time = System.Math.Round((float)(Time.realtimeSinceStartup - timePlay),3);
        timePlayedText.text = "Time: " + time + "s";
    }
}
