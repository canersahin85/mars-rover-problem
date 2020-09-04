namespace MarsRoverProblem.Enums
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Yönlerin değerlerinin tutulduğu enum
    /// </summary>
    public enum DirectionsEnum
    {
        [EnumMember(Value = "N")]
        N = 0,
        [EnumMember(Value = "E")]
        E = 1,
        [EnumMember(Value = "S")]
        S = 2,
        [EnumMember(Value = "W")]
        W = 3
    }
}
