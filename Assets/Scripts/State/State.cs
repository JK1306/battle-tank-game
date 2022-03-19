using UnityEngine;

public class State : MonoBehaviour
{
    public Model model;
    public virtual void OnEnterState(Model model)
    {
        this.model = model;
        this.enabled = true;
    }

    public virtual void OnExitState()
    {
        this.enabled = false;
    }

    public virtual void Tick(float target=0f){}

    private void Update() {}
}
