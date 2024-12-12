﻿using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PlannerA.Models;

public static class ProjectService
{
    private const string PATH = "project.json";

    public static IEnumerable<Project>? GetAllProjects()
    {
        var json = File.ReadAllText(PATH);
        return JsonSerializer.Deserialize<IEnumerable<Project>>(json);
    }
}