using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class Language
{
    public string Id { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<PageContent> PageContents { get; set; } = new List<PageContent>();

    public virtual ICollection<Page> Pages { get; set; } = new List<Page>();
}
