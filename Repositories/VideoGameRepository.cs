using AutoMapper;
using SimpleWebAPI.Dto;
using SimpleWebAPI.Models;
using SimpleWebAPI.Repositories.Common;
using SimpleWebAPI.Repositories.Interfaces;

namespace SimpleWebAPI.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {
        public RepositoryResult<VideoGameModel> Add(VideoGameModelDto data)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<VideoGameModelDto, VideoGameModel>()
               );

                var mapper = new Mapper(config);
                var model = mapper.Map<VideoGameModel>(data);

                using (PostgresDbContext db = new PostgresDbContext())
                {
                    db.VideoGames.Add(model);
                    db.SaveChanges();
                }

                return new RepositoryResult<VideoGameModel>(true);
            }
            catch (Exception ex)
            {
                return new RepositoryResult<VideoGameModel>(false, ex.Message);
            }
        }

        public IEnumerable<VideoGameModel> Find(IEnumerable<string> genres)
        {
            if (genres == null || genres.Count() == 0)
                return GetAll();

            var result = new List<VideoGameModel>();

            using(PostgresDbContext db = new PostgresDbContext())
            {
                result.AddRange(db.VideoGames.ToList().Where(x => x.Genres.FirstOrDefault(g => genres.Contains(g)) != null));
            }

            return result;
        }

        public IEnumerable<VideoGameModel> GetAll(int take = 10)
        {

            if (take < 1)
                take = 1;
            else if(take > 100)
                take = 100;

            using(PostgresDbContext db = new PostgresDbContext())
            {
                return db.VideoGames.ToList().Take(take);
            }
        }

        public RepositoryResult<VideoGameModel> Remove(int Id)
        {
            using(PostgresDbContext db = new PostgresDbContext())
            {
                VideoGameModel? model = db.VideoGames.FirstOrDefault(x => x.Id == Id);

                if (model == null)
                    return new RepositoryResult<VideoGameModel>(false, $"Видеоигра с id '{Id}' не найдена!");
                
                db.VideoGames.Remove(model);
                db.SaveChanges();

                return new RepositoryResult<VideoGameModel>(true);
            }
        }

        public RepositoryResult<VideoGameModel> Update(VideoGameModel data)
        {
            using(PostgresDbContext db = new PostgresDbContext())
            {
                var result = db.VideoGames.Update(data);

                if (result == null)
                    return new RepositoryResult<VideoGameModel>(false, "Не удалось найти и изменить информацию о видеоигре");

                db.SaveChanges();

                return new RepositoryResult<VideoGameModel>(true);
            }
        }
    }
}
