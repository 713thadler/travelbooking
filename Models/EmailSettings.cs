public class EmailSettings
{
    internal readonly bool RequireEmailConfirmation;

    public required string Host { get; set; }
    public int Port { get; set; }
    public bool EnableTLS { get; set; }
    public required string EmailUser { get; set; }
    public required string EmailPassword { get; set; }
}
