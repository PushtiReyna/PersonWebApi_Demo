using Mapster;
using MapsterMapper;

namespace PersonWebApi.ViewModel
{
    public class DeletePersonReqViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
