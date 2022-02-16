using SimpleWebAPI.Dto;
using SimpleWebAPI.Models;
using SimpleWebAPI.Repositories.Common;

namespace SimpleWebAPI.Repositories.Interfaces
{
    public interface IVideoGameRepository
    {
        RepositoryResult<VideoGameModel> Add(VideoGameModelDto data);
        IEnumerable<VideoGameModel> GetAll(int take);
        RepositoryResult<VideoGameModel> Update(VideoGameModel data);
        RepositoryResult<VideoGameModel> Remove(int Id);
        IEnumerable<VideoGameModel> Find(IEnumerable<string> genres);
    }
}
