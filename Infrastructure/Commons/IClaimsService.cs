namespace RepositoryLayer.Commons
{
	public interface IClaimsService
	{
		int GetCurrentUserId { get; }
		string? IpAddress { get; }
        string GetCurrentUserIdEmail { get; }
        int GetCurrentSessionUserId { get; }
    }
}