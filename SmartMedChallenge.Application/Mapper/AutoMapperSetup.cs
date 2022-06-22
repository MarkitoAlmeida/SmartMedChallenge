using AutoMapper;

namespace SmartMedChallenge.Application.Mapper
{
    public class AutoMapperSetup
    {
        protected AutoMapperSetup() { }

        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMap());
                cfg.AddProfile(new ViewModelToDomainMap());
            });
        }
    }
}
