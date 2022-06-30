using Contents.API.Models;

namespace Contents.API
{
    public class ContentsData
    {
        public List<ContentDto> Ciudades { get; set; }

        public static ContentsData InstanciaActual { get; } = new ContentsData();

        public ContentsData()
        {
            Ciudades = new List<ContentDto>()
            {
                new ContentDto()
                {
                     Id = 1,
                     Title = "Nasdasd",
                     Duration = 34,
                     Comment = "asdasdasd"
                },
                new ContentDto()
                {
                     Id = 2,
                     Title = "ghhgh",
                     Duration = 314,
                     Comment = "asdasdasd"
                },
                new ContentDto()
                {
                     Id = 3,
                     Title = "asdasdsad",
                     Duration = 32,
                     Comment = "asdasdasd"
                },

            };
        }
    }
}
