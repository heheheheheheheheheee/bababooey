using UnityEngine;
using TMPro;

[System.Serializable]
public class SittingScript : MonoBehaviour
{
    public GameObject chair;
    public TextMeshProUGUI interactText;

    private FirstPersonMovement fpm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpm = gameObject.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && fpm.canMove == false)
        {
            GetUpFromChair();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
            Debug.DrawLine(transform.position, transform.forward, Color.green);
            if (hit.collider.gameObject.tag == "Chair")
            {
                interactText.text = "press E to interact!";
                if (Input.GetKeyDown(KeyCode.E) && fpm.canMove)
                {
                    SitOnChair();
                }
            }
            else
            {
                interactText.text = "";
            }
        }
    }

    void SitOnChair()
    {
        LockMovement();
        gameObject.transform.position = chair.transform.position + new Vector3(0, 2f, 0);

        
    }

    void GetUpFromChair()
    {
        UnlockMovement();
    }

    void LockMovement()
    {
        fpm.canMove = false;
    }

    void UnlockMovement()
    {
        fpm.canMove = true;
    }
}
