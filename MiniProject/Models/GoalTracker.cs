using System;
using System.Collections.Generic;

namespace MiniProject.Models;

public partial class GoalTracker
{
    public int GoalId { get; set; }

    public string Title { get; set; } = null!;

    public string? Discriptin { get; set; }

    public DateTime StartDate { get; set; }

    public bool IsComplete { get; set; }
}
