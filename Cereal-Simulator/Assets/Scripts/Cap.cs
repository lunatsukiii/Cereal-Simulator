using UnityEngine;

public class Cap: Interactable {

    public Cap milkyCap;
    public bool isOn;

    private void Start() {
        UpdateCap();
    }

    void UpdateCap() {
        milkyCap.enabled = isOn;
    }

    public override string GetDescription() {
        if (isOn) return "Press [F] to <color=green>open</color> the Milk Carton.";
        return "Press [F] to <color=red>close</color> the Milk Carton.";
    }

    public override void Interact() {
        isOn = !isOn;
        UpdateCap();
    }
}