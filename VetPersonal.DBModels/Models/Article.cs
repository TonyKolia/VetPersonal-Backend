using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string? Title { get; set; }

    public string? Text { get; set; }

    public string? ImageName { get; set; }

    public virtual Language LanguageNavigation { get; set; } = null!;
}
