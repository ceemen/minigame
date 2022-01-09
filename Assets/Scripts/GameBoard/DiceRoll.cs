using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceRoll : MonoBehaviour
{

    public bool beenRolled;
    private Rigidbody diceRb;
    private bool rollActionBool;
    [SerializeField]
    private InputActionReference diceRollAction;

    private void Awake()
    {
        diceRb = gameObject.GetComponent<Rigidbody>();
        diceRollAction.action.performed += RollDice;
        diceRollAction.action.canceled += RollDice;
    }

    private void OnEnable()
    {

        diceRollAction.action.Enable();
    }

    private void OnDisable()
    {
        diceRollAction.action.Disable();
    }

    public void RollDice(InputAction.CallbackContext diceinput)
    {
        rollActionBool = diceinput.ReadValueAsButton();

        beenRolled = true;

        if (rollActionBool)
        {
            float xval = Random.Range(0.0f, 180.0f);
            float yval = Random.Range(0.0f, 180.0f);
            float zval = Random.Range(0.0f, 180.0f);
            Vector3 torqueVector = new Vector3(xval, yval, zval);
            diceRb.AddForce(Vector3.up * Random.Range(2.0f, 4.5f),ForceMode.Impulse);
            diceRb.AddTorque(torqueVector, ForceMode.Impulse);
        }
    }

}
