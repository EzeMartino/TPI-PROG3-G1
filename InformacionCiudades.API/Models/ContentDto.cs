using Contents.API.Entities;

namespace Contents.API.Models;
public class ContentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public int Duration { get; set; }

    public string Category { get; set; } //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

    public string? Comment { get; set; }
    public int Rating { get; set; }
}

