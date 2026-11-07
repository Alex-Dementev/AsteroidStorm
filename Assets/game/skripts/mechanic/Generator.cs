using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    private bool isActive = true;
    private Image myImage;

    void Start()
    {
        myImage = GetComponent<Image>();

        isActive = PlayerPrefs.GetInt("EnableGenerators", 1) == 1;

        if(isActive)
        {
            myImage.color = new Color(241f/255f, 112f/255f, 221f/255f, 200f/255f);
        }
        else
        {
            myImage.color = new Color(116f/255f, 81f/255f, 110f/255f, 200f/255f);
        }
    }

    public void Click()
    {
        if(isActive)
        {
            isActive = false;
            myImage.color = new Color(116f/255f, 81f/255f, 110f/255f, 200f/255f);
        }
        else
        {
            isActive = true;
            myImage.color = new Color(241f/255f, 112f/255f, 221f/255f, 200f/255f);
        }
    }
}
