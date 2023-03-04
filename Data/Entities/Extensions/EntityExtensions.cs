﻿using System.Text.Json;

namespace MotoApp.Data.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this T item)
    {
        var json = JsonSerializer.Serialize(item);
        return JsonSerializer.Deserialize<T>(json);
    }
}
