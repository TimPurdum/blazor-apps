﻿using System;

namespace BlazorApps.BlazorDataGrid.Utilities
{
    public class UnsupportedFieldTypeException : Exception
    {
        public UnsupportedFieldTypeException(Type? type)
        {
            Message = $"The type {type?.FullName} is not supported yet in the BdGrid";
        }

        public override string Message { get; }
    }
}