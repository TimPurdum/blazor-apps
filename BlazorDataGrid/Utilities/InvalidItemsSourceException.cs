using System;

namespace BlazorApps.BlazorDataGrid.Utilities
{
    public class InvalidItemsSourceException : Exception
    {
        public InvalidItemsSourceException(string? name)
        {
            Message = $"The type {name} is not a valid ItemsSource for a BdGrid";
        }


        public override string Message { get; }
    }
}