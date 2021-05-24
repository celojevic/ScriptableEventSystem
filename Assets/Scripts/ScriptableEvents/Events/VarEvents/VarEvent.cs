using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Var Event")]
public class VarEvent : ScriptableEvent
{

    /// <summary>
    /// The variable to change.
    /// </summary>
    public Var Var;

    /// <summary>
    /// How the variable is changed.
    /// </summary>
    public VarChange VarChange;

    private void OnValidate()
    {
        if (Var is IntVar && !(VarChange is IntVarChange))
            Debug.LogError("Var and VarChange do not match up on VarEvent: " + name);
    }

    public override void Parse()
    {
        if (Var is IntVar intVar)
        {
            IntVarChange intVarChange = VarChange as IntVarChange;
            switch (intVarChange.MathOp)
            {
                case MathOp.Add:
                    intVar.Value += intVarChange.Val;
                    break;

                case MathOp.Sub:
                    intVar.Value -= intVarChange.Val;
                    break;

                case MathOp.Div:
                    intVar.Value *= intVarChange.Val;
                    break;

                case MathOp.Mul:
                    intVar.Value /= intVarChange.Val;
                    break;
            }
        }
    }

}