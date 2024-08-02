using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isLocked = true;
    public string keyTag = "Key";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keyTag) && isLocked)
        {
            isLocked = false;
            OpenDoor();
            Destroy(other.gameObject); 
        }
    }

    public void OpenDoor()
    {
        if (!isLocked)
        {
            isOpen = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}