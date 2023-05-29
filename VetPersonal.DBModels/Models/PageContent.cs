using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class PageContent
{
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string? Text { get; set; }

    public int Type { get; set; }

    public int ContentOrder { get; set; }

    public int Page { get; set; }

    public virtual Language LanguageNavigation { get; set; } = null!;

    public virtual Page PageNavigation { get; set; } = null!;

    public virtual ContentType TypeNavigation { get; set; } = null!;
}
