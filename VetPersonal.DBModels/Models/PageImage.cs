using System;
using System.Collections.Generic;

namespace VetPersonal.DBModels.Models;

public partial class PageImage
{
    public int Id { get; set; }

    public int Page { get; set; }

    public string? ImageName { get; set; }

    public virtual Page PageNavigation { get; set; } = null!;
}
