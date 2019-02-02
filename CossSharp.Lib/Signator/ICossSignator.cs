namespace CossSharp.Lib.Signator
{
    /// <summary>
    /// Signs a Coss payload.
    /// </summary>
    public interface ICossSignator
    {
        string SignPayload(string privateKey, string payload);
    }
}
