
public enum BoolOp
{
    True, False, Switch,
}

public enum EqualityOp
{
    NotEqualTo, EqualTo,
    LessThan, GreaterThan,
    LessThanOrEqualTo, GreaterThanOrEqualTo,
}

public enum KeyPressType
{
    Down, Up, Hold,
}

public enum MathOp
{
    Add, Sub, Div, Mul,
}

public enum StartType
{
    Awake,
    OnEnable,
    Start,
}

/// <summary>
/// Change will replace the whole string.
/// Append will add on to the string.
/// Remove will remove part of the string.
/// </summary>
public enum StringOp
{
    Change, Append, Remove,
}
