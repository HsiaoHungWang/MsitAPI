using MsitAPI.Models;

namespace MsitAPI.Models.Dto
{
    public class SpotsPagingDto
    {
        public int TotalPages { get; set; }
       // public int TotalCount { get; set; }
        public List<SpotImagesSpot>? SpotsResult { get; set; }
    }
}
