using UnityEngine;
using UnityEngine.UI;

public class Cube2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "cube")
        {
            if (other.gameObject.tag == "hole")
            {
                Object.FindObjectOfType<UýManager>().bar2.fillAmount += 1 / GameManager.cubeCount2;
                transform.SetParent(other.transform);
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(other.gameObject.transform.position.x - transform.position.x, 0, other.gameObject.transform.position.z - transform.position.z);
                gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3((other.gameObject.transform.position.z - transform.position.z) * 10f, 0, (other.gameObject.transform.position.x - transform.position.x) * -10f);
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(gameObject, 2f);
            }
        }

        else
        {
            if (other.gameObject.tag == "hole")
            {
                transform.SetParent(other.transform);
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(other.gameObject.transform.position.x - transform.position.x, 0, other.gameObject.transform.position.z - transform.position.z);
                gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3((other.gameObject.transform.position.z - transform.position.z) * 10f, 0, (other.gameObject.transform.position.x - transform.position.x) * -10f);
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(gameObject, 2f);
                Object.FindObjectOfType<UýManager>().Failed();
            }

        }
    }
            
}
