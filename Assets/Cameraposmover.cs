using UnityEngine;

public class Cameraposmover : MonoBehaviour
{
    public Animator animator; // Animator component to control animations
    public GameObject Canvas;
    public GameObject Canvas2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure the Animator component is attached to the GameObject
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator component not found!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Trigger animation when the player presses the "T" key
        if (Input.GetKeyDown(KeyCode.T))
        {
            Movecamera(); // Call the function to trigger the animation
        }
    }

    // Method to trigger the animation in the Animator
    private void Movecamera()
    {
        if (animator != null)
        {
            animator.SetTrigger("ArmourySelected");
            Debug.Log("ArmourySelected trigger set!");
            Canvas.SetActive(false);
            Canvas2.SetActive(true);
        }
    }
}

