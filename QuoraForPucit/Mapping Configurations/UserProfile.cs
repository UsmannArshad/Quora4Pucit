using AutoMapper;
using QuoraForPucit.Models;
using QuoraForPucit.Models.ViewModel;
namespace QuoraForPucit.Mapping_Configurations
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserShowViewModel>();
        }
    }
}
