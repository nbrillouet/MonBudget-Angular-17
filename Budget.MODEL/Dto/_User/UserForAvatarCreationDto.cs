using Microsoft.AspNetCore.Http;

namespace Budget.MODEL.Dto
{
    public class UserForAvatarCreationDto
    {
        public string AvatarUrl { get; set; }
        public IFormFile File { get; set; }
        public string IdAvatarCloud { get; set; }

        public UserForAvatarCreationDto()
        {

        }
    }
}
