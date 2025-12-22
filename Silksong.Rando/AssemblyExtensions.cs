using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Silksong.Rando;

public static class AssemblyExtensions
{
    public static Sprite LoadEmbeddedSprite(this Assembly asm, string path, float pixelsPerUnit = 64f)
    {
        using var stream = asm.GetManifestResourceStream(path);
        if (stream == null)
        {
            
        }

        var buffer = new byte[stream.Length];
        
        stream.Read(buffer, 0, buffer.Length);

        var tex = new Texture2D(2, 2);

        tex.LoadImage(buffer, false);

        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f, pixelsPerUnit);
    }

    public static string LoadEmbeddedText(this Assembly asm, string path)
    {
        using Stream? stream = asm.GetManifestResourceStream(path);
        if (stream == null)
            throw new InvalidOperationException($"Resource not found: {path}");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
