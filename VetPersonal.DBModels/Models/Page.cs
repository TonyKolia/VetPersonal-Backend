using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class Page
{
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string? MenuText { get; set; }

    public int PageOrder { get; set; }

    public int Visible { get; set; }

    public string? Route { get; set; }

    public virtual Language LanguageNavigation { get; set; } = null!;

    public virtual ICollection<PageContent> PageContents { get; set; } = new List<PageContent>();

    public virtual ICollection<PageImage> PageImages { get; set; } = new List<PageImage>();
}
