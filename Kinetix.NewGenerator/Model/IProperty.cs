﻿namespace Kinetix.NewGenerator.Model
{
    public interface IProperty
    {
        string Name { get; }
        string Label { get; }
        bool PrimaryKey { get; }
    }
}
