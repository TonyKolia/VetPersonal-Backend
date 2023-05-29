using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class ContentType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<PageContent> PageContents { get; set; } = new List<PageContent>();
}
