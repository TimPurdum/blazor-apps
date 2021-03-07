using System;

namespace BlazorDataGrid.Business
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