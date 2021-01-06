using AutoMapper;

namespace Services.AutoMapper
{
    public abstract class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            CreateProfile();
        }

        protected abstract void CreateProfile();
    }
}