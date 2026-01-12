using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public float vitesseDescente;   
    public InputActionReference toucheMonte;
    public bool isJumpPressed;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isJumpPressed)
        {
            transform.position += new Vector3(0, vitesseDescente*Time.deltaTime, 0);

        }
        else
        transform.position -= new Vector3(0, vitesseDescente*Time.deltaTime, 0);
    }

    private void OnEnable()
    {
        if (toucheMonte != null)
        {
            toucheMonte.action.Enable();
            toucheMonte.action.performed += OnJumpPressed;
            toucheMonte.action.canceled += OnJumpReleased;
        }
    }

    private void OnDisable()
    {
        if (toucheMonte != null)
        {
            toucheMonte.action.Disable();
            toucheMonte.action.performed -= OnJumpPressed;
            toucheMonte.action.canceled -= OnJumpReleased;
        }
    }

    private void OnJumpPressed(InputAction.CallbackContext context)
    {
        isJumpPressed = true;
        print("Je Monte");
    }
    private void OnJumpReleased(InputAction.CallbackContext context)
    {
        isJumpPressed = false;
        print("Je Descends");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Sol"))
        {
        print("Je suis entré en collision avec " + other.gameObject.name);
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
