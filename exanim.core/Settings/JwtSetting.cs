namespace exanim.core.Settings;

public sealed record JwtSetting
{
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public int ExpireMinutes { get; init; }
}