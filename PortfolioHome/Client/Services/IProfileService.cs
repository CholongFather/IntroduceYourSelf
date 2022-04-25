namespace Client.Services;

public interface IProfileService
{
    public Task<List<string>> GetProfiles();
}
