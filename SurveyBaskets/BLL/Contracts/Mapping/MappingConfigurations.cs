namespace SurveyBaskets.BLL.Contracts.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>()
                .Map(Dest => Dest.Summary, src => src.Summary);
        }
    }
}
  