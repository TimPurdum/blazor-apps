using BlazorApps.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BlazorApps.BlazorScrumPoker
{
    public partial class ScrumTable
    {
		[Parameter]
		public string UserName { get; set; }

		[Parameter]
		public string RoomName { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
			if (_pageDicts == null)
            {
				_pageDicts = new Dictionary<string, ObservableDictionary<string, double>>();
            }

			if (!_pageDicts.ContainsKey(RoomName))
            {
				_pageDicts[RoomName] = new ObservableDictionary<string, double>();
				_showCards = new ObservableValue<bool>(false);
            }
			_pageDicts[RoomName].CollectionChanged += OnCollectionChanged;
			_showCards.PropertyChanged += OnPropertyChanged;
		}

        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			await InvokeAsync(StateHasChanged);
		}

        private async void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
			await InvokeAsync(StateHasChanged);
        }

        private ObservableDictionary<string, double> _selectedValues => _pageDicts[RoomName];

		private static Dictionary<string, ObservableDictionary<string, double>> _pageDicts;

		private static ObservableValue<bool> _showCards;
		private double _mean => _selectedValues.Select(kvp => kvp.Value).Sum() / _selectedValues.Count;
		private double _median
		{
			get
			{
				var count = _selectedValues.Count;
				var values = _selectedValues.Select(kvp => kvp.Value).OrderBy(v => v).ToArray();
				
				if (count <= 2)
                {
					return _mean;
                }

				if (count % 2 == 0)
				{
					return (values[count / 2 - 1] + values[count / 2]) / 2;
				}
				
				return values[count / 2];
			}
		}
		private double _mode => _selectedValues.Select(kvp => kvp.Value).GroupBy(v => v).OrderBy(g => g.Count()).LastOrDefault()?.Key ?? 0;

		private void CardClicked(Tuple<string, double> values)
		{
			_selectedValues[values.Item1] = values.Item2;
		}

		private void ToggleCards()
		{
			_showCards.Value = !_showCards.Value;
		}

		private void ClearSelections()
        {
			_selectedValues.Clear();
			_showCards.Value = false;
        }
	}
}
