using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    // Define possible states for the character
    private enum State
    {
        Idle,
        Walking,
        Jumping
    }

    // Current state of the character
    private State currentState;

    private void Start()
    {
        // Initialize to the Idle state
        currentState = State.Idle;
    }

    private void Update()
    {
        // Call the method to handle current state
        HandleState();

        // State transitions (simplified for demonstration)
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeState(State.Walking);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(State.Jumping);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeState(State.Idle);
        }
    }

    // Method to handle the behavior of each state
    private void HandleState()
    {
        switch (currentState)
        {
            case State.Idle:
                Debug.Log("Character is Idle");
                // Add idle behavior (e.g., play idle animation)
                break;

            case State.Walking:
                Debug.Log("Character is Walking");
                // Add walking behavior (e.g., move forward)
                break;

            case State.Jumping:
                Debug.Log("Character is Jumping");
                // Add jumping behavior (e.g., apply upward force)
                break;
        }
    }

    // Method to change the current state
    private void ChangeState(State newState)
    {
        currentState = newState;
        Debug.Log("Changed state to: " + currentState);
    }
}

