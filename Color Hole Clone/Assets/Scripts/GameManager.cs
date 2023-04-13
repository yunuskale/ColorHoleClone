using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Transform cubes1, cubes2;
    public static float cubeCount1, cubeCount2;
    public static bool firstPartEnded;
    public static bool finish;
    public static bool stop, stop1;
    private void Start()
    {
        cubeCount1 = GameObject.Find("Cubes").transform.childCount;
        cubeCount2 = GameObject.Find("Cubes (1)").transform.childCount;
    }
    private void Update()
    {
        if(GameObject.Find("Cubes").transform.childCount == 0 && !stop)
        {
            firstPartEnded = true;
            Object.FindObjectOfType<Hole>().HorizontalMove();
            stop=true;
        }
        else if(GameObject.Find("Cubes (1)").transform.childCount == 0 && !stop1)
        {
            Object.FindObjectOfType<UýManager>().Win();
            finish=true;
            stop1 = true;
        }
    }
    public void Restart()
    {
        firstPartEnded=false;
        finish=false;
        stop=false;
        stop1=false;
    }
}
