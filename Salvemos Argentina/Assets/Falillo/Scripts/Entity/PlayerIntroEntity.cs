using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntroEntity : MonoBehaviour {
    [Header("Variable de control")]
    [Space]
    public bool enabledControls;

    [Header("Variables")]
    [SerializeField] private ValueController<float> ctrl_value_speed;

    [Header("Features")]
    [Space]
    [SerializeField] private CommandsController ctrl_commands = new CommandsController();
    [SerializeField] private PhysicController ctrl_physic;
    [SerializeField] private MouseRotationController ctrl_mouse_rotation;
    [SerializeField] public Interactable interactable;

    private void FixedUpdate() {
        if (enabledControls) {
            ctrl_commands.CheckFixedUpdate();
            ctrl_mouse_rotation.Rotate(transform, Camera.main);
        }
    }

    public void Move_Up() => ctrl_physic.MoveInDirection(ctrl_value_speed.Value, Vector3.forward);
    public void Move_Down() => ctrl_physic.MoveInDirection(-ctrl_value_speed.Value, Vector3.forward);
    public void Move_Right() => ctrl_physic.MoveInDirection(ctrl_value_speed.Value, Vector3.right);
    public void Move_Left() => ctrl_physic.MoveInDirection(-ctrl_value_speed.Value, Vector3.right);

    public void InteractableInteract() {
        interactable.Interact();
    }
}
